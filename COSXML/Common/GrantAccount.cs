﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COSXML.Common
{
    public sealed class GrantAccount
    {
        List<string> idList;
        public GrantAccount()
        {
            idList = new List<string>();
        }
        public void AddGrantAccount(string ownerUin, string subUin)
        {
            if (ownerUin != null && subUin != null)
            {
                idList.Add(String.Format("id=\"qcs::cam::uin/%s:uin/%s\"", ownerUin, subUin));
            }
        }

        public string GetGrantAccounts()
        {
            StringBuilder idBuilder = new StringBuilder();
            foreach(string id in idList)
            {
                idBuilder.Append(id).Append(",");
            }
            string idStr = idBuilder.ToString();
            int last = idStr.LastIndexOf(",");
            if (last > 0)
            {
                return idStr.Substring(0, last);
            }
            return null;
        }
    }
}
