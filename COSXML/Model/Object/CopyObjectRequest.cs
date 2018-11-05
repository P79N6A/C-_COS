using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Common;
using COSXML.CosException;
using COSXML.Model.Tag;
using COSXML.Utils;
using COSXML.Mdel.Tag;

namespace COSXML.Model.Object
{
    public sealed class CopyObjectRequest : ObjectRequest
    {
        private CopySourceStruct copySourceStruct;

        public CopyObjectRequest(string bucket, string key)
            : base(bucket, key)
        {
            this.method = CosRequestMethod.PUT;
        }

        public void SetCopySource(CopySourceStruct copySource)
        {
            this.copySourceStruct = copySource;
        }

        public void SetCopyMetaDataDirective(CosMetaDataDirective metaDataDirective)
        {
            AddRequestHeader(CosRequestHeaderKey.X_COS_METADATA_DIRECTIVE, EnumUtils.GetValue(metaDataDirective));
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

        public void SetCosStorageClass(CosStorageClass cosStorageClass)
        {
            AddRequestHeader(CosRequestHeaderKey.X_COS_STORAGE_CLASS_, EnumUtils.GetValue(cosStorageClass));
        }

        public void SetCosACL(string cosACL)
        {
            if (cosACL != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_ACL, cosACL);
            }
        }

        public void SetCosACL(CosACL cosACL)
        {
            AddRequestHeader(CosRequestHeaderKey.X_COS_ACL, EnumUtils.GetValue(cosACL));
        }

        public void setXCosGrantRead(GrantAccount grantAccount)
        {
            if (grantAccount != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_GRANT_READ, grantAccount.GetGrantAccounts());
            }
        }

        public void setXCosGrantWrite(GrantAccount grantAccount)
        {
            if (grantAccount != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_GRANT_WRITE, grantAccount.GetGrantAccounts());
            }
        }

        public void setXCosReadWrite(GrantAccount grantAccount)
        {
            if (grantAccount != null)
            {
                AddRequestHeader(CosRequestHeaderKey.X_COS_GRANT_FULL_CONTROL, grantAccount.GetGrantAccounts());
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
        }

        protected override void InteranlUpdateHeaders()
        {
            this.headers.Add(CosRequestHeaderKey.X_COS_COPY_SOURCE, copySourceStruct.GetCopySouce());

        }
    }
}
