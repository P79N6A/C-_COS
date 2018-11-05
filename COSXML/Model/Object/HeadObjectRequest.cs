using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;

namespace COSXML.Model.Object
{
    public sealed class HeadObjectRequest : ObjectRequest
    {
        public HeadObjectRequest(string bucket, string key)
            : base(bucket, key)
        {
            this.method = CosRequestMethod.HEAD;
        }

        public void SetVersionId(string versionId)
        {
            if (versionId != null)
            {
                AddQueryParameter(CosRequestHeaderKey.VERSION_ID, versionId);
            }
        }

        public void SetIfModifiedSince(string ifModifiedSince)
        {
            if (ifModifiedSince != null)
            {
                AddRequestHeader(CosRequestHeaderKey.IF_MODIFIED_SINCE, ifModifiedSince);
            }
        }

    }
}
