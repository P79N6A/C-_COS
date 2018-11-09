using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Common;
using COSXML.Model.Tag;

namespace COSXML.Model.Bucket
{
    public sealed class PutBucketCORSRequest : BucketRequest
    {
        private CORSConfiguration corsConfiguration;

        public PutBucketCORSRequest(string bucket)
            : base(bucket)
        {
            this.method = CosRequestMethod.PUT;
            this.queryParameters.Add("cors", null);
            corsConfiguration = new CORSConfiguration();
            corsConfiguration.corsRules = new List<CORSConfiguration.CORSRule>();
        }

        public override Network.RequestBody GetRequestBody()
        {
            return base.GetRequestBody();
        }

        public void SetCORSRule(CORSConfiguration.CORSRule corsRule)
        {
            if (corsRule != null)
            {
                corsConfiguration.corsRules.Add(corsRule);
            }
        }

        public void SetCORSRules(List<CORSConfiguration.CORSRule> corsRules)
        {
            if (corsRules != null)
            {
                corsConfiguration.corsRules.AddRange(corsRules);
            }
        }
    }
}
