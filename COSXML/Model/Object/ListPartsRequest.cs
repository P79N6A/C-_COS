using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
using COSXML.CosException;

namespace COSXML.Model.Object
{
    public sealed class ListPartsRequest : ObjectRequest
    {
        private string uploadId;

        public ListPartsRequest(string bucket, string key, string uploadId)
            : base(bucket, key)
        {
            this.method = CosRequestMethod.POST;
            this.uploadId = uploadId;
        }

        public void SetUploadId(string uploadId)
        {
            this.uploadId = uploadId;
        }

        public void SetMaxParts(int maxParts)
        {
            AddQueryParameter(CosRequestHeaderKey.MAX_PARTS, maxParts.ToString());
        }

        public void SetPartNumberMarker(int partNumberMarker)
        {
           AddQueryParameter(CosRequestHeaderKey.PART_NUMBER_MARKER, partNumberMarker.ToString());
        }

        public void SetEncodingType(string encodingType)
        {
            if (encodingType != null)
            {
                AddQueryParameter(CosRequestHeaderKey.ENCODING_TYPE, encodingType);
            }  
        }

        public override void CheckParameters()
        {
            base.CheckParameters();
            if (uploadId == null)
            {
                throw new CosClientException((int)CosClientError.INVALID_ARGUMENT, "uploadId is null");
            }
        }

        protected override void InternalUpdateQueryParameters()
        {
            queryParameters.Add("uploadId", uploadId);
        }


    }
}
