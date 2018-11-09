using System;
using System.Collections.Generic;

using System.Text;
using COSXML.Model.Tag;
using System.Xml;
using System.IO;

namespace COSXML.Transfer
{
    public sealed class XmlBuilder
    {
        public static string BuildCORSConfigXML(CORSConfiguration corsConfiguration)
        {
            StringWriter stringWriter = new StringWriter();
            XmlWriterSettings xmlWriterSetting = new XmlWriterSettings();
            xmlWriterSetting.Indent = true;

            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSetting);
            xmlWriter.WriteStartDocument();

            //start to write element
            xmlWriter.WriteStartElement("CORSConfiguration");
            if (corsConfiguration.corsRules != null)
            {
                foreach(CORSConfiguration.CORSRule  corsRule in corsConfiguration.corsRules)
                {
                    xmlWriter.WriteStartElement("CORSRule");

                    xmlWriter.WriteElementString("ID", corsRule.id);
                    xmlWriter.WriteElementString("AllowedOrigin", corsRule.allowedOrigin);
                    if (corsRule.allowedMethods != null)
                    {
                        foreach (string method in corsRule.allowedMethods)
                        {
                            xmlWriter.WriteElementString("AllowedMethod", method);
                        }
                    }
                    if (corsRule.allowedHeaders != null)
                    {
                        foreach (string header in corsRule.allowedHeaders)
                        {
                            xmlWriter.WriteElementString("AllowedHeader", header);
                        }
                    }
                    if (corsRule.exposeHeaders != null)
                    {
                        foreach (string exposeHeader in corsRule.exposeHeaders)
                        {
                            xmlWriter.WriteElementString("ExposeHeader", exposeHeader);
                        }
                    }
                    xmlWriter.WriteElementString("MaxAgeSeconds", corsRule.maxAgeSeconds.ToString());

                    xmlWriter.WriteEndElement();
                }
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            return RemoveXMLHeader(stringWriter.ToString());
        }

        private static string RemoveXMLHeader(string xmlContent)
        {
            if (xmlContent != null)
            {
                if (xmlContent.StartsWith("<?xml"))
                {
                    int end = xmlContent.IndexOf("?>");
                    xmlContent = xmlContent.Substring(end + 2);
                }
            }
            return xmlContent;
        }

    }
}
