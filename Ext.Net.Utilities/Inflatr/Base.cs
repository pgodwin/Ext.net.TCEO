/********
 * @version   : 1.0.0
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-06-15
 * @copyright : Copyright (c) 2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ext.Net.Utilities.Inflatr
{
    public abstract class Base
    {
        private Options options;
        protected int index = 0;
        protected string input = "";
        protected int c = 0;
        protected StringBuilder r;

        public Base()
        {
            this.options = new Options();
            this.r = this.Indent();
        }

        public Base(Options options) : this()
        {
            if (options != null)
            {
                this.options = options.Clone();
                this.r = this.Indent();
            }
        }

        public Options Options
        {
            get
            {
                return this.options;
            }
        }

        /// <summary>
        /// Inflate the string
        /// </summary>
        /// <param name="input">compressed string</param>
        /// <returns>Inflated string</returns>
        public abstract string Inflate(string input);

        private Regex escapeRe = new Regex(@"([.*+?^${}()|[\]\/\\])", RegexOptions.Compiled);
        protected string Escape(string pattern)
        {
            return escapeRe.Replace(pattern, "\\$1");
        }

        protected StringBuilder Indent()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.options.Level; i++)
            {
                sb.Append(this.options.Indent);
            }

            return sb;
        }

        protected int LastIndexOf(Regex pattern)
        {
            return this.LastIndexOf(pattern, null);
        }

        protected int LastIndexOf(Regex pattern, string input)
        {
            if (input.IsEmpty())
            {
                input = this.input;
            }

            for (int i = this.index; i >= 0; i--)
            {
                bool match = pattern.IsMatch(input, i);
                if (match)
                { 
                    return i; 
                }
            }
            return -1;
        }

        protected bool After(Regex pattern, Regex start)
        {
            int i = this.LastIndexOf(start);
            
            if (i > 0)
            {
                return pattern.IsMatch(this.input, i);
            }

            return false;
        }

        protected void Append(params string[] strings)
        {
            foreach (string item in strings)
            {
                if (item != null)
                {
                    this.r.Append(item);
                    this.c += item.Length;
                }
            }
        }

        protected string Peek(string pat)
        {
            Match m = new Regex("^" + pat, RegexOptions.Multiline).Match(this.input, this.index);
            return m.Success ? m.Groups[0].Value : null;
        }

        protected string Scan(string pat)
        {
            string m = this.Peek(pat);
            if (m.IsNotEmpty())
            {
                this.index += m.Length;
                return m;
            }

            return null;
        }

        protected bool NextChar()
        {
            this.Append(this.Scan("(\n|.)"));
            return true;
        }

        protected bool WhiteSpace()
        {
            if (this.Scan("\\s+").IsNotEmpty())
            {
                this.Append(" ");
                return true;
            }

            return false;
        }

        private Regex newLineRe1 = new Regex("\\Z", RegexOptions.Compiled);
        private Regex newLineRe2 = new Regex("\\S", RegexOptions.Compiled);
        protected string NewLine()
        {
            int x = this.LastIndexOf(this.newLineRe1, this.r.ToString());
            int y = this.LastIndexOf(this.newLineRe2, this.r.ToString());

            if ( x < 0 || y < 0 || x < y ) {
                this.c = 0; 
                return "\n" + this.Indent().ToString();      
            } 
            else 
            { 
                return ""; 
            }
        }

        protected string ScanUntil(string pat)
        {
            Regex re = new Regex("^((?:(?!"+pat+").)*)"+pat, RegexOptions.Multiline);
            Match m = re.Match(this.input, this.index);

            if (m.Success)
            {
                this.index += m.Groups[0].Length; 
                return m.Groups[1].Value;
            }

            return null;
        }

        protected string Between(string start)
        {
            return this.Between(start, start);
        }

        protected string Between(string start, string finish)
        {
            string m = this.Scan(start);
            if (m.IsNotEmpty())
            {
                m = this.ScanUntil(finish);
                if (m.IsNotEmpty())
                {
                    return m;
                }
                else
                {
                    throw new Exception("Between: unmatched " + finish + " after " + start + ".");
                }
            }

            return null;
        }
    }
}
