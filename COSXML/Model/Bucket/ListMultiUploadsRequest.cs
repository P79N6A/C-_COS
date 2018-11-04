using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;

namespace COSXML.Model.Bucket
{
    public sealed class ListMultiUploadsRequest : BucketRequest
    {
        public ListMultiUploadsRequest(string bucket)
            : base(bucket)
        {
            this.bucket = bucket;
            this.method = CosRequestMethod.GET;
            this.queryParameters.Add("uploads", null);
        }

        public void SetDelimiter(string delimiter)
        {
            if (delimiter != null)
            {
                AddQueryParameter("delimiter", delimiter);
            }
        }

        public void SetEncodingType(string encodingType)
        {
            if (encodingType != null)
            {
                AddQueryParameter("Encoding-type", encodingType);
            }
        }

        public void SetKeyMarker(string keyMarker)
        {
            if (keyMarker != null)
            {
                AddQueryParameter("key-marker", keyMarker);
            }
        }

        public void SetMaxUploads(string maxUploads)
        {
            if (maxUploads != null)
            {
                AddQueryParameter("max-uploads", maxUploads);
            }
        }

        public void SetPrefix(string prefix)
        {
            if (prefix != null)
            {
                AddQueryParameter("Prefix", prefix);
            }
        }

        public void SetUploadIdMarker(String uploadIdMarker)
        {
            if (uploadIdMarker != null)
            {
                AddQueryParameter("upload-id-marker", uploadIdMarker);
            }
        }
    }
}
