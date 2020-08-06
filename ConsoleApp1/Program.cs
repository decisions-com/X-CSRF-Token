using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var f = new XCSRFToken.X_CSRF();
             var result  = f.GetCSRF("developer", "Down1oad", "http://172.16.1.39:8000/sap/opu/odata/sap/ZODATA_BILLING_SRV/");
            var ff = result.Result;


        }
    }
}
