/********
 * @version   : 1.0.0
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-06-15
 * @copyright : Copyright (c) 2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.IO;
using System.IO.Compression;
using System.Text;
using System.Web;

namespace Ext.Net.Utilities
{
    public class CompressionUtils
    {
        public static void GZipAndSend(object instance)
        {
            CompressionUtils.GZipAndSend((instance != null) ? instance.ToString() : "");
        }

        public static void GZipAndSend(string instance)
        {
            CompressionUtils.GZipAndSend(instance, "application/json");
        }

        public static void GZipAndSend(string instance, string responseType)
        {
            CompressionUtils.GZipAndSend(Encoding.UTF8.GetBytes(instance), responseType);
        }

        public static void GZipAndSend(byte[] instance, string responseType)
        {
            CompressionUtils.Send(CompressionUtils.GZip(instance), responseType);
        }

        public static void Send(byte[] instance, string responseType)
        {
            HttpResponse response = HttpContext.Current.Response;

            response.AppendHeader("Content-Encoding", "gzip");
            response.Charset = "utf-8";
            response.ContentType = responseType;
            response.BinaryWrite(instance);
        }

        public static byte[] GZip(string instance)
        {
            return GZip(Encoding.UTF8.GetBytes(instance));
        }

        public static byte[] GZip(byte[] instance)
        {
            MemoryStream stream = new MemoryStream();
            GZipStream zipstream = new GZipStream(stream, CompressionMode.Compress);
            zipstream.Write(instance, 0, instance.Length);
            zipstream.Close();

            return stream.ToArray();
        }

        public static bool IsGZipSupported
        {
            get
            {
                HttpRequest request = HttpContext.Current.Request;

                bool ie6 = request.Browser.IsBrowser("IE") && request.Browser.MajorVersion <= 6;
                string encoding = (request.Headers["Accept-Encoding"] ?? "").ToLowerInvariant();

                return !ie6 && encoding.Contains("gzip", "deflate");
            }
        }
    }
}
