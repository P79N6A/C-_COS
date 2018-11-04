using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.CosException;
using COSXML.Common;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 8:03:59 PM
* bradyxiao
*/
namespace COSXML.Model.Bucket
{
    /**
     * Buceket request for cos
     * base class
     * provider bucket,region property
     */
    public abstract class BucketRequest : CosRequest
    {
        protected string bucket;

        protected string region;

        public BucketRequest(string bucket)
        {
            this.bucket = bucket;
            this.path = "/";
        }

        public void SetBucket(string bucket)
        {
            this.bucket = bucket;
        }

        public void SetRegion(string region)
        {
            this.region = region;
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
        }
    }
}
