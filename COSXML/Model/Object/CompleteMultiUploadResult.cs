using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Object
{
    public sealed class CompleteMultiUploadResult : CosResult
    {
        public CompleteMultipartUploadResult completeMultipartUpload;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (completeMultipartUpload == null ? "" : "\n" + completeMultipartUpload.GetInfo());
        }
    }
}
