using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Object
{
    public sealed class GetObjectACLResult : CosResult
    {
        public AccessControlPolicy accessControlPolicy;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (accessControlPolicy == null ? "" : "\n" + accessControlPolicy.GetInfo());
        }
    }
}
