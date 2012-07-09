using System;
using System.IO;
using System.Text;
using System.Web;

namespace Ext.Net.Examples
{
    public class AnalyticsFilter : Stream
    {
        private readonly Stream response;
        private readonly StringBuilder html;

        public const string ANALYTIC_SCRIPT = @"<script type=""text/javascript""> 
 
           var _gaq = _gaq || [];
           _gaq.push(['_setAccount', 'UA-19135912-3']);
           _gaq.push(['_setDomainName', '.ext.net']);
           _gaq.push(['_trackPageview']);
           _gaq.push(['_setAllowHash', false]);
         
           (function() {
          var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
          ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
          var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
           })();
        </script>";

        public AnalyticsFilter(Stream stream)
        {
            this.response = stream;
            this.html = new StringBuilder();
        }

        public override void Flush()
        {
            if (this.html.Length == 0)
            {
                this.response.Flush();
                return;
            }

            int index = this.html.ToString().IndexOf("</body>", StringComparison.InvariantCultureIgnoreCase);
            if (index >= 0)
            {
                this.html.Insert(index, ANALYTIC_SCRIPT);
            }

            byte[] data = System.Text.Encoding.UTF8.GetBytes(this.html.ToString());
            this.response.Write(data, 0, data.Length);
            this.response.Flush();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.html.Append(HttpContext.Current.Response.ContentEncoding.GetString(buffer, offset, count));
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Close()
        {
            this.response.Close();
        }

        public override long Length
        {
            get { return 0; }
        }

        private long position;

        public override long Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.response.Seek(offset, origin);
        }

        public override void SetLength(long length)
        {
            this.response.SetLength(length);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.response.Read(buffer, offset, count);
        }
    }
}
