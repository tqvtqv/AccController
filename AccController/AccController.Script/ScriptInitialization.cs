using Serenity;
using System.Html;

namespace AccController
{
    public static class ScriptInitialization
    {
        static ScriptInitialization()
        {
            Q.Config.RootNamespaces.Add("AccController");
        }
    }
}