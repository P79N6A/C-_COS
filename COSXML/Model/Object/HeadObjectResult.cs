using System;
using System.Collections.Generic;

using System.Text;

namespace COSXML.Model.Object
{
    public sealed class HeadObjectResult : CosResult
    {
        public string cosObjectType;
        public string cosStorageClass;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }
    }
}
