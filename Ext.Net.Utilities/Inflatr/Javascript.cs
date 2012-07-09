/********
 * @version   : 1.0.0
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-06-15
 * @copyright : Copyright (c) 2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ext.Net.Utilities.Inflatr
{
    public class Javascript : Base
    {
        public const string KEYWORDS = "(function|continue|default|finally|export|return|switch|import|delete|throw|const|while|catch|break|void|case|with|this|else|for|try|var|new|do|in|if)\\W";
        public const string OPERATORS = "(instanceof|typeof|>>>=|===|<<=|>>=|>>>|!==|!=|>=|\\*=|<=|\\+\\+|\\-=|==|&&|>>|<<|/=|\\|\\||\\+=|\\^=|\\|=|&=|\\-\\-|\\||&|\\^|>|<|!|=|\\?|:|%|/|\\*|\\-|\\+)";

        public override string Inflate(string input)
        {
            this.input = input; 
            while ( this.index < this.input.Length ) 
            {
              bool r = this.Comment() || this.String() || this.Regex() || this.Operator() || 
              this.Keyword() ||this.OpenBlock() || this.CloseBlock() || this.Comma() || 
              this.Parens() || this.Eos() || this.Eol() || this.NextChar();
            }
            return new Regex("\\s*$").Replace(this.r.ToString(), "");
        }

        protected virtual bool Comment()
        {
            string m = this.Between("//", "\n");
            if (m.IsNotEmpty())
            {
                this.Append("//", m, this.NewLine());
                return false;
            }
            else
            {
                m = this.Between(this.Escape("/*"), this.Escape("*/"));
                if (m.IsNotEmpty())
                {
                    this.Append("/*", m, "*/");
                    return true;
                }
            }

            return false;
        }

        protected virtual bool String()
        {
            string m = this.Between("'");
            if (m.IsNotEmpty())
            {
                this.Append("'" + m + "'");
                return true;
            }
            else
            {
                m = this.Between("\"");
                if (m.IsNotEmpty())
                {
                    this.Append("\"" + m + "\"");
                    return true;
                }
            }

            return false;
        }

        private Regex afterPatternRegex = new Regex("^(\\d|\\w|\\$|_\\))", RegexOptions.Compiled);
        private Regex afterStartRegex = new Regex("(\\:|\\S)", RegexOptions.Compiled);
        protected virtual bool Regex()
        {
            if (!this.After(this.afterPatternRegex, this.afterStartRegex))
            {
                string m = this.Between("/");
                if (m.IsNotEmpty())
                {
                    this.Append("/"+m+"/");
                    return true;
                }
            }

            return false;
        }

        protected virtual bool Operator()
        {
            string m = this.Scan(Javascript.OPERATORS);
            if (m.IsNotEmpty())
            {
                this.Append(" " + m + " ");
                return true;
            }

            return false;
        }

        protected virtual bool Keyword()
        {
            return false;
        }

        protected virtual bool OpenBlock()
        {
            if (this.Scan("\\{").IsNotEmpty())
            {
                this.Options.Level += 1; 
                this.Append(" {", this.NewLine() );
                return true;
            }

            return false;
        }

        protected virtual bool CloseBlock()
        {
            if(this.Scan("\\}").IsNotEmpty())
            {
                this.Options.Level -= 1; 
                this.Append( this.NewLine(), "}" );
                if (this.Peek("[;,\\}]").IsNotEmpty()) 
                { 
                    this.Append( this.NewLine() ); 
                }

                return true;
            }

            return false;
        }

        protected virtual bool Comma()
        {
            if (this.Scan(",").IsNotEmpty())
            {
                if (this.Peek("(?!\\{\\})*;").IsNotEmpty() || (this.c < this.Options.Wrap))
                {
                    this.Append(", ");
                } else {
                    this.Append(",", this.NewLine() );
                }
                return true;
            }

            return false;
        }

        protected virtual bool Parens()
        {
            if (this.Scan("\\(\\s*\\)").IsNotEmpty())
            {
                this.Append("()");
                return true;
            }
            else if(this.Scan("\\(").IsNotEmpty())
            {
                this.Append(" ( ");
                return true;
            }
            else if (this.Scan("\\)").IsNotEmpty())
            {
                this.Append(" ) ");
                return true;
            }

            return false;
        }

        protected virtual bool Eos()
        {
            if (this.Scan(";").IsNotEmpty())
            {
                this.Append(";");
                if (this.Peek("\\s*\\}").IsNotEmpty())
                {
                    this.Append(this.NewLine());
                }
                return true;
            }

            return false;
        }

        protected virtual bool Eol()
        {
            return this.Scan("\n").IsNotEmpty();
        }
    }
}
