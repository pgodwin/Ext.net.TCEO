/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 1.2.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-09-12
 * @copyright : Copyright (c) 2006-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TokenUtils
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string ID_PATTERN = @"#{\w[^\r;})]+}";        

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string SELECT_PATTERN = @"\${[^{}]+}";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string DIRECTMETHODS_PATTERN = "#{DirectMethods}";

        private static Regex ID_Pattern_RE = new Regex(TokenUtils.ID_PATTERN, RegexOptions.Compiled);
        private static Regex Begin_ID_Pattern_RE = new Regex("^" + TokenUtils.ID_PATTERN, RegexOptions.Compiled);
        private static Regex Select_Pattern_RE = new Regex(TokenUtils.SELECT_PATTERN, RegexOptions.Compiled);
        private static Regex Begin_Select_Pattern_RE = new Regex("^" + TokenUtils.SELECT_PATTERN, RegexOptions.Compiled);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsDirectMethodsToken(string script)
        {
            return script.IndexOf(TokenUtils.DIRECTMETHODS_PATTERN) >= 0;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsAlertToken(string script)
        {
            return script.IsNotEmpty() ? (script.StartsWith("!{") && script.EndsWith("}")) : false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsRawToken(string script)
        {
            return script.IsNotEmpty() ? ((script.StartsWith("={") && script.EndsWith("}")) || script.StartsWith("<raw>")) : false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsFunction(string script)
        {
            return script.IsNotEmpty() ? ((script.StartsWith("function(") || script.StartsWith("Ext.get") || script.StartsWith("Ext.select"))) : false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIDToken(string script)
        {
            return script.IsNotEmpty() ?  Begin_ID_Pattern_RE.Matches(script).Count == 1 : false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsSelectToken(string script)
        {
            return script.IsNotEmpty() ? Begin_Select_Pattern_RE.Matches(script).Count == 1 : false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsFunctionToken(string script)
        {
            return script.IsNotEmpty() ? (script.StartsWith("#(") && script.EndsWith(")")) : false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ParseTokens(string script)
        {
            return TokenUtils.ParseTokens(script, TokenUtils.Page);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ParseTokens(string script, Control seed)
        {
            if (seed == null)
            {
                seed = TokenUtils.Page;
            }

            bool isRaw = (
                TokenUtils.IsAlertToken(script) ||
                TokenUtils.IsRawToken(script) ||
                TokenUtils.IsSelectToken(script));
            
            script = TokenUtils.ReplaceIDTokens(script, seed);
            script = TokenUtils.ReplaceSelectTokens(script);

            script = TokenUtils.ReplaceAlertToken(script);
            script = TokenUtils.ReplaceRawToken(script);
            script = TokenUtils.ReplaceFunctionToken(script);

            return (isRaw || TokenUtils.IsFunction(script)) ? "<raw>".ConcatWith(script) : script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ReplaceDirectMethods(string script, Control seed)
        {
            if (TokenUtils.IsDirectMethodsToken(script))
            {
                UserControl parent = seed as UserControl;

                if (parent == null)
                {
                    parent = ReflectionUtils.GetTypeOfParent(seed, typeof(System.Web.UI.UserControl)) as UserControl;
                }

                ResourceManager sm = null;
                string ns = "Ext.net.DirectMethods";

                if (parent != null && !(parent is MasterPage && seed.Parent is System.Web.UI.WebControls.ContentPlaceHolder))
                {
                    string id = ResourceManager.GetControlIdentification(parent);

                    if (id.IsNotEmpty())
                    {
                        id = ".".ConcatWith(id);
                    }

                    sm = ResourceManager.GetInstance(HttpContext.Current);

                    if (sm != null)
                    {
                        ns = sm.DirectMethodNamespace;
                    }

                    return script.Replace(TokenUtils.DIRECTMETHODS_PATTERN, ns.ConcatWith(id));
                }
                else
                {
                    Page parentPage = seed as Page;

                    if (parentPage == null)
                    {
                        parentPage = ReflectionUtils.GetTypeOfParent(seed, typeof(System.Web.UI.Page)) as System.Web.UI.Page;
                    }

                    if (parentPage != null)
                    {
                        sm = ResourceManager.GetInstance(parentPage);

                        if (sm != null)
                        {
                            ns = sm.DirectMethodNamespace;
                        }

                        return script.Replace(TokenUtils.DIRECTMETHODS_PATTERN, ns);
                    }
                }
            }

            return script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static List<string> ExtractIDs(string script)
        {

            List<string> result = new List<string>();

            if (script.IsNotEmpty())
            {
                MatchCollection matches = ID_Pattern_RE.Matches(script);
                string id = "";

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        id = match.Value.Between("{", "}");

                        if (id.IsNotEmpty())
                        {
                            result.Add(id);
                        }
                    }
                }
                else if (!script.EndsWith("}"))
                {
                    result.Add(script);
                }
            }

            return result;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ReplaceIDTokens(string script, Control seed)
        {
            script = TokenUtils.ReplaceDirectMethods(script, seed);

            Control control = null;

            string[] parts = null;

            foreach (Match match in ID_Pattern_RE.Matches(script))
            {
                parts = match.Value.Between("{", "}").Split('.');

                control = ControlUtils.FindControl(seed, parts[0]);

                if (control != null)
                {
                    if (parts.Length == 2)
                    {
                        PropertyInfo prop = control.GetType().GetProperty(parts[1]);

                        if (prop != null)
                        {
                            object value = prop.GetValue(control, null);

                            if (value == null)
                            {
                                value = ReflectionUtils.GetDefaultValue(prop);
                            }

                            if (value is string)
                            {
                                string val = TokenUtils.ParseTokens(value.ToString(), control);

                                if (TokenUtils.IsRawToken(val))
                                {
                                    val = JSON.Serialize(TokenUtils.ReplaceRawToken(val)).Chop();
                                }
                                else
                                {
                                    val = JSON.Serialize(val);
                                }

                                script = script.Replace(match.Value, val);
                            }
                            else
                            {
                                script = script.Replace(match.Value, JSON.Serialize(value));
                            }
                        }
                    }
                    else
                    {
                        if (control is Layout)
                        {
                            Component component = ((Layout)control).ParentComponent;
                            script = script.Replace(match.Value, component != null ? component.ClientID.ConcatWith(".getLayout()") : control.ClientID);
                        }
                        else if (control is Observable || control is UserControl)
                        {
                            script = script.Replace(match.Value, control.ClientID);
                        }
                        else
                        {
                            script = script.Replace(match.Value, "Ext.get(\"" + control.ClientID + "\")");
                        }
                    }
                }
                else
                {
                    script = script.Replace(match.Value, "Ext.get(\"" + parts[0] + "\")");
                }
            }

            return script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ReplaceAlertToken(string script)
        {
            if (TokenUtils.IsAlertToken(script))
            {
                script = string.Format(ResourceManager.FunctionTemplate, "Ext.Msg.alert(".ConcatWith(script.Substring(0, script.Length - 1).Substring(2), ");"));
            }

            return script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ReplaceRawToken(string script)
        {
            if (TokenUtils.IsRawToken(script))
            {
                script = script.StartsWith("<raw>") ? script.Substring(5) : script.Between("{", "}");
            }

            return script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ReplaceSelectTokens(string script)
        {
            return Select_Pattern_RE.Replace(script,  new MatchEvaluator(TokenUtils.MatchSelectTokens));
        }

        static string MatchSelectTokens(Match match)
        {
            return "Ext.select(\"".ConcatWith(match.Value.Remove(match.Value.Length - 1).Remove(0, 2), "\")");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ReplaceFunctionToken(string script)
        {
            if (TokenUtils.IsFunctionToken(script))
            {
                script = "function(){".ConcatWith(script.Remove(0, 1).Chop(), "}");
            }

            return script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ParseAndNormalize(string script)
        {
            return TokenUtils.ParseAndNormalize(script, null);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ParseAndNormalize(string script, Control seed)
        {
            return TokenUtils.NormalizeRawToken(TokenUtils.ParseTokens(script, seed));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string NormalizeRawToken(string script)
        {
            if (TokenUtils.IsRawToken(script))
            {
                return TokenUtils.ReplaceRawToken(script);
            }

            return JSON.Serialize(script, JSON.AltConvertersInternal);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static Page Page
        {
            get
            {
                Page page = null;

                if (HttpContext.Current != null && HttpContext.Current.CurrentHandler is Page)
                {
                    page = (Page)HttpContext.Current.CurrentHandler;
                }

                return page;
            }
        }
    }
}