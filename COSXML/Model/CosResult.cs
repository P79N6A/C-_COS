﻿using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Network;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/2/2018 1:05:46 PM
* bradyxiao
*/
namespace COSXML.Model
{
    /**
     * this class for cos result.
     * 
     */
    public abstract class CosResult
    {
        public int httpCode;

        public string httpMessage;

        public Dictionary<string, List<string>> responseHeaders;

        public string accessUrl;

        /**
         * Exception:
         *      throw CosClientException, CosServerException
         */
        public virtual void ParseResponse(Response response) 
        {

        }

        public ResponseBody GetResponseBody() 
        {
            return null;
        }

        public virtual string GetResultInfo()
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.Append(httpCode).Append(" ").Append(httpMessage).Append("\n");
            if (responseHeaders != null)
            {
                foreach(KeyValuePair<string, List<string>> element in responseHeaders)
                {
                    resultBuilder.Append(element.Key).Append(": ").Append(element.Value[0]).Append("\n");
                }
            }

            return resultBuilder.ToString();
        }
    }
}
