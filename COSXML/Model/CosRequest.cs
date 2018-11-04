using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
using COSXML.Network;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 1:05:09 PM
* bradyxiao
*/
namespace COSXML.Model
{
    /**
     * cos request base class, all cos operator must be extended this.
     * 
     * request method | request path | query parameters
     * request headers
     * request body
     * 
     * special:
     * cos sign;
     */
    public abstract class CosRequest
    {
        protected string method = CosRequestMethod.GET;

        protected string path;

        protected Dictionary<string, string> queryParameters = new Dictionary<string,string>();

        protected Dictionary<string, string> headers = new Dictionary<string,string>();

        protected string appid;

        public string GetRequestMethod() 
        {
            return method;
        }

        public string GetRequestPath() 
        {
            return path;
        }

        public virtual Dictionary<string, string> GetRequestParamters()
        {
            return queryParameters;
        }

        public virtual Dictionary<string, string> GetRequestHeaders()
        {
            return headers;
        }

        public abstract RequestBody GetRequestBody();
        

        /**
        public void SetRequestMethod(string method)
        {
            this.method = method;
        }

        public void SetRequestPath(string path)
        {
            this.path = path;
        }
         */

        public void AddQueryParameter(string key, string value)
        {
            if (key != null)
            {
                if (queryParameters.ContainsKey(key))
                {
                    queryParameters[key] = value;
                }
                else
                {
                    queryParameters.Add(key, value);
                }
            }
        }

        public void AddRequestHeader(string key, string value)
        {
            if (key != null)
            {
                if (headers.ContainsKey(key))
                {
                    headers[key] = value;
                }
                else
                {
                    headers.Add(key, value);
                }
            }
        }

        public abstract string GetHost();


        public void SetAppid(string appid)
        {
            this.appid = appid;
        }

        public abstract void CheckParameters();

    }
}
