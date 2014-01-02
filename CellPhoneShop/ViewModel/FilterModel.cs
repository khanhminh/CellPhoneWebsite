using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class FilterModel
    {
        public string[] brand { get; set; }
        public string[] os { get; set; }
        public string[] price { get; set; }
        public string[] star { get; set; }

        public string query { get; set; }
        public int page { get; set; }
        public string sortby { get; set; }
        public int view { get; set; }

        public static string ToString(string[] value)
        {
            string result = "";
            if (value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    result += value[i];
                    if (i != value.Length - 1)
                    {
                        result += ",";
                    }
                }
            }

            return result;
        }
    }
}