using Newtonsoft.Json;
using System.Collections.Generic;

namespace Worker
{
    public static class Constants
    {
        //public static string ApiUrl = "https://testcore.whyise.com";
        public static string ApiUrl = "http://localhost:61124";

        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings { Formatting = Formatting.Indented, ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
    }
}