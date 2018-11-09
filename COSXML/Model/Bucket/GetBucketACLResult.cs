using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 9:08:55 PM
* bradyxiao
*/
namespace COSXML.Model.Bucket
{
    public sealed class GetBucketACLResult : CosResult
    {
        public AccessControlPolicy accessControlPolicy;

        public override void ParseResponse(Network.Response response)
        {
            base.ParseResponse(response);
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (accessControlPolicy == null ? "" : "\n" + accessControlPolicy.GetInfo());
        }
    }
}
