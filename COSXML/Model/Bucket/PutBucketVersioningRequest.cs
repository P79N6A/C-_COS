﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
using COSXML.Model.Tag;

namespace COSXML.Model.Bucket
{
    public sealed class PutBucketVersioningRequest : BucketRequest
    {
        private VersioningConfiguration versioningConfiguration;

        public PutBucketVersioningRequest(string bucket)
            : base(bucket)
        {
            this.method = CosRequestMethod.PUT;
            this.queryParameters.Add("versioning", null);
            versioningConfiguration = new VersioningConfiguration();
        }


        public override Network.RequestBody GetRequestBody()
        {
            return base.GetRequestBody();
        }


        public void IsEnableVersionConfig(bool isEnable)
        {
            if (isEnable)
            {
                versioningConfiguration.status = "Enabled";
            }
            else
            {
                versioningConfiguration.status = "Suspended";
            }
        }
    }
}