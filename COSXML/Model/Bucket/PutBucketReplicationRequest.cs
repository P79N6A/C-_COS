using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
using COSXML.Model.Tag;

namespace COSXML.Model.Bucket
{
    public sealed class PutBucketReplicationRequest : BucketRequest
    {
        private ReplicationConfiguration replicationConfiguration;

        public PutBucketReplicationRequest(string bucket)
            : base(bucket)
        {
            this.method = CosRequestMethod.PUT;
            this.queryParameters.Add("replication", null);
            replicationConfiguration = new ReplicationConfiguration();
            replicationConfiguration.rules = new List<ReplicationConfiguration.Rule>();
        }

        public override Network.RequestBody GetRequestBody()
        {
            return base.GetRequestBody();
        }

        public void setReplicationConfigurationWithRole(string ownerUin, string subUin)
        {
            if (ownerUin != null && subUin != null)
            {
                string role = "qcs::cam::uin/" + ownerUin + ":uin/" + subUin;
                replicationConfiguration.role = role;
            }
        }

        public void setReplicationConfigurationWithRule(RuleStruct ruleStruct)
        {
            if (ruleStruct != null)
            {
                ReplicationConfiguration.Rule rule = new ReplicationConfiguration.Rule();
                rule.id = ruleStruct.id;
                rule.status = ruleStruct.isEnable ? "Enabled" : "Disabled";
                rule.prefix = ruleStruct.prefix;
                ReplicationConfiguration.Destination destination = new ReplicationConfiguration.Destination();
                destination.storageClass = ruleStruct.storageClass;
                StringBuilder bucket = new StringBuilder();
                bucket.Append("qcs:id/0:cos:").Append(ruleStruct.region).Append(":appid/")
                        .Append(ruleStruct.appid).Append(":").Append(ruleStruct.bucket);
                destination.bucket = bucket.ToString();
                rule.destination = destination;
                replicationConfiguration.rules.Add(rule);
            }
        }

    }

    public sealed class RuleStruct
    {
        public string appid;
        public string region;
        public string bucket;
        public string storageClass;
        public string id;
        public string prefix;
        public bool isEnable;
    }

}
