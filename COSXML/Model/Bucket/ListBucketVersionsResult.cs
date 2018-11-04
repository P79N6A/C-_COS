using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Bucket
{
    public sealed class ListBucketVersionsResult :CosResult
    {
        public ListBucketVersions listBucketVersions;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (listBucketVersions == null ? "" : "\n" + listBucketVersions.GetInfo());
        }
    }
}
