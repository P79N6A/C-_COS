﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;

namespace COSXML.Model.Object
{
    public sealed class DeleteObjectRequest : ObjectRequest
    {
        public DeleteObjectRequest(string bucket, string key)
            : base(bucket, key)
        {
            this.method = CosRequestMethod.DELETE;
        }

        public void SetVersionId(string versionId)
        {
            if (versionId != null)
            {
                AddQueryParameter(CosRequestHeaderKey.VERSION_ID, versionId);
            }
        }
    }
}
