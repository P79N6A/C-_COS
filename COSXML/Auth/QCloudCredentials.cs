using System;
using System.Collections.Generic;
using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/9/2018 12:09:40 PM
* bradyxiao
*/
namespace COSXML.Auth
{
    /// <summary>
    /// cos 业务认证 key and id
    /// </summary>
    public class QCloudCredentials
    {
        public QCloudCredentials(string secretId, string secretKey, string keyTime)
        {
            this.SecretId = secretId;
            this.SecretKey = secretKey;
            this.KeyTime = keyTime;
        }

        public QCloudCredentials(string secretId, string secretKey, long keyStartTime, long keyEndTime)
            : this(secretId, secretKey, String.Format("{0};{1}", keyStartTime, keyEndTime))
        { }

        public string SecretId
        { get; private set; }

        public string SecretKey
        { get; private set; }

        public string KeyTime
        { get; private set; }

    }

    public class SessionQCloudCredentials : QCloudCredentials
    {
        public SessionQCloudCredentials(string secretId, string secretKey, string token, string keyTime) :
            base(secretId, secretKey, keyTime)
        {
            this.Token = token;
            
        }

        public SessionQCloudCredentials(string secretId, string secretKey, string token, long keyStartTime, long keyEndTime)
            :base(secretId, secretKey, keyStartTime, keyEndTime)
        {
            this.Token = token;
        }

        public string Token
        { get; private set; }
    }
}
