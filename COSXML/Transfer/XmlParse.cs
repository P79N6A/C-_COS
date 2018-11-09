using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.IO;
using COSXML.Model.Tag;

namespace COSXML.Transfer
{
    public sealed class XmlParse
    {
        public static void ParseListAllMyBucketsResult(Stream inStream, ListAllMyBuckets result)
        {
            XmlReader xmlReader = XmlReader.Create(inStream);
            ListAllMyBuckets.Bucket bucket = null;

            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element: // element start
                        if("Owner".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase)) // get element name
                        {
                            result.owner = new ListAllMyBuckets.Owner();
                        }
                        else if ("ID".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            xmlReader.Read();
                            result.owner.id = xmlReader.Value; // get element value
                        }
                        else if ("DisplayName".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            xmlReader.Read();
                            result.owner.disPlayName = xmlReader.Value;
                        }
                        else if ("Buckets".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            result.buckets = new List<ListAllMyBuckets.Bucket>();
                        }
                        else if ("Bucket".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            bucket = new ListAllMyBuckets.Bucket();
                        }
                        else if ("Bucket".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            bucket = new ListAllMyBuckets.Bucket();
                        }
                        else if ("Name".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            xmlReader.Read();
                            bucket.name = xmlReader.Value;
                        }
                        else if ("Location".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            xmlReader.Read();
                            bucket.location = xmlReader.Value;
                        }
                        else if ("CreateDate".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            xmlReader.Read();
                            bucket.createDate = xmlReader.Value;
                        }
                        break;
                    case XmlNodeType.EndElement: //end element
                        if ("Bucket".Equals(xmlReader.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            result.buckets.Add(bucket);
                            bucket = null;
                        }
                        break;
                }
            }
        }


    }
}
