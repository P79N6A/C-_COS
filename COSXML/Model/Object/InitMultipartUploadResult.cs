using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;

namespace COSXML.Model.Object
{
    public sealed class InitMultipartUploadResult : CosResult
    {
        public InitiateMultipartUpload initMultipartUpload;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (initMultipartUpload == null ? "" : "\n" + initMultipartUpload.GetInfo());
        }
    }
}
