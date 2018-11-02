﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 9:07:34 PM
* bradyxiao
*/
namespace COSXML.Model.Bucket
{
    public sealed class GetBucketACLRequest : BucketRequest
    {
        public GetBucketACLRequest(string bucket)
        {
            this.bucket = bucket;
            this.method = CosRequestMethod.GET;
            this.queryParameters.Add("acl", null);
        }
    }
}