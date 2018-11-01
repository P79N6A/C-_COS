using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML;
using COSXML.Utils;

namespace Demo
{
    class DemoApp
    {
        static void Main(string[] args)
        {
            COSValueAttribute cosValueAttribute = new COSValueAttribute("value");

            string value = cosValueAttribute.value;

            Console.WriteLine(cosValueAttribute.value);

           foreach(COSRegion region in Enum.GetValues(typeof(COSRegion)))
           {
               Console.WriteLine(EnumUtils.GetValue(region));
           }
            
            Console.ReadKey();
        }
    }
}
