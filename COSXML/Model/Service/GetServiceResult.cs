﻿using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 5:50:56 PM
* bradyxiao
*/
namespace COSXML.Model.Service
{
    public sealed class GetServiceResult : CosResult
    {
        public ListAllMyBuckets listAllMyBuckets;

        public override void ParseResponse(Network.Response response)
        {
            throw new NotImplementedException();
        }

        public override string GetResultInfo()
        {
            return base.GetResultInfo() + (listAllMyBuckets == null ? "" : "\n" + listAllMyBuckets.GetInfo());
        }
    }
}
