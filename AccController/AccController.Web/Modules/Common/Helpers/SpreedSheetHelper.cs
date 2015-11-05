using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

namespace AccController.Modules.Common.Helpers
{
    public class SpreedSheetHelper
    {
        //public DbContext Db { get; set; }
        public string TemplatePath { get; set; }
        public Boolean HasError { get; set; }
        protected UInt32Value errCellStyleIndex;
        protected CultureInfo cultureInfo;
        /// <summary>
        /// Template path to parse input spreadsheet
        /// </summary>
        /// <param name="templatePath"></param>
        public SpreedSheetHelper(string templatePath)
        {
            this.TemplatePath = templatePath;
            HasError = false;
            cultureInfo = new CultureInfo("vi");
            cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            

        }
        //public SpreedSheetHelper(DbContext ctx, string templatePath)
        //{
        //    this.TemplatePath = templatePath;
        //    this.Db = ctx;
        //}
        public MemoryStream OpenTemplate()
        {
            if (File.Exists(TemplatePath))
            {
                var f = File.OpenRead(TemplatePath);
                var stream = new MemoryStream();
                f.CopyTo(stream);
                f.Close();
                return stream;
            }
            else
                return null;
        }
        public CommonWorkSheet GetTemplateSheet()
        {
            try
            {
                var sheet = new CommonWorkSheet();
                var templateWorkPart = SpreadsheetDocument.Open(OpenTemplate(), false).WorkbookPart;
                sheet.Sheet = templateWorkPart.WorksheetParts.First().Worksheet;
                #region build defined names
                sheet.DefinedNames = BuildDefinedNamesTable(templateWorkPart, 0);
                #endregion
                return sheet;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public T ReadFromFile<T>(T container, Stream file) where T : class, new()
        {
            if (container == null)
                container = new T();
            WorkbookPart workbookPart;
            var document = SpreadsheetDocument.Open(file, true);
            workbookPart = document.WorkbookPart;
            #region add style
            if (document.WorkbookPart.WorkbookStylesPart == null)
                document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            var stylesPart = document.WorkbookPart.WorkbookStylesPart;
            Stylesheet styleSheet = document.WorkbookPart.WorkbookStylesPart.Stylesheet;
            if (styleSheet == null)
                styleSheet = new Stylesheet { Fills = new Fills() };

            //stylesPart.Stylesheet.Fills = new Fills();

            // create a solid red fill
            var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
            solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFFF0000") }; // red fill
            solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };
            styleSheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); // required, reserved by Excel
            styleSheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); // required, reserved by Excel
            styleSheet.Fills.AppendChild(new Fill { PatternFill = solidRed });

            if (styleSheet.CellFormats == null)
            {
                styleSheet.CellFormats = new CellFormats();// cell format list
                styleSheet.CellFormats.AppendChild(new CellFormat());// empty one for index 0, seems to be required
            }

            // cell format references style format 0, font 0, border 0, fill 2 and applies the fill
            styleSheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 2, ApplyFill = true });
            
            styleSheet.Save();

            errCellStyleIndex = styleSheet.CellFormats.Count - 1;
            #endregion

            FillObject(container, workbookPart, GetTemplateSheet());
            return container;
        }

        private void FillObject<T>(T container, WorkbookPart workbookPart, CommonWorkSheet templateSheet) where T : class, new()
        {
            #region Fill Single cell
            foreach (var item in templateSheet.DefinedNames.Where(n => !n.IsRange))
                SetObjValue<T>(container, item, workbookPart);
            #endregion
            #region Fill Range cells
            foreach (var item in templateSheet.DefinedNames.Where(n => n.IsRange))
            {
                var startRow = item.StartRow;
                var count = FillRangeObjs(container, item, workbookPart);
                if (count > 0)
                    foreach (var c in templateSheet.DefinedNames.Where(n => Convert.ToInt32(n.StartRow) > Convert.ToInt32(startRow)))
                        c.ShiftRows(count);
            }
            #endregion
        }



        public T GetTemplate<T>() where T : ICommonSheet, new()
        {
            var f = File.OpenRead(TemplatePath);
            using (MemoryStream stream = new MemoryStream())
            {
                f.CopyTo(stream);

            }
            if (File.Exists(TemplatePath))
                return GetSheet<T>(File.OpenRead(TemplatePath), 0);

            return new T();
        }
        public T GetSheet<T>(Stream file, int sheetIndex) where T : ICommonSheet, new()
        {
            // Open the excel document
            WorkbookPart workbookPart;

            var document = SpreadsheetDocument.Open(file, false);
            workbookPart = document.WorkbookPart;
            if (sheetIndex < 0)
                sheetIndex = 0;
            var data = new T();
            var sheets = workbookPart.Workbook.Descendants<Sheet>();
            if (sheets.Count() > sheetIndex)
                data.SheetName = sheets.ToList()[sheetIndex].Name;
            else
                data.SheetName = sheets.FirstOrDefault().Name;
            var defNames = workbookPart.Workbook.DefinedNames;
            var x = GetTemplateSheet();
            return data;

        }
        public IEnumerable<T> GetSheet<T>(Stream file) where T : ICommonSheet, new()
        {
            // Open the excel document
            WorkbookPart workbookPart;
            List<Row> rows;

            var document = SpreadsheetDocument.Open(file, false);
            workbookPart = document.WorkbookPart;

            var sheets = workbookPart.Workbook.Descendants<Sheet>();
            foreach (var sheet in sheets)
            {
                var data = new T();
                data.SheetName = sheet.Name;
                try
                {
                    var workSheet = ((WorksheetPart)workbookPart
                        .GetPartById(sheet.Id)).Worksheet;
                    var columns = workSheet.Descendants<Columns>().FirstOrDefault();
                    data.ColumnConfigurations = columns;
                    var sheetData = workSheet.Elements<SheetData>().First();
                    rows = sheetData.Elements<Row>().ToList();
                }
                catch (Exception e)
                {
                    data.Message = "Unable to open the file: " + e.Message;
                }
                yield return data;
            }


            // Read the header
            //if (rows.Count > 0)
            //{
            //    var row = rows[0];
            //    var cellEnumerator = GetExcelCellEnumerator(row);
            //    while (cellEnumerator.MoveNext())
            //    {
            //        var cell = cellEnumerator.Current;
            //        var text = ReadExcelCell(cell, workbookPart).Trim();
            //        data.Headers.Add(text);
            //    }
            //}

            //// Read the sheet data
            //if (rows.Count > 1)
            //{
            //    for (var i = 1; i < rows.Count; i++)
            //    {
            //        var dataRow = new List<string>();
            //        data.DataRows.Add(dataRow);
            //        var row = rows[i];
            //        var cellEnumerator = GetExcelCellEnumerator(row);
            //        while (cellEnumerator.MoveNext())
            //        {
            //            var cell = cellEnumerator.Current;
            //            var text = ReadExcelCell(cell, workbookPart).Trim();
            //            dataRow.Add(text);
            //        }
            //    }
            //}

        }


        #region file proccessing

        private int ConvertColumnNameToNumber(string columnName)
        {
            var alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName)) throw new ArgumentException();

            char[] colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);

            var convertedValue = 0;
            for (int i = 0; i < colLetters.Length; i++)
            {
                char letter = colLetters[i];
                // ASCII 'A' = 65
                int current = i == 0 ? letter - 65 : letter - 64;
                convertedValue += current * (int)Math.Pow(26, i);
            }

            return convertedValue;
        }

        private IEnumerator<Cell> GetExcelCellEnumerator(Row row)
        {
            int currentCount = 0;
            foreach (Cell cell in row.Descendants<Cell>())
            {
                string columnName = GetColumnName(cell.CellReference);

                int currentColumnIndex = ConvertColumnNameToNumber(columnName);

                for (; currentCount < currentColumnIndex; currentCount++)
                {
                    var emptycell = new Cell()
                    {
                        DataType = null,
                        CellValue = new CellValue(string.Empty)
                    };
                    yield return emptycell;
                }

                yield return cell;
                currentCount++;
            }
        }

        private string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            var cellValue = cell.CellValue;
            var text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable
                    .Elements<SharedStringItem>().ElementAt(
                        Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }

            return (text ?? string.Empty).Trim();
        }
        string[] headerColumns = new string[] { "A", "B", "C" };
        Row CreateContentRow(int index, string territory, decimal salesLastYear, decimal salesThisYear)
        {
            //Create the new row.
            Row r = new Row();
            r.RowIndex = (UInt32)index;
            //First cell is a text cell, so create it and append it.
            Cell firstCell = CreateTextCell(headerColumns[0], territory, index);
            r.AppendChild(firstCell);
            //Create the cells that contain the data.
            for (int i = 1; i < headerColumns.Length; i++)
            {
                Cell c = new Cell();
                c.CellReference = headerColumns[i] + index;
                CellValue v = new CellValue();
                if (i == 1)
                    v.Text = salesLastYear.ToString();
                else
                    v.Text = salesThisYear.ToString();
                c.AppendChild(v);
                r.AppendChild(c);
            }
            return r;
        }
        Cell CreateTextCell(string header, string text, int index)
        {
            //Create a new inline string cell.
            Cell c = new Cell();
            c.DataType = CellValues.InlineString;
            c.CellReference = header + index;
            //Add text to the text cell.
            InlineString inlineString = new InlineString();
            Text t = new Text();
            t.Text = text;
            inlineString.AppendChild(t);
            c.AppendChild(inlineString);
            return c;
        }
        void FixChartData(WorkbookPart workbookPart, int totalCount)
        {
            //Get the appropriate chart part from template file.
            ChartPart chartPart = workbookPart.ChartsheetParts.First().DrawingsPart.ChartParts.First();
            //Change the ranges to accomodate the newly inserted data.
            //foreach (Charts.Formula formula in chartPart.ChartSpace.Descendants<Charts.Formula>())
            //{
            //    if (formula.Text.Contains("$2"))
            //    {
            //        string s = formula.Text.Split('$')[1];
            //        formula.Text += ":$" + s + "$" + totalCount;
            //    }
            //}
            chartPart.ChartSpace.Save();
        }

        static List<DefinedNameVal> BuildDefinedNamesTable(WorkbookPart workbookPart, int sheetId)
        {
            //Build a list. 
            List<DefinedNameVal> definedNames = new List<DefinedNameVal>();
            foreach (DefinedName name in workbookPart.Workbook.DefinedNames)
            {
                if ((!name.LocalSheetId.HasValue) || (name.LocalSheetId.Value == sheetId))
                {
                    var defName = new DefinedNameVal(name);
                    defName.SheetId = sheetId.ToString();
                    if ((!string.IsNullOrEmpty(defName.EndColumn)) && (defName.EndColumn != defName.StartColumn))
                    {
                        defName.IsRange = true;
                        if (name.Comment != null)
                        {
                            defName.Parameter = JsonConvert.DeserializeObject<SheetParameter>(name.Comment.InnerText);
                            defName.Columns = new List<DefinedNameVal>();
                            var row = GetWorkSheetPart(workbookPart, defName).Worksheet.GetFirstChild<SheetData>().Descendants<Row>().FirstOrDefault(r => ((Row)r).RowIndex == Convert.ToInt32(defName.StartRow));
                            if (row != null)
                                foreach (var cell in row.Descendants<Cell>())
                                {
                                    var value = GetValue(cell, workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault());
                                    if (!string.IsNullOrEmpty(value) && value.StartsWith("{") && value.EndsWith("}"))
                                        defName.Columns.Add(new DefinedNameVal
                                        {
                                            Key = cell.CellReference,
                                            Reference = cell.CellReference,
                                            SheetId = defName.SheetId,
                                            SheetName = defName.SheetName,
                                            StartRow = defName.StartRow,
                                            StartColumn = GetColumnName(cell.CellReference),
                                            Parameter = JsonConvert.DeserializeObject<SheetParameter>(value)
                                        });
                                }
                        }
                    }
                    else
                        GetSheetParameter(workbookPart, defName);
                    definedNames.Add(defName);
                }
            }
            return definedNames;
        }

        private static void GetSheetParameter(WorkbookPart workbookPart, DefinedNameVal defName)
        {
            defName.Parameter = JsonConvert.DeserializeObject<SheetParameter>(
                GetCellValue(GetWorkSheetPart(workbookPart, defName),
                workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault(),
                defName.StartColumn, defName.StartRow));
        }

        private static WorksheetPart GetWorkSheetPart(WorkbookPart workbookPart, DefinedNameVal definedName)
        {
            //Get worksheet based on defined name. 
            string relId = workbookPart.Workbook.Descendants<Sheet>().Where(s => definedName.SheetName.Equals(s.Name)).First().Id;
            return (WorksheetPart)workbookPart.GetPartById(relId);
        }


        public static string GetCellValue(WorkbookPart wbPart, Cell theCell)
        {
            string value = null;

            // If the cell does not exist, return an empty string.
            if (theCell != null)
            {
                value = theCell.InnerText;

                // If the cell represents an integer number, you are done. 
                // For dates, this code returns the serialized value that 
                // represents the date. The code handles strings and 
                // Booleans individually. For shared strings, the code 
                // looks up the corresponding value in the shared string 
                // table. For Booleans, the code converts the value into 
                // the words TRUE or FALSE.
                if (theCell.DataType != null)
                {
                    switch (theCell.DataType.Value)
                    {
                        case CellValues.SharedString:

                            // For shared strings, look up the value in the
                            // shared strings table.
                            var stringTable =
                                wbPart.GetPartsOfType<SharedStringTablePart>()
                                .FirstOrDefault();

                            // If the shared string table is missing, something 
                            // is wrong. Return the index that is in
                            // the cell. Otherwise, look up the correct text in 
                            // the table.
                            if (stringTable != null)
                            {
                                value =
                                    stringTable.SharedStringTable
                                    .ElementAt(int.Parse(value)).InnerText;
                            }
                            break;

                        case CellValues.Boolean:
                            switch (value)
                            {
                                case "0":
                                    value = "FALSE";
                                    break;
                                default:
                                    value = "TRUE";
                                    break;
                            }
                            break;
                    }
                }
            }
            return value;
        }

        static string GetCellValue(WorksheetPart worksheetPart, SharedStringTablePart stringTablePart, string startCol, string startRow)
        {
            string reference = startCol + startRow;
            //Get the exact cell based on the reference. 
            Cell cell = worksheetPart.Worksheet.Descendants<Cell>().Where(c => reference.Equals(c.CellReference)).First();
            return GetValue(cell, stringTablePart);
        }
        static string GetValue(Cell cell, SharedStringTablePart stringTablePart)
        {
            if (cell.ChildElements.Count == 0) return null;
            //Get the cell value. 
            string value = cell.CellValue.InnerText;
            //Look up the real value from shared string table. 
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                value = stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            return value;
        }
        private static uint GetRowIndex(string cellName)
        {
            // Create a regular expression to match the row index portion the cell name.
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(cellName);

            return uint.Parse(match.Value);
        }
        private static string GetColumnName(string cellName)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellName);

            return match.Value;
        }
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        private static int CompareColumn(string column1, string column2)
        {
            if (column1.Length > column2.Length)
            {
                return 1;
            }
            else if (column1.Length < column2.Length)
            {
                return -1;
            }
            else
            {
                return string.Compare(column1, column2, true);
            }
        }
        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create it.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    // The text already exists in the part. Return its index.
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }
        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                worksheet.Save();
                return newCell;
            }
        }
        #endregion
        #region fill objects
        private int FillRangeObjs<T>(T container, DefinedNameVal item, WorkbookPart workbookPart) where T : class, new()
        {
            var count = 0;
            ParameterExpression param = Expression.Parameter(typeof(T), "parm");
            MemberExpression member = Expression.Property(param, item.Parameter.Field);
            if ((member.Type != typeof(string)) && typeof(IEnumerable).IsAssignableFrom(member.Type))
            {
                Type listType = typeof(List<>).MakeGenericType(new[] { member.Type.GetGenericArguments()[0] });
                dynamic list = Activator.CreateInstance(listType);


                var stop = false;

                while (!stop)
                {
                    dynamic obj = Activator.CreateInstance(member.Type.GetGenericArguments()[0]);
                    var adding = false;
                    foreach (var col in item.Columns)
                    {
                        var value = SetObjValue(obj, col, workbookPart);
                        if (!string.IsNullOrEmpty(value))
                        {
                            adding = true;
                        }
                    }
                    if (adding)
                    {
                        count++;
                        list.Add(obj);
                    }
                    stop = !adding;
                    item.ShiftRows(1);
                }
                ((PropertyInfo)member.Member).SetValue(container, list);

            }
            return count;
        }

        private string SetObjValue<T>(T container, DefinedNameVal item, WorkbookPart workbookPart) where T : class, new()
        {
            // Retrieve a reference to the worksheet part.
            WorksheetPart wsPart =
                (WorksheetPart)(workbookPart.GetPartById(workbookPart.Workbook.Descendants<Sheet>().First().Id));
            // Use its Worksheet property to get a reference to the cell 
            // whose address matches the address you supplied.
            Cell theCell = wsPart.Worksheet.Descendants<Cell>().
              Where(c => c.CellReference == item.Reference).FirstOrDefault();
            var value = GetCellValue(workbookPart, theCell);
            if (!string.IsNullOrEmpty(value) && (item.Parameter != null))
                try
                {
                    SetObjValue<T>(container, item, value);
                }
                catch (Exception ex)
                {
                    theCell.CellValue = new CellValue(string.Format("{0}({1})", value, ex.Message));
                    theCell.StyleIndex = errCellStyleIndex;
                    HasError = true;
                    workbookPart.Workbook.Save();
                    //workbookPart
                }
            return value;
        }

        private void SetObjValue<T>(T container, DefinedNameVal item, string value) where T : class, new()
        {
            switch (item.Parameter.Type)
            {
                case "FK"://Foreignkey
                    value = GetFKValue(container, item, value);
                    break;
                case "Tbl"://Foreignkey
                    value = GetTblFKValue(container, item, value);
                    break;
                case "Query"://Foreignkey
                    value = GetQueryFKValue(container, item, value);
                    break;
            }
            if (!string.IsNullOrEmpty(value))
            {
                // Create the parameter for the ObjectType (typically the 'x' in your expression (x => 'x')
                // The "parm" string is used strictly for debugging purposes
                ParameterExpression param = Expression.Parameter(container.GetType(), "parm");
                MemberExpression member = Expression.Property(param, item.Parameter.Field);
                ConstantExpression constant;
                if (member.Type.IsGenericType && member.Type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    if (Nullable.GetUnderlyingType(member.Type) == typeof(DateTime) && !value.Contains("/"))
                        constant = Expression.Constant(Convert.ChangeType(FromExcelSerialDate(Convert.ToInt32(value)), Nullable.GetUnderlyingType(member.Type), cultureInfo));
                    else
                        constant = Expression.Constant(Convert.ChangeType(value, Nullable.GetUnderlyingType(member.Type), cultureInfo));
                    Expression.Assign(member, Expression.Convert(constant, member.Type));
                    BinaryExpression assignExp = Expression.Assign(member, Expression.Convert(constant, member.Type));
                    var actionT = typeof(Action<>).MakeGenericType(container.GetType());
                    //Delegate.CreateDelegate(actionT, container.GetType().GetMethod("Invoke"))
                    Expression.Lambda<Action<T>>(assignExp, param)
                        .Compile()
                        .Invoke(container);
                }
                else
                {
                    if (member.Type == typeof(DateTime) && !value.Contains("/"))
                        constant = Expression.Constant(Convert.ChangeType(FromExcelSerialDate(Convert.ToInt32(value)), member.Type, cultureInfo));
                    else
                        constant = Expression.Constant(Convert.ChangeType(value, member.Type, cultureInfo));
                    BinaryExpression assignExp = Expression.Assign(member, constant);
                    Expression.Lambda<Action<T>>(assignExp, param)
                         .Compile()
                         .Invoke(container);
                }
            }
        }

        private string GetFKValue<T>(T container, DefinedNameVal item, string value) where T : class, new()
        {
            //if (Db != null)
            //{
            //    ParameterExpression param = Expression.Parameter(Db.GetType(), "parm");
            //    MemberExpression member = Expression.Property(param, item.Parameter.FkObj);
            //    if ((member.Type != typeof(string)) && typeof(IEnumerable).IsAssignableFrom(member.Type))
            //    {
            //        //Db.Set(member.Type).ForEachAsync()

            //        Type listType = typeof(List<>).MakeGenericType(new[] { member.Type });
            //        IList list = (IList)Activator.CreateInstance(listType);
            //        throw new NotSupportedException();
            //    }
            //}
            return value;
        }
        private string GetTblFKValue<T>(T container, DefinedNameVal item, string value) where T : class, new()
        {
            //if (Db != null)
            //{
            //    var fkValue = Db.Database.SqlQuery<string>(string.Format("Select CONVERT(varchar, {0}) From {1} Where CONVERT(nvarchar, {2}) = N'{3}'", item.Parameter.FkKey, item.Parameter.FkObj, item.Parameter.FkText, value)).FirstOrDefault();
            //    if (!string.IsNullOrEmpty(fkValue)) return fkValue;
            //}
            return value;
        }
        private string GetQueryFKValue<T>(T container, DefinedNameVal item, string value) where T : class, new()
        {
            //if (Db != null)
            //{
            //    var fkValue = Db.Database.SqlQuery<string>(item.Parameter.Query, value).FirstOrDefault();
            //    if (!string.IsNullOrEmpty(fkValue)) return fkValue;
            //}
            return value;
        }

        public static DateTime FromExcelSerialDate(int SerialDate)
        {
            if (SerialDate > 59) SerialDate -= 1; //Excel/Lotus 2/29/1900 bug   
            return new DateTime(1899, 12, 31).AddDays(SerialDate);
        }
        #endregion


        #region export Xls
        public static MemoryStream ExportXls<T>(IEnumerable<T> listObjs)
        {
            if (listObjs != null && listObjs.Any())
            {
                var stream = new MemoryStream();
                using (SpreadsheetDocument workbook = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook, true))
                {
                    // create the workbook
                    var workbookPart = workbook.AddWorkbookPart();
                    workbook.WorkbookPart.Workbook = new Workbook();     // create the worksheet
                    workbook.WorkbookPart.Workbook.Sheets = new Sheets();

                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new SheetData();
                    sheetPart.Worksheet = new Worksheet(sheetData);

                    Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    uint sheetId = 1;
                    if (sheets.Elements<Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1; 
                    }

                    Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = $"DanhSach{nameof(T)}" };
                    sheets.Append(sheet);


                    foreach (var item in listObjs)
                    {
                        Row newRow = new Row();

                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        //cell.CellValue = new CellValue(item.SoDienThoai); //
                        newRow.AppendChild(cell);

                        sheetData.AppendChild(newRow);
                    }

                }
                stream.Seek(0, SeekOrigin.Begin);
                return stream;
            }
            else
                return null;
        }
        #endregion
    }
    public class CommonWorkSheet : ICommonSheet
    {
        public Columns ColumnConfigurations { get; set; }

        public List<List<string>> DataRows { get; set; }

        public List<string> Headers { get; set; }

        public string Message { get; set; }

        public string SheetName { get; set; }

        public int Status { get; set; }

        public Worksheet Sheet { get; set; }

        public List<DefinedNameVal> DefinedNames { get; set; }
    }
    public interface ICommonSheet
    {
        int Status { get; set; }
        string Message { get; set; }
        Columns ColumnConfigurations { get; set; }
        List<string> Headers { get; set; }
        List<List<string>> DataRows { get; set; }
        List<DefinedNameVal> DefinedNames { get; set; }
        string SheetName { get; set; }
        Worksheet Sheet { get; set; }
    }
    public interface IParamDefinition
    {
        string Type { get; set; }
    }
    public class DefinedNameVal
    {
        public DefinedNameVal() { }
        public DefinedNameVal(DefinedName defName)
        {
            this.Key = defName.Name;
            this.Reference = defName.InnerText;
            this.SheetName = this.Reference.Split('!')[0].Trim('\'');
            //Assumption: None of the defined names are relative defined names (i.e. A1). 
            string range = this.Reference.Split('!')[1];
            string[] rangeArray = range.Split('$');
            this.StartColumn = rangeArray[1];
            this.StartRow = rangeArray[2].TrimEnd(':');
            if (rangeArray.Length > 3)
            {
                this.EndColumn = rangeArray[3];
                this.EndRow = rangeArray[4];
            }
        }
        public string Key { get; set; }
        public string SheetId { get; set; }
        public string SheetName { get; set; }
        public string Reference { get; set; }

        public string StartColumn { get; set; }

        public string StartRow { get; set; }

        public string EndColumn { get; set; }

        public string EndRow { get; set; }
        public bool IsRange { get; set; }
        public SheetParameter Parameter { get; set; }
        public List<DefinedNameVal> Columns { get; set; }
        public void ShiftRows(int numOfRows)
        {
            if (string.IsNullOrEmpty(StartRow)) return;
            var curRow = Convert.ToInt32(StartRow);
            curRow = curRow + numOfRows;
            if (curRow < 0) curRow = 0;
            this.StartRow = curRow.ToString();
            this.Reference = string.Concat(this.StartColumn, this.StartRow);
            if ((!string.IsNullOrEmpty(this.EndColumn)) && (!string.IsNullOrEmpty(this.EndRow)))
            {
                var newEndRow = Convert.ToInt32(EndRow) + numOfRows;
                if (newEndRow < 0) newEndRow = 0;
                this.EndRow = newEndRow.ToString();
                this.Reference = string.Concat(this.Reference, ":", this.EndColumn, this.EndRow);
            }
            if (this.Columns != null && this.Columns.Any())
                this.Columns.ForEach(c => c.ShiftRows(numOfRows));
        }
    }
    public class SingleNameVal : DefinedNameVal
    { }
    public class TableNameVal : DefinedNameVal
    {
        public IEnumerable<SingleNameVal> Body { get; set; }
        public IEnumerable<SingleNameVal> Footer { get; set; }
    }
    public class SheetParameter
    {
        /// <summary>
        /// FK: Foreign key to another entity
        /// Tbl: Foreign key to another table
        /// Query: Foreign key to another table
        /// default: Property of object
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Property of object
        /// </summary>
        public string Field { get; set; }
        public bool IsGroup { get; set; }
        public string Aggregates { get; set; }
        /// <summary>
        /// Foreign object: table or entity
        /// </summary>
        public string FkObj { get; set; }
        /// <summary>
        /// foreign key
        /// </summary>
        public string FkKey { get; set; }
        /// <summary>
        /// foreign text
        /// </summary>
        public string FkText { get; set; }
        public string Query { get; set; }
    }
}
