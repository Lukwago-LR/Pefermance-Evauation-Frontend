using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SATRI_CLIENT
{
    public static class global
    {
        public static string _globalVar = "";

        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
    }
}
