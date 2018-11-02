using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 10:02:19 PM
* bradyxiao
*/
namespace COSXML.Model.CORSTag
{
    public sealed class CORSConfiguration
    {
        public List<CORSRule> corsRules;

        public String GetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder("{CORSConfiguration:\n");
            if(corsRules != null){
                foreach(CORSRule corsRule in corsRules)
                {
                    if (corsRule != null) stringBuilder.Append(corsRule.GetInfo()).Append("\n");
                }
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

    }

    public sealed class CORSRule{
        public String id;
        public String allowedOrigin;
        public List<String> allowedMethods;
        public List<String> allowedHeaders;
        public List<String> exposeHeaders;
        public int maxAgeSeconds;
     
        public String GetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder("{CORSRule:\n");
            stringBuilder.Append("ID:").Append(id).Append("\n");
            stringBuilder.Append("AllowedOrigin:").Append(allowedOrigin).Append("\n");
            if (allowedMethods != null)
            {
                foreach (String method in allowedMethods)
                {
                    if(method != null)stringBuilder.Append("AllowedMethod:").Append(method).Append("\n");
                }
            }
            if (allowedHeaders != null)
            {
                foreach (String header in allowedHeaders)
                {
                    if(header != null)stringBuilder.Append("AllowedHeader:").Append(header).Append("\n");
                }
            }
            if (exposeHeaders != null)
            {
                foreach (String exposeHeader in exposeHeaders)
                {
                    if(exposeHeader != null)stringBuilder.Append("ExposeHeader:").Append(exposeHeader).Append("\n");
                }
            }
            stringBuilder.Append("MaxAgeSeconds:").Append(maxAgeSeconds).Append("\n");
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}
