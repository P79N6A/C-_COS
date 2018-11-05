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

        public ObjectRequest(string bucket, string key)
        {
            this.bucket = bucket;
            if (key != null && !key.StartsWith("/"))
            {
                this.path = "/" + key;
            }
            else 
            {
                this.path = key;
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

        public virtual void SetCosPath(string key)
        {
            if (key != null && !key.StartsWith("/"))
            {
                this.path = "/" + key;
            }
            else
            {
                this.path = key;
            }
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
                throw new CosClientException((int)CosClientError.INVALID_ARGUMENT, "bucket is null");
            }
            if (region == null)
            {
                throw new CosClientException((int)CosClientError.INVALID_ARGUMENT, "region is null");
            }
            if (path == null)
            {
                throw new CosClientException((int)CosClientError.INVALID_ARGUMENT, "cosPath is null");
            }

        }

        protected virtual void InternalUpdateQueryParameters() 
        { 
        }

        protected virtual void InteranlUpdateHeaders() { }

        public override Dictionary<string, string> GetRequestParamters()
        {
            InternalUpdateQueryParameters();
            return base.GetRequestParamters();
        }

        public override Dictionary<string, string> GetRequestHeaders()
        {
            InteranlUpdateHeaders();
            return base.GetRequestHeaders();
        }


    }
}
