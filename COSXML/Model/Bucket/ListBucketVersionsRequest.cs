using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;

namespace COSXML.Model.Bucket
{
    public sealed class ListBucketVersionsRequest : BucketRequest
    {
        public ListBucketVersionsRequest(string bucket)
            : base(bucket)
        {
            this.method = CosRequestMethod.GET;
            this.queryParameters.Add("versions", null);
        }

        public void SetPrefix(string prefix)
        {
            if (prefix != null)
            {
                AddQueryParameter("prefix", prefix);
            }
        }

        public void SetKeyMarker(string keyMarker)
        {
            if (keyMarker != null)
            {
                AddQueryParameter("key-marker", keyMarker);
            }
        }

        public void SetVersionIdMarker(string versionIdMarker)
        {
            if (versionIdMarker != null)
            {
                AddQueryParameter("version-id-marker", versionIdMarker);
            }
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
                AddQueryParameter("encoding-type", encodingType);
            }
        }

        public void SetMaxKeys(string maxKeys)
        {
            if (maxKeys != null)
            {
                AddQueryParameter("max-keys", maxKeys);
            }
            else
            {
                AddQueryParameter("max-keys", "1000");
            }
        }
    }
}
