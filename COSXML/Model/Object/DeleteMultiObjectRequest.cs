using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;
using COSXML.Common;

namespace COSXML.Model.Object
{
    public sealed class DeleteMultiObjectRequest : ObjectRequest
    {
        private Delete delete;

        public DeleteMultiObjectRequest(string bucket)
            : base(bucket, null)
        {
            this.method = CosRequestMethod.POST;
            this.path = "/";
            this.queryParameters.Add("delete", null);
            delete = new Delete();
            delete.deleteObjects = new List<Delete.DeleteObject>();
        }

        public override void SetCosPath(string key)
        {
        }

        public void IsDeleteQuiet(bool quiet) 
        {
            delete.quiet = quiet;
        }

        public void SetDeleteKey(string key)
        {
            SetDeleteKey(key, null);
        }

        public void SetDeleteKey(string key, string versionId)
        {
            if (key != null)
            {
                if (key.StartsWith("/"))
                {
                    key = key.Substring(1);
                }
                Delete.DeleteObject deleteObject = new Delete.DeleteObject();
                deleteObject.key = key;
                if (versionId != null)
                {
                    deleteObject.versionId = versionId;
                }
                delete.deleteObjects.Add(deleteObject);
            }
        }

        public void SetObjectKeys(List<string> keys)
        {
            if (keys != null)
            {
                foreach (string key in keys)
                {
                    SetDeleteKey(key);
                }
            }
        }

        public void SetObjectKeys(Dictionary<string, string> versionIdAndKey)
        {
            if (versionIdAndKey != null)
            {
                foreach (KeyValuePair<string, string> pair in versionIdAndKey)
                {
                    SetDeleteKey(pair.Value, pair.Key);
                }
            }
        }

    }
}
