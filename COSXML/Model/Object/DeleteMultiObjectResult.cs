using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Object
{
    public sealed class DeleteMultiObjectResult : CosResult
    {
        public DeleteResult deleteResult;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (deleteResult == null ? "" : deleteResult.GetInfo());
        }
    }
}
