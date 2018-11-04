using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Bucket
{
    public sealed class GetBucketLocationResult : CosResult
    {
        public LocationConstraint locationConstraint;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (locationConstraint == null ? "" : "\n" + locationConstraint.GetInfo());
        }
    }
}
