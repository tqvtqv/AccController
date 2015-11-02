
using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace AccController.Northwind
{
    public partial class EmployeeFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "AccController.Northwind.EmployeeFormatter";
    
        public EmployeeFormatterAttribute()
            : base(Key)
        {
        }
    
        public String GenderProperty
        {
            get { return GetOption<String>("genderProperty"); }
            set { SetOption("genderProperty", value); }
        }
    }

    public partial class FreightFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "AccController.Northwind.FreightFormatter";
    
        public FreightFormatterAttribute()
            : base(Key)
        {
        }
    }

    public partial class ShipperFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "AccController.Northwind.ShipperFormatter";
    
        public ShipperFormatterAttribute()
            : base(Key)
        {
        }
    }
}

