using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using COSXML.Network;
using COSXML.Model;
using COSXML.Common;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/6/2018 8:52:29 PM
* bradyxiao
*/
namespace COSXML.Network
{
    /// <summary>
    /// input: CosRequest; output: CosResponse
    /// </summary>
    public sealed class HttpClient
    {

        private HttpClientConfig config;

        public HttpClient(HttpClientConfig config)
        {
            if (config != null)
            {
                this.config = config;
            }
            else
            {
                this.config = new HttpClientConfig.Builder().Build();
            }

            // init grobal httpwebreqeust
            CommandTask.Init(this.config);
        }

        public void excute(CosRequest cosRequest, CosResult cosResult)
        {
            Request request = CreateRequest(cosRequest);
            Response response = new Response();
            response.Body = cosResult.GetResponseBody();
            CommandTask.excute(request, response, config);
            cosResult.httpCode = response.Code;
            cosResult.httpMessage = response.Message;
            cosResult.responseHeaders = response.Headers;
        }

        private Request CreateRequest(CosRequest cosRequest)
        {
            Request request = new Request();
            request.Method = cosRequest.Method;
            request.IsHttps = cosRequest.IsHttps;
            request.SetHttpUrl(CreateUrl(cosRequest));
            Dictionary<string, string> headers = cosRequest.GetRequestHeaders();
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> pair in headers)
                {
                    request.AddHeader(pair.Key, pair.Value);
                }
            }

            request.Body = cosRequest.GetRequestBody();
            return request;
        }

        private HttpUrl CreateUrl(CosRequest cosRequest)
        {
            HttpUrl httpUrl = new HttpUrl();
            httpUrl.Scheme(cosRequest.IsHttps ? "https" : "http");
            httpUrl.Host(cosRequest.GetHost());
            httpUrl.SetPath(cosRequest.RequestPath);
            httpUrl.SetQueryParamters(cosRequest.GetRequestParamters());
            return httpUrl;
        }

        private bool CheckHasSign(CosRequest cosRequest)
        {
            if (cosRequest.GetRequestHeaders().ContainsKey(CosRequestHeaderKey.AUTHORIZAIION))
            {
                return true;
            }
            
            return false;
        }
      
    }
    
}
