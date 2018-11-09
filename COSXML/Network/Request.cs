using System;
using System.Collections.Generic;

using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 4:40:14 PM
* bradyxiao
*/
namespace COSXML.Network
{
    public sealed class Request
    {
        private string method;  // post put get delete head, etc.
        private HttpUrl url;  // shceme://host:port/path?query# etc.
        private Headers.Builder headers; // key : value
        private RequestBody body; // file or byte, etc.
        private Object tag; // package tag for request
        private bool isHttps;

        public Request()
        {
            headers = new Headers.Builder();
        }

        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        public bool IsHttps
        {
            get { return isHttps; }
            set { isHttps = value; }
        }

        public void SetHttpUrl(HttpUrl httpUrl)
        {
            if (httpUrl == null) throw new ArgumentNullException("httpUrl == null");
            this.url = httpUrl;
        }

        public HttpUrl Url
        {
            get
            { 
                if (url == null) throw new ArgumentNullException("httpUrl == null"); 
                return url; 
            }
            private set { }
        }

        public Headers Headers
        {
            get { return headers.Build(); }
            private set { }
        }

        public void AddHeader(string name, string value)
        {
            headers.Add(name, value);
        }

        public void SetHeader(string name, string value)
        {
            headers.Set(name, value);
        }

        public RequestBody Body
        {
            get { return body; }
            set { body = value; }
        }

        public Object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Request{method=").Append(method)
                .Append(", url=").Append(url)
                .Append(", tag=").Append(tag)
                .Append('}');
            return str.ToString();
        }

    }
}
