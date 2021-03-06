﻿using System;
using System.Collections.Generic;

using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 11:26:53 AM
* bradyxiao
*/
namespace COSXML.CosException
{
    public class CosClientException : System.ApplicationException
    {
        public int errorCode;

        public CosClientException(int errorCode, string message)
            : base(message)
        {
            this.errorCode = errorCode;
        }

        public CosClientException(int errorCode, string message, Exception cause) 
            :base(message, cause)
        {
            this.errorCode = errorCode;
        }
    }
}
