using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Bucket
{
    public sealed class GetBucketReplicationResult : CosResult
    {
        public ReplicationConfiguration replicationConfiguration;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (replicationConfiguration == null ? "" : "\n" + replicationConfiguration.GetInfo()); 
        }
    }
}
