using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using COSXML.Log;
using COSXML.Network;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/6/2018 4:39:32 PM
* bradyxiao
*/
namespace Demo.test
{
    class NetworkTest
    {
        public static void testGet(string url)
        {
            
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                //request.ProtocolVersion = HttpVersion.Version10; 
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //StreamReader reader = new StreamReader(response.GetResponseStream());
            //Console.WriteLine(reader.ReadToEnd());
      
            Console.WriteLine((int)response.StatusCode);
            Console.WriteLine(response.StatusDescription);
            WebHeaderCollection headers = response.Headers;
            if (headers != null)
            {
                Dictionary<string, List<string>> result = new Dictionary<string, List<string>>(headers.Count);
                for (int i = 0; i < headers.Count; i++)
                {
                    List<string> values = null;
                    if (headers.GetValues(i) != null)
                    {
                        values = new List<string>();
                        foreach (string value in headers.GetValues(i))
                        {
                            values.Add(value);
                        }
                    }

                    result.Add(headers.GetKey(i), values);
                }
                foreach (KeyValuePair<string, List<string>> pair in result)
                {
                    Console.WriteLine(pair.Key + ": " + pair.Value[0]);
                }
            }
            
            response.Close();
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            QLog.D("XIAO", sender.ToString());
            QLog.D("XIAO", certificate.ToString());
            QLog.D("XIAO", chain.ToString());
            QLog.D("XIAO", errors.ToString());


            if (errors == SslPolicyErrors.None) // 第三方证书有效
                return true;
            return false;
        } 
    }
}
