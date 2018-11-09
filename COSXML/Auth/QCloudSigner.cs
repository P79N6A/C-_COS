using System;
using System.Collections.Generic;
using System.Text;
using COSXML.Network;
using COSXML.Common;
using COSXML.Log;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/9/2018 4:30:34 PM
* bradyxiao
*/
namespace COSXML.Auth
{
    /// <summary>
    /// 签名
    /// </summary>
    public interface QCloudSigner
    {
        void Sign(Request request, QCloudCredentials qcloudCredentials);
    }

    public interface QCloudSignSource
    {
        string Source(Request request);
    }

    public sealed class CosXmlSourceProvider : QCloudSignSource
    {
        private static string TAG = "CosXmlSourceProvider";
        private Dictionary<string, string> parameterKeys;
        
        private Dictionary<string, string> headerKeys;

        private string signTime;

        public CosXmlSourceProvider()
        {
            parameterKeys = new Dictionary<string, string>();
            headerKeys = new Dictionary<string, string>();
        }

        public void AddParameterKey(string parameterKey)
        {
            if (parameterKey != null)
            {
                try
                {
                    parameterKeys.Add(parameterKey, parameterKey.ToLower());
                }
                catch (ArgumentException) 
                {
                    QLog.D(TAG, parameterKey + " has already exist in sign");
                }
            }
        }

        public void AddParameterKeys(List<string> parameterKeys)
        {
            if (parameterKeys != null)
            {
                foreach (string key in parameterKeys)
                {
                    AddParameterKey(key);
                }
            }
        }

        public void AddHeaderKey(string headerKey)
        {
            if(headerKey != null)
            {
                try
                {
                    parameterKeys.Add(headerKey, headerKey.ToLower());
                }
                catch (ArgumentException)
                {
                    QLog.D(TAG, headerKey + " has already exist in sign");
                }
            }
        }

        public void AddHeaderKeys(List<string> headerKeys)
        {
            if (headerKeys != null)
            {
                foreach (string key in headerKeys)
                {
                    AddHeaderKey(key);
                }
            }
        }

        public void SetSignTime(string signTime)
        {
            if(signTime != null)
            {
                this.signTime = signTime;
            }
        }

        public void SetSignTime(long signStartTime, long duration)
        {
            this.signTime = String.Format("{0};{1}",signStartTime, signStartTime + duration);
        }

        public string Source(Request request)
        {
            StringBuilder formatString = new StringBuilder();
            formatString.Append(request.Method.ToLower()).Append('\n');
            formatString.Append(request.Url.GetPath()).Append('\n');
            formatString.Append(
            return null;
        }

        public void sort(List<string> list)
        {
            if(list != null)
            {
                list.Sort(SortList);
            }
        }

        public int SortList(string first, string second)
        {
            return String.Compare(first, second);
        }
    }


    public sealed class CosXmlSigner : QCloudSigner
    {
        public CosXmlSigner() { }

        public void Sign(Request request, QCloudCredentials qcloudCredentials)
        {
            if (request == null) throw new ArgumentNullException("Request == null");
            if (qcloudCredentials == null) throw new ArgumentNullException("QCloudCredentials == null");
            StringBuilder signBuilder = new StringBuilder();

            signBuilder.Append(CosAuthConstants.Q_SIGN_ALGORITHM).Append('=').Append(CosAuthConstants.SHA1).Append('&')
                .Append(CosAuthConstants.Q_AK).Append('=').Append(qcloudCredentials.SecretId).Append('&')
                .Append(CosAuthConstants.Q_SIGN_TIME).Append('=').Append("sign time").Append('&')
                .Append(CosAuthConstants.Q_KEY_TIME).Append('=').Append(qcloudCredentials.KeyTime).Append('&')
                .Append(CosAuthConstants.Q_HEADER_LIST).Append('=').Append("sign time").Append('&')
                .Append(CosAuthConstants.Q_URL_PARAM_LIST).Append('=').Append("sign time").Append('&')
                .Append(CosAuthConstants.Q_SIGNATURE).Append('=').Append("sign");
            request.AddHeader(CosRequestHeaderKey.AUTHORIZAIION, signBuilder.ToString());
            if(qcloudCredentials is SessionQCloudCredentials)
            {
                request.AddHeader(CosRequestHeaderKey.COS_SESSION_TOKEN,((SessionQCloudCredentials)qcloudCredentials).Token);
            }
        }
    }

    public sealed class CosAuthConstants
    {
        private CosAuthConstants() { }

        public static string Q_SIGN_ALGORITHM = "q-sign-algorithm";

        public static string Q_AK = "q-ak";

        public static string Q_SIGN_TIME = "q-sign-time";

        public static string Q_KEY_TIME = "q-key-time";

        public static string Q_HEADER_LIST = "q-header-list";

        public static string Q_URL_PARAM_LIST = "q-url-param-list";

        public static string Q_SIGNATURE = "q-signature";

        public static string SHA1 = "sha1";
    }
}
