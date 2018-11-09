using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Bucket
{
    public sealed class GetBucketLifecycleResult : CosResult
    {
        public LifecycleConfiguration lifecycleConfiguration;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (lifecycleConfiguration == null ? "" : "\n " + lifecycleConfiguration.GetInfo());
        }
    }
}
