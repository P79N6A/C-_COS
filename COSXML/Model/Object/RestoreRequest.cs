using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;
using COSXML.Common;

namespace COSXML.Model.Object
{
    public sealed class RestoreRequest : ObjectRequest
    {
        private RestoreConfigure restoreConfigure;
        public RestoreRequest(string bucket, string key)
            : base(bucket, key)
        {
            this.method = CosRequestMethod.PUT;
            restoreConfigure = new RestoreConfigure();
            this.queryParameters.Add("restore", null);
            restoreConfigure.casJobParameters = new RestoreConfigure.CASJobParameters();
        }

        public void SetExpireDays(int days)
        {
            if (days < 0) days = 0;
            restoreConfigure.days = days;
        }

        public void SetTier(RestoreConfigure.Tier tier)
        {
            restoreConfigure.casJobParameters.tier = tier;
        }

        public override Network.RequestBody GetRequestBody()
        {
            return base.GetRequestBody();
        }
    }
}
