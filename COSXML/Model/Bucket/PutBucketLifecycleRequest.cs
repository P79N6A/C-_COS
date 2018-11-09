using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Common;
using COSXML.Model.Tag;

namespace COSXML.Model.Bucket
{
    public sealed class PutBucketLifecycleRequest : BucketRequest
    {
        private LifecycleConfiguration lifecycleConfiguration;

        public PutBucketLifecycleRequest(string bucket)
            : base(bucket)
        {
            this.method = CosRequestMethod.PUT;
            this.queryParameters.Add("lifecycle", null);
            lifecycleConfiguration = new LifecycleConfiguration();
            lifecycleConfiguration.rules = new List<LifecycleConfiguration.Rule>();
        }

        public override Network.RequestBody GetRequestBody()
        {
            return base.GetRequestBody();
        }

        public void SetRule(LifecycleConfiguration.Rule rule)
        {
            if(rule != null)
            {
                lifecycleConfiguration.rules.Add(rule);
            }
        }

        public void SetRules(List<LifecycleConfiguration.Rule> rules)
        {
            if (rules != null)
            {
                lifecycleConfiguration.rules.AddRange(rules);
            }
        }
    }
}
