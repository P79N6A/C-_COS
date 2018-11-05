using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
using COSXML.CosException;

namespace COSXML.Model.Object
{
    public sealed class OptionObjectRequest : ObjectRequest
    {
        private string origin;
        private string accessControlMethod;

        public OptionObjectRequest(string bucket, string key, string origin, string accessControlMethod)
            : base(bucket, key)
        {
            this.method = CosRequestMethod.OPTIONS;
            this.origin = origin;
            if (accessControlMethod != null)
            {
                this.accessControlMethod = accessControlMethod.ToUpper();
            }
        }

        public void SetOrigin(string origin)
        {
            this.origin = origin;
        }

        public void SetAccessControlMethod(string accessControlMethod)
        {
            this.accessControlMethod = accessControlMethod;
        }

        public void SetAccessControlHeaders(List<string> accessControlHeaders)
        {
            if (accessControlHeaders != null)
            {
                StringBuilder headers = new StringBuilder();
                foreach (string accessControlHeader in accessControlHeaders)
                {
                    headers.Append(accessControlHeader).Append(",");
                }
                if (accessControlHeaders.Count > 0)
                {
                    headers.Remove(headers.Length - 1, 1);
                    AddRequestHeader(CosRequestHeaderKey.ACCESS_CONTROL_REQUEST_HEADERS, headers.ToString());
                }
            }
        }

        public override void CheckParameters()
        {
            base.CheckParameters();
            if(origin == null)
            {
                throw new CosClientException((int)CosClientError.INVALID_ARGUMENT, "origin is null");
            }
            if (accessControlMethod == null)
            {
                throw new CosClientException((int)CosClientError.INVALID_ARGUMENT, "accessControlMethod is null");
            }
        }

        protected override void InteranlUpdateHeaders()
        {
            this.headers.Add(CosRequestHeaderKey.ORIGIN, origin);
            this.headers.Add(CosRequestHeaderKey.ACCESS_CONTROL_REQUEST_METHOD, accessControlMethod);
            base.InteranlUpdateHeaders();
        }
    }
}
