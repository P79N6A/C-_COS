using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using COSXML.Log;
using System.Reflection;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/7/2018 9:34:42 AM
* bradyxiao
*/
namespace COSXML.Network
{
    /// <summary>
    /// network request and response
    /// type1: command request
    /// type2: upload file
    /// type3: download file
    /// difference: body progress
    /// </summary>
    public sealed class CommandTask
    {
        public const string TAG = "CommandTask";

        /// <summary>
        /// init connectionLimit and statueCode = 100 action
        /// </summary>
        /// <param name="config"></param>
        public static void Init(HttpClientConfig config)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = config.ConnectionLimit;
        }

        /// <summary>
        /// sync excute
        /// </summary>
        /// <param name="request"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static void excute(Request request, Response response, HttpClientConfig config)
        {
            //step1: create HttpWebRequest by request.url
            HttpWebRequest httpWebRequest = HttpWebRequest.Create(request.Url.ToString()) as HttpWebRequest;
           
            // handler request
            HandleHttpWebRequest(httpWebRequest, request, config);

            //final: get response
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            //print log
            printReqeustInfo(httpWebRequest);

            //handle response
            HandleHttpWebResponse(httpWebResponse, response);
        }

        /// <summary>
        /// handle request
        /// </summary>
        /// <param name="httpWebRequest"></param>
        /// <param name="request"></param>
        /// <param name="config"></param>
        private static void HandleHttpWebRequest(HttpWebRequest httpWebRequest, Request request, HttpClientConfig config)
        {
            // set connect timeout
            httpWebRequest.Timeout = config.ConnectionTimeoutMs;
            //set read write timeout
            httpWebRequest.ReadWriteTimeout = config.ReadWriteTimeoutMs;

            // set request method
            httpWebRequest.Method = request.Method.ToUpperInvariant();
            // set user-agent
            httpWebRequest.UserAgent = config.UserAgnet;
            // set allow auto redirect
            httpWebRequest.AllowAutoRedirect = config.AllowAutoRedirect;

            // notice: it is not allowed to set common headers with the WebHeaderCollection.Accept
            // such as: Connection,Content-Length,Content-Type,Date,Expect. Host,If-Modified-Since,Range, Referer,Transfer-Encoding,User-Agent,Proxy-Connection
            //step2: set header and connection properity by request.heders
            for (int i = 0, count = request.Headers.Size(); i < count; i++)
            {
                HttpHeaderHandle.AddHeader(httpWebRequest.Headers, request.Headers.Name(i), request.Headers.Value(i));
            }

            //step3: set proxy, default proxy = null, improte performation
            SetRequestProxy(httpWebRequest, config);

            //step4: https, default all true for "*.myqcloud.com"
            if (request.IsHttps)
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationCertificate);
            }

            //setp5: send request content: body
            if (request.Body != null)
            {
                request.Body.OnWrite(httpWebRequest.GetRequestStream());
            }
        }

        /// <summary>
        /// handle response
        /// </summary>
        /// <param name="httpWebResponse"></param>
        /// <param name="response"></param>
        private static void HandleHttpWebResponse(HttpWebResponse httpWebResponse, Response response)
        {
            response.Code = (int)httpWebResponse.StatusCode;
            response.Message = httpWebResponse.StatusDescription;

            WebHeaderCollection headers = httpWebResponse.Headers;
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
                response.Headers = result;
            }

            response.ContentLength = httpWebResponse.ContentLength;

            if (response.Body != null)
            {
                response.Body.ContentLength = httpWebResponse.ContentLength;
                response.Body.ContentType = httpWebResponse.ContentType;
                response.Body.OnRead(httpWebResponse.GetResponseStream());
            }

            // print log
            printResponseInfo(httpWebResponse);

            httpWebResponse.Close(); // close 
        }


        /// <summary>
        /// set proxy
        /// </summary>
        /// <param name="httpWebRequest"></param>
        /// <param name="config"></param>
        private static void SetRequestProxy(HttpWebRequest httpWebRequest, HttpClientConfig config)
        {
            httpWebRequest.Proxy = null;

            if (!String.IsNullOrEmpty(config.ProxyHost))
            {
                if (config.ProxyPort < 0)
                {
                    httpWebRequest.Proxy = new WebProxy(config.ProxyHost);
                }
                else
                {
                    httpWebRequest.Proxy = new WebProxy(config.ProxyHost, config.ProxyPort);
                }
                if (!String.IsNullOrEmpty(config.ProxyUserName))
                {
                    httpWebRequest.Proxy.Credentials = String.IsNullOrEmpty(config.ProxyDomain) ?
                        new NetworkCredential(config.ProxyUserName, config.ProxyUserPassword ?? String.Empty) :
                        new NetworkCredential(config.ProxyUserName, config.ProxyUserPassword ?? String.Empty,
                            config.ProxyDomain);
                }
                httpWebRequest.PreAuthenticate = true; // 代理验证
            }
        }

        /// <summary>
        /// check certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        private static bool CheckValidationCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        /// <summary>
        /// print request info
        /// </summary>
        /// <param name="httpWebRequest"></param>
        private static void printReqeustInfo(HttpWebRequest httpWebRequest)
        {
            StringBuilder requestLog = new StringBuilder("--->");
            requestLog.Append(httpWebRequest.Method).Append(' ').Append(httpWebRequest.RequestUri.ToString()).Append('\n');
            int count = httpWebRequest.Headers.Count;
            for (int i = 0; i < count; i++)
            {
                requestLog.Append(httpWebRequest.Headers.GetKey(i)).Append(":").Append(httpWebRequest.Headers.GetValues(i)[0]).Append('\n');
            }
            requestLog.Append("allow auto redirect: " + httpWebRequest.AllowAutoRedirect).Append('\n');
            requestLog.Append("connect timeout: " + httpWebRequest.Timeout).Append('\n');
            requestLog.Append("read write timeout: " + httpWebRequest.ReadWriteTimeout).Append('\n');
            requestLog.Append("proxy: " + (httpWebRequest.Proxy == null ? "null" : ((WebProxy)httpWebRequest.Proxy).Address.ToString()));
            requestLog.Append("<---");
            QLog.D(TAG, requestLog.ToString());
        }

        /// <summary>
        /// print response info
        /// </summary>
        /// <param name="httpWebResponse"></param>
        private static void printResponseInfo(HttpWebResponse httpWebResponse)
        { 
            StringBuilder responseLog = new StringBuilder("--->");
            responseLog.Append(httpWebResponse.Method).Append(' ').Append(httpWebResponse.ResponseUri.ToString()).Append('\n');
            responseLog.Append(httpWebResponse.StatusCode).Append(' ').Append(httpWebResponse.StatusDescription);
            int count = httpWebResponse.Headers.Count;
            for (int i = 0; i < count; i++)
            {
                responseLog.Append(httpWebResponse.Headers.GetKey(i)).Append(":").Append(httpWebResponse.Headers.GetValues(i)[0]).Append('\n');
            }
            responseLog.Append("<---");
            QLog.D(TAG, responseLog.ToString());
        }

    }
    
    internal static class HttpHeaderHandle
    {
        private static MethodInfo addHeaderMethod;
        private static readonly ICollection<PlatformID> monoPlatforms = new List<PlatformID> { PlatformID.MacOSX, PlatformID.Unix };
        private static bool? isMonoPlatform;

        internal static void AddHeader(WebHeaderCollection webHeaderCollection, string key, string value)
        {
            if (isMonoPlatform == null)
            {
                isMonoPlatform = monoPlatforms.Contains(Environment.OSVersion.Platform);
            }
             // HTTP headers should be encoded to iso-8859-1,
            // however it will be encoded automatically by HttpWebRequest in mono.
            if(false == isMonoPlatform)
            {
                // Encode headers for win platforms.
                
            }
            if(addHeaderMethod == null)
            {
                // Specify the internal method name for adding headers
                // mono: AddWithoutValidate
                // win: AddInternal
                var internalMethodName = (isMonoPlatform == true) ? "AddWithoutValidate" : "AddInternal";
                var method =  typeof(WebHeaderCollection).GetMethod(
                    internalMethodName,
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    new Type[] { typeof(string), typeof(string) },
                    null);
                addHeaderMethod = method;
            }

            addHeaderMethod.Invoke(webHeaderCollection, new Object[]{key, value});          
        }

     }
}
