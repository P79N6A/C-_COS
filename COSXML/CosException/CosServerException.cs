using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 11:27:27 AM
* bradyxiao
*/
namespace COSXML.CosException
{
    public class CosServerException : System.ApplicationException
    {
        public int statusCode;
        public string statusMessage;
        public string errorCode;
        public string errorMessage;
        public string requestId;
        public string traceId;
        public string resource;

        public CosServerException(int statusCode, string statusMessage)
            : base("server exception: " + statusCode)
        {
            this.statusCode = statusCode;
            this.statusMessage = statusMessage;
        }
    }
}
