using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.CosException;
using COSXML.Common;

namespace COSXML.Model.Object
{
    public abstract class ObjectRequest : CosRequest
    {
        protected string bucket;

        protected string region;

        public ObjectRequest(string bucket, string cosPath)
        {
            this.bucket = bucket;
            if (cosPath != null && !cosPath.StartsWith("/"))
            {
                this.path = "/" + cosPath;
            }
            else 
            {
                this.path = cosPath;
            }
        }

        public void SetBucket(string bucket)
        {
            this.bucket = bucket;
        }

        public void SetRegion(string region)
        {
            this.region = region;
        }

        public void SetCosPath(string cosPath)
        {
            this.path = cosPath;
        }

        public override Network.RequestBody GetRequestBody()
        {
            return null;
        }

        public override string GetHost()
        {
            StringBuilder hostBuilder = new StringBuilder();
            if (bucket.EndsWith("-" + appid))
            {
                hostBuilder.Append(bucket);
            }
            else
            {
                hostBuilder.Append(appid).Append("-")
                    .Append(bucket);
            }
            hostBuilder.Append(".cos.")
                .Append(region)
                .Append(".myqcloud.com");
            return hostBuilder.ToString();
        }

        public override void CheckParameters()
        {
            if (bucket == null)
            {
                throw new CosClientException((int)CosClientError.INVALIDARGUMENT, "bucket is null");
            }
            if (region == null)
            {
                throw new CosClientException((int)CosClientError.INVALIDARGUMENT, "region is null");
            }
            if (path == null)
            {
                throw new CosClientException((int)CosClientError.INVALIDARGUMENT, "cosPath is null");
            }

        }

        protected virtual void InternalUpdateQueryParameters() 
        { 
        }

        public override Dictionary<string, string> GetRequestParamters()
        {
            InternalUpdateQueryParameters();
            return base.GetRequestParamters();
        }


    }
}
