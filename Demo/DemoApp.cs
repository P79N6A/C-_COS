using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML;
using COSXML.Utils;
using COSXML.Log;
using COSXML.CosException;
using COSXML.Common;
using System.IO;
using COSXML.Model.Tag;
using COSXML.Transfer;

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
            /**
            SupperA supper = new SubB();
            supper.commonMethod();
            supper.virtualMethod();
            SupperA.staticMethod();
            */

            /**
            string content = "<ListAllMyBucketsResult>"
                        + "<Owner>"
                        + " <ID>qcs::cam::uin/1147518609:uin/1147518609</ID>"
                        + "<DisplayName>1147518609</DisplayName>"
                        + " </Owner>"
                        + "<Buckets>"
                            + "<Bucket>"
                                + "<Name>01</Name>"
                                + "<Location>ap-beijing</Location>"
                                + "<CreateDate>2016-09-13 15:20:15</CreateDate>"
                            + "</Bucket>"
                            + "<Bucket>"
                                + "<Name>0111</Name>"
                                + "<Location>ap-hongkong</Location>"
                                + "<CreateDate>2017-01-11 17:23:51</CreateDate>"
                            + "</Bucket>"
                            + "<Bucket>"
                                + "<Name>1201new</Name>"
                                + "<Location>eu-frankfurt</Location>"
                                + "<CreateDate>2016-12-01 09:45:02</CreateDate>"
                            + "</Bucket>"
                        + "</Buckets>"
                    + "</ListAllMyBucketsResult>";

            byte[] bytes = Encoding.ASCII.GetBytes(content);
            MemoryStream memoryStream = new MemoryStream(bytes);
            ListAllMyBuckets result = new ListAllMyBuckets();
            XmlParse.ParseListAllMyBucketsResult(memoryStream, result);
            //QLog.D("XIAO", result.GetInfo(), null);
            Console.WriteLine(result.GetInfo());
            */

            testCORSCOnfig();

            Console.ReadKey();
        }

        public static void testCORSCOnfig()
        {
            CORSConfiguration corsConfig = new CORSConfiguration();
            corsConfig.corsRules = new List<CORSConfiguration.CORSRule>();
            for (int i = 0; i < 3; i++)
            {
                CORSConfiguration.CORSRule corsRule = new CORSConfiguration.CORSRule();
                corsRule.id = (i + 1).ToString();
                corsRule.allowedOrigin = "http://www.cloud.tencent.com";
                corsRule.maxAgeSeconds = 5000;

                corsRule.allowedMethods = new List<string>();
                corsRule.allowedMethods.Add("PUT");
                corsRule.allowedMethods.Add("GET");
                corsRule.allowedMethods.Add("DELETE");

                corsRule.allowedHeaders = new List<string>();
                corsRule.allowedHeaders.Add("Host");
                corsRule.allowedHeaders.Add("Authorizition");
                corsRule.allowedHeaders.Add("Content-Length");

                corsRule.exposeHeaders = new List<string>();
                corsRule.exposeHeaders.Add("X-COS-Meta1");
                corsRule.exposeHeaders.Add("X-COS-Meta2");
                corsRule.exposeHeaders.Add("X-COS-Meta2");
                corsConfig.corsRules.Add(corsRule);
            }
            Console.WriteLine(XmlBuilder.BuildCORSConfigXML(corsConfig));
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
        public new void commonMethod()
        {
            Console.WriteLine("this is sub common method: " + filed);
        }

        public override void virtualMethod()
        {
            Console.WriteLine("this is sub virtual method: " + filed);
        }

        public new static void staticMethod()
        {
            Console.WriteLine("this is sub static method: " + staticFiled);
        }
    }
}
