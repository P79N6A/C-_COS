using System;
using System.Collections.Generic;

using System.Text;

namespace COSXML.Model.Object
{
    public sealed class OptionObjectResult : CosResult
    {
        public string accessControlAllowOrigin;
        public long accessControlMaxAge;
        public List<string> accessControlAllowHeaders;
        public List<string> accessControlAllowMethods;
        public List<string> accessControlAllowExposeHeaders;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo();
        }
    }
}
