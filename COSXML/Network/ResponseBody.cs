using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 4:34:20 PM
* bradyxiao
*/
namespace COSXML.Network
{
    public abstract class ResponseBody
    {
        public long ContentLength
        { get; set; }

        public string ContentType
        { get; set; }

        public abstract void OnRead(Stream stream);
    }
}
