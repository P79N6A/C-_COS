using System;
using System.Collections.Generic;

using System.Text;

namespace COSXML.Model.Object
{
    public sealed class UploadPartResult : CosResult
    {
        public string eTag;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }
    }
}
