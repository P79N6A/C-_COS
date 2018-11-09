﻿using System;
using System.Collections.Generic;
using System.Text;

namespace COSXML.Mdel.Tag
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
                idList.Add(String.Format("id=\"qcs::cam::uin/{0}:uin/{1}\"", ownerUin, subUin));
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
