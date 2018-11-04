using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;

namespace COSXML.Model.Bucket
{
    public sealed class GetBucketRequest : BucketRequest
    {
        public GetBucketRequest(string bucket)
            : base(bucket)
        {
            this.method = CosRequestMethod.GET;
        }

        public void SetPrefix(string prefix)
        {
            if (prefix != null)
            {
                AddQueryParameter("prefix", prefix);
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

        public void SetMarker(string marker)
        {
            if (marker != null)
            {
                AddQueryParameter("marker", marker);
            }
        }

        public void SetMaxKeys(string maxKeys)
        {
            if (maxKeys != null)
            {
                AddQueryParameter("max-keys", maxKeys);
            }
        }
    }
}
