using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Utils;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 8:19:06 PM
* bradyxiao
*/
namespace COSXML.Common
{
    public enum CosClientError
    {
        [CosValue("InvalidArgument")]
        INVALIDARGUMENT = 10000,

        [CosValue("InvalidCredentials")]
        INVALIDCREDENTIALS = 10001,

        [CosValue("BadRequest")]
        BADREQUEST = 10002,

        [CosValue("SinkSourceNotFound")]
        SINKSOURCENOTFOUND = 10003,

        [CosValue("InternalError")]
        INTERNALERROR = 20000,

        [CosValue("ServerError")]
        SERVERERROR = 20001,

        [CosValue("IOError")]
        IOERROR = 20002,

        [CosValue("PoorNetwork")]
        POORNETWORK = 20003,

        [CosValue("UserCancelled")]
        USERCANCELLED = 30000,

        [CosValue("AlreadyFinished")]
        ALREADYFINISHED = 30001,
    }
}
