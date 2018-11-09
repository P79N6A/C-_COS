using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 4:39:49 PM
* bradyxiao
*/
namespace COSXML.Network
{
    public class Response
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public Dictionary<string, List<string>> Headers { get; set; }

        public long ContentLength { get; set; }

        public ResponseBody Body { get; set; }
       
    }

}
