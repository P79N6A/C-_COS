using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/1/2018 9:48:15 PM
* bradyxiao
*/
namespace COSXML.Utils
{
    public enum COSRegion
    {
        [COSValue("ap-beijing-1")]
        AP_Beijing_1,

        [COSValue("ap-beijing")]
        AP_Beijing,

        [COSValue("ap-shanghai")]
        AP_Shanghai,

        [COSValue("ap-guangzhou")]
        AP_Guangzhou,

        [COSValue("ap-guangzhou-2")]
        AP_Guangzhou_2,
        
        [COSValue("ap-chengdu")]
        AP_Chengdu,

        [COSValue("ap-singapore")]
        AP_Singapore,

        [COSValue("ap-hongkong")]
        AP_Hongkong,

        [COSValue("na-toronto")]
        NA_Toronto,

        [COSValue("eu-frankfurt")]
        EU_Frankfurt

    }
}
