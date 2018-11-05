using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
using COSXML.Utils;
using COSXML.Mdel.Tag;

namespace COSXML.Model.Object
{
    public sealed class InitMultipartUploadRequest : ObjectRequest
    {
        public InitMultipartUploadRequest(string bucket, string key)
            : base(bucket, key)
        {
            this.method = CosRequestMethod.POST;
            this.queryParameters.Add("uploads", null);
        }

        public void SetCacheControl(string cacheControl)
        {
            if (cacheControl != null)
            {
                AddRequestHeader(CosRequestHeaderKey.CACHE_CONTROL, cacheControl);
            }
        }

        public void SetContentDisposition(string contentDisposition)
        {
            if (contentDisposition != null)
            {
                AddRequestHeader(CosRequestHeaderKey.CONTENT_DISPOSITION, contentDisposition);
            }
        }

        public void SetContentEncoding(string contentEncoding)
        {
            if (contentEncoding != null)
            {
                AddRequestHeader(CosRequestHeaderKey.CONTENT_ENCODING, contentEncoding);
            }
        }

        public void SetExpires(string expires)
        {
            if (expires != null)
            {
                AddRequestHeader(CosRequestHeaderKey.EXPIRES, expires);
            }
        }


        public void SetCosACL(string cosACL)
        {
            if (cosACL != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_ACL, cosACL);
            }
        }

        public void SetCosACL(CosACL cosACL)
        {
            AddRequestHeader(CosRequestHeaderKey.X_COS_ACL, EnumUtils.GetValue(cosACL));
        }

        public void setXCosGrantRead(GrantAccount grantAccount)
        {
            if (grantAccount != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_GRANT_READ, grantAccount.GetGrantAccounts());
            }
        }

        public void setXCosGrantWrite(GrantAccount grantAccount)
        {
            if (grantAccount != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_GRANT_WRITE, grantAccount.GetGrantAccounts());
            }
        }

        public void setXCosReadWrite(GrantAccount grantAccount)
        {
            if (grantAccount != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_GRANT_FULL_CONTROL, grantAccount.GetGrantAccounts());
            }
        }
    }
}
