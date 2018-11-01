using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/1/2018 9:48:38 PM
* bradyxiao
*/
namespace COSXML.Utils
{
   public sealed class COSValueAttribute : Attribute
    {
        public string value
        {
            get;
            private set;
        }

        public COSValueAttribute(string value)
        {
            this.value = value;
        }
    }
}
