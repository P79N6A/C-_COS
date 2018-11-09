using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Common;
using System.IO;

namespace COSXML.Model.Object
{
    public sealed class UploadPartRequest : ObjectRequest
    {
        private int partNumber;
        private string uploadId;
        private string srcPath;
        private long fileOffset = -1L;
        private long contentLength = -1L;
        private byte[] data;


        private UploadPartRequest(string bucket, string key, int partNumber, string uploadId)
            : base(bucket, key)
        {
            this.method = CosRequestMethod.PUT;
            this.partNumber = partNumber;
            this.uploadId = uploadId;
        }

        public UploadPartRequest(string bucket, string key, int partNumber, string uploadId, string srcPath, long fileOffset,
            long fileSendLength)
            : this(bucket, key, partNumber, uploadId)
        {
            this.srcPath = srcPath;
            this.fileOffset = fileOffset;
            this.contentLength = fileSendLength;
        }

        public UploadPartRequest(string bucket, string key, int partNumber, string uploadId, string srcPath)
            : this(bucket, key, partNumber, uploadId, srcPath, -1L, -1L)
        { }

        public UploadPartRequest(string bucket, string key, int partNumber, string uploadId, byte[] data)
            :this(bucket, key, partNumber, uploadId)
        {
            this.data = data;
        }

        public void SetPartNumber(int partNumber)
        {
            this.partNumber = partNumber;
        }

        public void SetUploadId(string uploadId)
        {
            this.uploadId = uploadId;
        }






    }
}
