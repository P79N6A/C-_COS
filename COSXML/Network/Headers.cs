using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/5/2018 9:15:19 PM
* bradyxiao
*/
namespace COSXML.Network
{
    public sealed class Headers
    {
        private string[] nameAndValues;

        internal Headers(Builder builder)
        {
            this.nameAndValues = builder.namesAndValues.ToArray();
        }

        private Headers(string[] nameAndValues)
        {
            this.nameAndValues = nameAndValues;
        }

        public string Get(string name)
        {
            return Get(nameAndValues, name);
        }

        private static string Get(string[] nameAndValues, string name)
        {
            for (int i = nameAndValues.Length - 2; i >= 0; i -= 2)
            {
                if(name.Equals(nameAndValues[i], StringComparison.OrdinalIgnoreCase)
                {
                    return nameAndValues[i + 1];
                }
            }
            return null;
        }

        public sealed class Builder
        {
            internal List<string> namesAndValues = new List<string>(20);


            /**
              * Add a header line without any validation. Only appropriate for headers from the remote peer
              * or cache.
              */
            internal Builder AddLenient(string name, string value)
            {
                namesAndValues.Add(name);
                namesAndValues.Add(value.Trim());
                return this;
            }

            Builder AddLenient(string line)
            {
                int index = line.IndexOf(":", 1);
                if (index != -1)
                {
                    return AddLenient(line.Substring(0, index), line.Substring(index + 1));
                }
                else if (line.StartsWith(":"))
                {
                    // Work around empty header names and header names that start with a
                    // colon (created by old broken SPDY versions of the response cache).
                    return AddLenient("", line.Substring(1)); // Empty header name.
                }
                else
                {
                    return AddLenient("", line); // No header name.
                }
            }

            public Builder Add(string line)
            {
                int index = line.IndexOf(":");
                if (index == -1)
                {
                    throw new 
                }
            }


            private void CheckNameAndValue(String name, String value)
            {
                if (name == null) throw new NullPointerException("name == null");
                if (name.isEmpty()) throw new IllegalArgumentException("name is empty");
                for (int i = 0, length = name.length(); i < length; i++)
                {
                    char c = name.charAt(i);
                    if (c <= '\u0020' || c >= '\u007f')
                    {
                        throw new IllegalArgumentException(Util.format(
                            "Unexpected char %#04x at %d in header name: %s", (int)c, i, name));
                    }
                }
                if (value == null) throw new NullPointerException("value for name " + name + " == null");
                for (int i = 0, length = value.length(); i < length; i++)
                {
                    char c = value.charAt(i);
                    if ((c <= '\u001f' && c != '\t') || c >= '\u007f')
                    {
                        throw new IllegalArgumentException(Util.format(
                            "Unexpected char %#04x at %d in %s value: %s", (int)c, i, name, value));
                    }
                }
            }

            public string Get(string name)
            {
                for (int i = namesAndValues.Count - 2; i >= 0; i -= 2)
                {
                    if (name.Equals(namesAndValues[i], StringComparison.OrdinalIgnoreCase))
                    {
                        return namesAndValues[i + 1];
                    }
                }
                return null;
            }

            public Headers build()
            {
                return new Headers(this);
            }


 
        }

    }
}
