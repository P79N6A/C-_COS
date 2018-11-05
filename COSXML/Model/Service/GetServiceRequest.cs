using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 5:25:23 PM
* bradyxiao
*/
namespace COSXML.Model.Service
{
    public sealed class GetServiceRequest : CosRequest
    {
        public GetServiceRequest()
        {
            method = CosRequestMethod.GET;
            path = "/";
        }

        public override Network.RequestBody GetRequestBody()
        {
            return null;
        }

        public override string GetHost()
        {
            return "service.cos.myqcloud.com";
        }

        public override void CheckParameters()
        {
            return;
        }
    }
}
