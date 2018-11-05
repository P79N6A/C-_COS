using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Object
{
    public sealed class CopyObjectResult : CosResult
    {
        public CopyObject copyObject;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (copyObject == null ? "" : "\n" + copyObject.GetInfo());
        }

    }
}
