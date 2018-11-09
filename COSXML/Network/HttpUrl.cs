using System;
using System.Collections.Generic;

using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/6/2018 11:37:45 AM
* bradyxiao
*/
namespace COSXML.Network
{
    /**
     * //最基本的划分
        [scheme:]scheme-specific-part[#fragment]  
        //对scheme-specific-part进一步划分
        [scheme:][//authority][path][?query][#fragment]  
        //对authority再次划分, 这是最细分的结构
        [scheme:][//host:port][path][?query][#fragment]
     */
    public sealed class HttpUrl
    {

        private string scheme;

        private string userName;

        private string userPwd;

        private string host;

        private int port = -1;

        private string path = "/";

        private string queryString;

        private string fragment;

        public void Scheme(string scheme)
        {
            if (scheme == null) throw new ArgumentNullException("scheme == null");
            if (scheme.Equals("http", StringComparison.OrdinalIgnoreCase))
            {
                this.scheme = "http";
            }
            else if (scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
            {
                this.scheme = "https";
            }
            else
            {
                throw new ArgumentException("unexpected scheme: " + scheme);
            }
        }

        public void UserName(string userName)
        {
            if (userName == null) throw new ArgumentNullException("userName == null");
            this.userName = userName;
        }

        public void UserPassword(string userPwd)
        {
            this.userPwd = userPwd;
        }

        public void Host(string host)
        {
            if (host == null) throw new ArgumentNullException("host == null");
            this.host = host;
        }

        public void Port(int port)
        {
            if (port <= 0 || port >= 65535) throw new ArgumentException("unexpected port: " + port);
            this.port = port;
        }

        public void SetPath(string path)
        {
            if (path != null)
            {
                this.path = path; // need url encode
            }
           
        }

        public void SetQueryParamters(Dictionary<string, string> queryParameters)
        {
            if (queryParameters != null)
            {
                StringBuilder query = new StringBuilder();
                foreach (KeyValuePair<string, string> pair in queryParameters)
                {
                    query.Append(pair.Key);
                    if (pair.Value != null)
                    {
                        query.Append('=').Append(pair.Value);
                    }
                    query.Append('&');
                }
                queryString = query.ToString();
                if (queryString.EndsWith("&"))
                {
                    queryString = queryString.Remove(queryString.Length - 1);
                }
            }
        }

        public void SetFragment(string fragment)
        {
            this.fragment = fragment;
        }

        public override string ToString()
        {

            if (scheme == null) throw new ArgumentNullException("scheme == null");
            if (host == null) throw new ArgumentNullException("host == null");

            StringBuilder url = new StringBuilder();

            url.Append(scheme)
                .Append("://");

            if (userName != String.Empty || userPwd != String.Empty)
            {
                url.Append(userName);
                if (userPwd != String.Empty)
                {
                    url.Append(':')
                        .Append(userPwd);
                }
                url.Append('@');
            }

            if (host.IndexOf(':') != -1)
            {
                url.Append('[')
                    .Append(host)
                    .Append(']');
            }
            else
            {
                url.Append(host);
            }

            int effectivePort = EffecivePort();
            if (effectivePort != DefaultPort(scheme))
            {
                url.Append(':')
                    .Append(effectivePort);
            }

            url.Append(path);

            if (queryString != null)
            {
                url.Append('?');
                url.Append(queryString);
            }

            if (fragment != null)
            {
                url.Append('#')
                    .Append(fragment);
            }

            return url.ToString();

        }

        public int EffecivePort()
        {
            return port != -1 ? port : DefaultPort(scheme);
        }

        private int DefaultPort(string scheme)
        {
            if (scheme.Equals("http", StringComparison.OrdinalIgnoreCase))
            {
                return 80;
            }
            else if (scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
            {
                return 443;
            }
            else
            {
                return -1;
            }
        }

        private int DelimiterOffset(string input, int pos, int limit, char delimiter)
        {
            for (int i = pos; i < limit; i++)
            {
                if (input[i] == delimiter) return i;
            }
            return limit;
        }

        private int DelimiterOffset(string input, int pos, int limit, string delimiters)
        {
            for (int i = pos; i < limit; i++)
            {
                if (delimiters.IndexOf(input[i]) != -1) return i;
            }
            return limit;
        }

        private void PathSegmentToString(StringBuilder outPut, List<string> pathSegments)
        {
            foreach (string path in pathSegments)
            {
                outPut.Append('/').Append(path);
            }
        }

        private void NamesAndValuesToQueryString(StringBuilder outPut, List<string> namesAndValues)
        {
            for (int i = 0, size = namesAndValues.Count; i < size; i += 2)
            {
                string name = namesAndValues[i];
                string value = namesAndValues[i + 1];
                if (i > 0) outPut.Append('&');
                outPut.Append(name);
                if (value != null)
                {
                    outPut.Append('=');
                    outPut.Append(value);
                }
            }
        }
    }

}
