using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML;
using COSXML.Utils;
using COSXML.Log;
using COSXML.CosException;
using COSXML.Common;

namespace Demo
{
    class DemoApp
    {
        private const string TAG = "DemoApp";
        static void Main(string[] args)
        {
            /**
            COSValueAttribute cosValueAttribute = new COSValueAttribute("value");

            string value = cosValueAttribute.value;

            Console.WriteLine(cosValueAttribute.value);

            foreach(COSRegion region in Enum.GetValues(typeof(COSRegion)))
            {
                 Console.WriteLine(EnumUtils.GetValue(region));
            }
             */
            /**
            QLog.SetLogLevel(LEVEL.V);
            QLog.I(TAG, CosVersion.SDKVersion, null);
            QLog.W(TAG, "this is warning message", null);
            QLog.V(TAG, "this is a verbose message", null);
            QLog.D(TAG, "this is a debug message", null);
            QLog.I(TAG, "this is a info message", null);
            QLog.E(TAG, "this is a error message", null);

            try
            {
                CosClientException clientException = new CosClientException("4000", "this is client exception");
               // QLog.E(TAG, clientException.Message, clientException);
              
                throw clientException;
            }
            catch (CosClientException ex)
            {
                QLog.E(TAG, ex.ToString(), ex);
            }
            */
            SupperA supper = new SubB();
            supper.commonMethod();
            supper.virtualMethod();
            SupperA.staticMethod();

            Console.ReadKey();
        }
    }

    class SupperA
    {
        protected string filed;
        protected static string staticFiled;

        public SupperA()
        {
            filed = "supper";
            staticFiled = "supper static";
        }

        public void commonMethod()
        {
            Console.WriteLine("this is super common method: " + filed);
        }

        public virtual void virtualMethod()
        {
            Console.WriteLine("this is super virtual method: " + filed);
        }

        public static void staticMethod()
        {
            Console.WriteLine("this is super static method: " + staticFiled);
        }

    }

    class SubB : SupperA
    {
        public SubB()
        {
            filed = "sub";
            staticFiled = "sub static";
        }
        public void commonMethod()
        {
            Console.WriteLine("this is sub common method: " + filed);
        }

        public override void virtualMethod()
        {
            Console.WriteLine("this is sub virtual method: " + filed);
        }

        public static void staticMethod()
        {
            Console.WriteLine("this is sub static method: " + staticFiled);
        }
    }
}
