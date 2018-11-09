using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Object
{
    public sealed class ListPartsResult : CosResult
    {
        public ListParts listParts;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }
        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (listParts == null ? "" : "\n" + listParts.GetInfo());
        }

    }
}
