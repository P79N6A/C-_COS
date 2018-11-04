using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
using COSXML.CosException;

namespace COSXML.Model.Object
{
    public sealed class AbortMultiUploadRequest : ObjectRequest
    {
        private string uploadId;

        public AbortMultiUploadRequest(string bucket, string cosPath, string uploadId) : base(bucket, cosPath)
        {
            this.uploadId = uploadId;
            this.method = CosRequestMethod.DELETE;
        }

        public void SetUploadId(string uploadId)
        {
            this.uploadId = uploadId;
        }

        public string GetUploadId()
        {
            return uploadId;
        }

        public override void CheckParameters()
        {
            base.CheckParameters();
            if (uploadId == null)
            {
                throw new CosClientException((int)CosClientError.INVALIDARGUMENT, "uploadId is null");
            }
        }

        protected override void InternalUpdateQueryParameters()
        {
            this.queryParameters.Add("uploadId", uploadId);
        }
    }
}
