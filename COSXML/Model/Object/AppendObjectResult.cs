using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COSXML.Model.Object
{
    public sealed class AppendObjectResult : CosResult
    {
        private string contentSHA1;
        private string nextAppendPosition;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }
    }
}
