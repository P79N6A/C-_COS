﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
using COSXML.Model.Tag;
using COSXML.CosException;

namespace COSXML.Model.Object
{
    public sealed class UploadPartCopyRequest : ObjectRequest
    {
        private CopySourceStruct copySourceStruct;
        /**Specified part number*/
        private int partNumber = -1;
        /**init upload generate' s uploadId by service*/
        private String uploadId = null;

        public UploadPartCopyRequest(string bucket, string key, int partNumber, string uploadId)
            : base(bucket, key)
        {
            this.method = CosRequestMethod.PUT;
            this.partNumber = partNumber;
            this.uploadId = uploadId;
        }

        public void SetCopySource(CopySourceStruct copySource)
        {
            this.copySourceStruct = copySource;
        }

        public void SetCopyRange(long start, long end)
        {
            if (start >= 0 && end >= start)
            {
                string bytes = String.Format("bytes={0}-{1}", start, end);
                AddRequestHeader(CosRequestHeaderKey.X_COS_COPY_SOURCE_RANGE, bytes);
            }
        }

        public void SetCopyIfModifiedSince(string sourceIfModifiedSince)
        {
            if (sourceIfModifiedSince != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_COPY_SOURCE_IF_MODIFIED_SINCE, sourceIfModifiedSince);
            }
        }

        public void SsetCopyIfUnmodifiedSince(string sourceIfUnmodifiedSince)
        {
            if (sourceIfUnmodifiedSince != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_COPY_SOURCE_IF_UNMODIFIED_SINCE, sourceIfUnmodifiedSince);
            }
        }

        public void SetCopyIfMatch(string eTag)
        {
            if (eTag != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_COPY_SOURCE_IF_MATCH, eTag);
            }
        }

        public void SetCopyIfNoneMatch(string eTag)
        {
            if (eTag != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_COPY_SOURCE_IF_NONE_MATCH, eTag);
            }
        }

        public override void CheckParameters()
        {
            base.CheckParameters();
            if (copySourceStruct == null)
            {
                throw new CosClientException((int)CosClientError.INVALID_ARGUMENT, "copy source is null");
            }
            else
            {
                copySourceStruct.CheckParameters();
            }
            if (partNumber <= 0)
            {
                throw new CosClientException((int)CosClientError.INVALID_ARGUMENT, "partNumber is less than  1");
            }
            if (uploadId == null)
            {
                throw new CosClientException((int)CosClientError.INVALID_ARGUMENT, "uploadID is null");
            }
        }

        protected override void InternalUpdateQueryParameters()
        {
            this.queryParameters.Add("partNumber", partNumber.ToString());
            this.queryParameters.Add("uploadId", uploadId);
        }

    }
}
