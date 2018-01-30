using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA1_MVCApp.Models
{
    public static class Logger
    {
        public static void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}