using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COSXML.Common
{
    public sealed class CosRequestHeaderKey
    {
        public static string X_COS_ACL = "x-cos-acl";
        public static string X_COS_GRANT_READ = "x-cos-grant-read";
        public static string X_COS_GRANT_WRITE = "x-cos-grant-write";
        public static string X_COS_GRANT_FULL_CONTROL = "x-cos-grant-full-control";
        public static string CACHE_CONTROL = "Cache-Control";
        public static string CONTENT_DISPOSITION = "Content-Disposition";
        public static string CONTENT_ENCODING = "Content-Encoding";
        public static string EXPIRES = "Expires";
        public static string X_COS_COPY_SOURCE = "x-cos-copy-source";
        public static string X_COS_METADATA_DIRECTIVE = "x-cos-metadata-directive";
        public static string X_COS_COPY_SOURCE_IF_MODIFIED_SINCE= "x-cos-copy-source-If-Modified-Since";
        public static string X_COS_COPY_SOURCE_IF_UNMODIFIED_SINCE = "x-cos-copy-source-If-Unmodified-Since";
        public static string X_COS_COPY_SOURCE_IF_MATCH = "x-cos-copy-source-If-Match";
        public static string X_COS_COPY_SOURCE_IF_NONE_MATCH = "x-cos-copy-source-If-None-Match";
        public static string X_COS_STORAGE_CLASS_ = "x-cos-storage-class";
        public static string X_COS_COPY_SOURCE_RANGE = "x-cos-copy-source-range";
        public static string ORIGIN = "Origin";
        public static string ACCESS_CONTROL_REQUEST_METHOD = "Access-Control-Request-Method";
        public static string ACCESS_CONTROL_REQUEST_HEADERS = "Access-Control-Request-Headers";
        public static string IF_MODIFIED_SINCE = "If-Modified-Since";
        public static string IF_UNMODIFIED_SINCE = "If-Unmodified-Since";
        public static string IF_MATCH = "If-Match";
        public static string IF_NONE_MATCH = "If-None-Match";
        public static string APPLICATION_XML = "application/xml";
        public static string TEXT_PLAIN = "text/plain";
        public static string APPLICATION_OCTET_STREAM = "application/octet-stream";
        public static string RANGE = "Range";
        public static string VERSION_ID = "versionId";
        public static string ENCODING_TYPE = "Encoding-type";
        public static string PART_NUMBER_MARKER = "part-number-marker";
        public static string MAX_PARTS = "max-parts";
    }
}
