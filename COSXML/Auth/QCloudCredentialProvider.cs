using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Utils;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/9/2018 12:16:20 PM
* bradyxiao
*/
namespace COSXML.Auth
{

    public abstract class QCloudCredentialProvider
    {
        public abstract QCloudCredentials GetQCloudCredentials();

        public virtual void Refresh() { }
    }

    /// <summary>
    /// 通过 云 api
    /// </summary>
    public class DefaultQCloudCredentialProvider : QCloudCredentialProvider
    {
        private string secretId;

        private string secretKey;

        private string keyTime;

        public DefaultQCloudCredentialProvider(string secretId, string secretKey, long keyDuration)
            : this(secretId, secretKey, TimeUtils.GetCurrentTime(TimeUnit.SECONDS), keyDuration)
        {}

        public DefaultQCloudCredentialProvider(string secretId, string secretKey, long keyStartTime, long keyDuration)
        {
            this.secretId = secretId;
            this.secretKey = secretKey;
            long keyEndTime = keyStartTime + keyDuration;
            this.keyTime = String.Format("{0};{1}", keyStartTime, keyEndTime);
        }

        public override QCloudCredentials GetQCloudCredentials()
        {
            if (secretId == null) throw new ArgumentNullException("secretId == null");
            if (secretKey == null) throw new ArgumentNullException("secretKey == null");
            if (keyTime == null) throw new ArgumentNullException("keyTime == null");
            return new QCloudCredentials(secretId, secretKey, keyTime);
        }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 通过 临时密钥
    /// </summary>
    public class DefaultSessionQCloudCredentialProvider : QCloudCredentialProvider
    {
        public DefaultSessionQCloudCredentialProvider() { }

        public override QCloudCredentials GetQCloudCredentials()
        {
            string secretId = "";
            string secretKey = "";
            string token = "";
            long keyStartTime = TimeUtils.GetCurrentTime(TimeUnit.SECONDS);
            long keyEndTime = 0L;
            string keyTime = String.Format("{0};{1}", keyStartTime, keyEndTime);
            return new SessionQCloudCredentials(secretId, secretKey, token, keyTime);
        }

        public override void Refresh()
        {
            base.Refresh();
        }
    }
}
