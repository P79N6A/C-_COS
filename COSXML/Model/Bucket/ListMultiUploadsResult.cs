using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Tag
{
    public sealed class ListMultiUploadsResult : CosResult
    {
        public ListMultipartUploads listMultipartUploads;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (listMultipartUploads == null ? "" : "\n" + listMultipartUploads.GetInfo());
        }
    }
}
