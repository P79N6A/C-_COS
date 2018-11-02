using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 2:34:04 PM
* bradyxiao
*/
namespace COSXML.Common
{
    public sealed class CosVersion
    {
        public static string SDKVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}
