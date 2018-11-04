using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;

namespace COSXML.Model.Bucket
{
    public sealed class HeadBucketRequest : BucketRequest
    {
        public HeadBucketRequest(string bucket)
            : base(bucket)
        {
            this.method = CosRequestMethod.HEAD;
        }
    }
}
