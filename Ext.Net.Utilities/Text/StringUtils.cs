/********
 * @version   : 1.0.0
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-06-15
 * @copyright : Copyright (c) 2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace Ext.Net.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public static class StringUtils
    {
        /// <summary>
        /// Replaces all occurrences of System.String in the oldValues String Array, with
        /// another specified System.String of newValue.
        /// </summary>
        /// <param name="instance">this string</param>
        /// <param name="oldValues">An Array of String objects to be replaced.</param>
        /// <param name="newValue">The new value to replace old values.</param>
        /// <returns>
        /// The modified original string.
        /// </returns>
        [Description("Replaces all occurrences of System.String in the oldValues String Array, with another specified System.String of newValue.")]
        public static string Replace(this string instance, string[] oldValues, string newValue)
        {
            if (oldValues == null || oldValues.Length < 1)
            {
                return instance;
            }

            oldValues.Each<string>(value => instance.Replace(value, newValue));

            return instance;
        }

        /// <summary>
        /// Replaces all occurrences of System.String in the oldValue String Array, with the
        /// return String value of the specified Function convert.
        /// </summary>
        /// <param name="instance">this string</param>
        /// <param name="oldValues">An Array of String objects to be replaced.</param>
        /// <param name="convert">The Function to convert the found old value.</param>
        /// <returns>
        /// The modified original string.
        /// </returns>
        [Description("Replaces all occurrences of System.String in the oldValue String Array, with the return String value of the specified Function convert.")]
        public static string Replace(this string instance, string[] oldValues, Func<string, string> convert)
        {
            if (oldValues == null || oldValues.Length < 1)
            {
                return instance;
            }

            oldValues.Each<string>(value => instance = instance.Replace(value, convert(value)));

            return instance;
        }

        /// <summary>
        /// Format the string with the arguments (args parameter).
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        [Description("Format the string with the arguments (args parameter).")]
        public static string FormatWith(this string format, params object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(string.Format("The args parameter can not be null when calling {0}.FormatWith().", format));
            }

            return string.Format(format, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <param name="args"></param>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            Verify.IsNotNull(format, "format");

            return string.Format(provider, format, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, object source)
        {
            return format.FormatWith(null, source);
        }

        /// http://james.newtonking.com/archive/2008/03/29/formatwith-2-0-string-formatting-with-named-variables.aspx
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        [Description("")]
        public static string FormatWith(this string format, IFormatProvider provider, object source)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            List<object> values = new List<object>();

            string rewrittenFormat = Regex.Replace(format,
                @"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+",
                delegate(Match m)
                {
                    Group startGroup = m.Groups["start"];
                    Group propertyGroup = m.Groups["property"];
                    Group formatGroup = m.Groups["format"];
                    Group endGroup = m.Groups["end"];

                    values.Add((propertyGroup.Value == "0")
                      ? source
                      : Eval(source, propertyGroup.Value));

                    int openings = startGroup.Captures.Count;
                    int closings = endGroup.Captures.Count;

                    return openings > closings || openings % 2 == 0
                         ? m.Value
                         : new string('{', openings) + (values.Count - 1) + formatGroup.Value + new string('}', closings);
                },
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            return string.Format(provider, rewrittenFormat, values.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static object Eval(object source, string expression)
        {
            try
            {
                return DataBinder.Eval(source, expression);
            }
            catch (HttpException e)
            {
                throw new FormatException(null, e);
            }
        }

        /// <summary>
        /// Add the args strings the source text string.
        /// </summary>
        public static string ConcatWith(this string instance, string text)
        {
            return string.Concat(instance, text);
        }

        /// <summary>
        /// Add the args strings the source text string.
        /// </summary>
        public static string ConcatWith(this string instance, params object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(string.Format("The args parameter can not be null when calling {0}.Format().", instance));
            }

            return string.Concat(instance, string.Concat(args));
        }

        /// <summary>
        /// Determines if the string contains any of the args. If yes, returns true, otherwise returns false.
        /// </summary>
        /// <param name="instance">The instance of the string</param>
        /// <param name="args">The string to check if contained within the string instance.</param>
        /// <returns>boolean</returns>
        public static bool Contains(this string instance, params string[] args)
        {
            foreach (string s in args)
            {
                if (instance.Contains(s))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determine is the string is null or empty.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// Determine is the string is NOT null or empty.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string text)
        {
            return !text.IsEmpty();
        }

        /// <summary>
        /// Return a string from between the start and end positions. 
        /// </summary>
        [Description("Return a sub array of this string array.")]
        public static string Between(this string text, string start, string end)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            return text.RightOf(start).LeftOfRightmostOf(end);
        }

        /// <summary>
        /// Return a sub array of this string array.
        /// </summary>
        [Description("Return a sub array of this string array.")]
        public static string[] Subarray(this string[] items, int start)
        {
            return items.Subarray(start, items.Length - start);
        }

        /// <summary>
        /// Return a sub array of this string array.
        /// </summary>
        [Description("Return a sub array of this string array.")]
        public static string[] Subarray(this string[] items, int start, int length)
        {
            if (start > items.Length)
            {
                throw new ArgumentException(string.Format("The start index [{0}] is greater than the length [{1}] of the array.", start, items.Length));
            }

            if ((start + length) > items.Length)
            {
                throw new ArgumentException(string.Format("The length [{0}] to return is greater than the length [{1}] of the array.", length, items.Length));
            }

            string[] temp = new string[length];

            int count = 0;

            for (int i = start; i < start + length; i++)
            {
                temp[count] = items[i];
                count++;
            }

            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable items)
        {
            return items.Join(",", "{0}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable items, string separator)
        {
            return items.Join(separator, "{0}");
        }

        /// <summary>
        /// Join the items together
        /// </summary>
        /// <param name="items">The items to join.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="template">The template to format the items with.</param>
        /// <returns></returns>
        public static string Join(this IEnumerable items, string separator, string template)
        {
            StringBuilder sb = new StringBuilder();

            foreach (object item in items)
            {
                if (item != null)
                {
                    sb.Append(separator);
                    sb.Append(string.Format(template, item.ToString()));
                }
            }

            return sb.ToString().RightOf(separator);
        }

        /// <summary>
        /// Chops one character from each end of string.
        /// </summary>
        public static string Chop(this string text)
        {
            return text.Chop(1);
        }

        /// <summary>
        /// Chops the specified number of characters from each end of string. 
        /// </summary>
        public static string Chop(this string text, int characters)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            return text.Substring(characters, text.Length - characters - 1);
        }

        /// <summary>
        /// Chops the specified string from each end of the string. If the character does not exist on both ends 
        /// of the string, the characters are not chopped.
        /// </summary>
        public static string Chop(this string text, string character)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            if (text.StartsWith(character) && text.EndsWith(character))
            {
                int length = character.Length;
                return text.Substring(length, text.Length - (length + 1));
            }

            return text;
        }

        /// <summary>
        /// MD5Hash's a string. 
        /// </summary>
        public static string ToMD5Hash(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text.Trim());
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts the first character of each word to Uppercase. Example: "the lazy dog" returns "The Lazy Dog"
        /// </summary>
        /// <param name="text">The text to convert to sentence case</param>
        public static string ToTitleCase(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            return text.Split(' ').ToTitleCase();
        }

        /// <summary>
        /// Converts the first character of each word to Uppercase. Example: "the lazy dog" returns "The Lazy Dog"
        /// </summary>
        /// <param name="text">The text to convert to sentence case</param>
        public static string ToTitleCase(this string text, CultureInfo ci)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            return text.Split(' ').ToTitleCase(ci);
        }

        /// <summary>
        /// Converts the first character of each word to Uppercase. Example: "the lazy dog" returns "The Lazy Dog"
        /// </summary>
        public static string ToTitleCase(this string[] words)
        {
            return words.ToTitleCase(null);
        }

        /// <summary>
        /// Converts the first character of each word to Uppercase. Example: "the lazy dog" returns "The Lazy Dog"
        /// </summary>
        public static string ToTitleCase(this string[] words, CultureInfo ci)
        {
            if (words == null || words.Length == 0)
            {
                return "";
            }

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = (ci != null ? char.ToUpper(words[i][0], ci) : char.ToUpper(words[i][0])) + words[i].Substring(1);
            }

            return string.Join(" ", words);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsLowerCamelCase(this string text)
        {
            if (text.IsEmpty())
            {
                return false;
            }

            return text.Substring(0, 1).ToLowerInvariant().Equals(text.Substring(0, 1));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToLowerCamelCase(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            return text.Substring(0, 1).ToLower(CultureInfo.InvariantCulture) + text.Substring(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string ToLowerCamelCase(this string[] values)
        {
            if (values == null || values.Length == 0)
            {
                return "";
            }

            return values.ToLowerCamelCase();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            return text.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + text.Substring(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string[] values, string separator)
        {
            string temp = "";

            foreach (string s in values)
            {
                temp += separator;
                temp += ToCamelCase(s);
            }
            
            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string[] values)
        {
            return values.ToCamelCase("");
        }

        /// <summary>
        /// Pad the left side of a string with characters to make the total length.
        /// </summary>
        public static string PadLeft(this string text, char c, Int32 totalLength)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            if (totalLength < text.Length)
            {
                return text;
            }

            return new String(c, totalLength - text.Length) + text;
        }

        /// <summary>
        /// Pad the right side of a string with a '0' if a single character.
        /// </summary>
        public static string PadRight(this string text)
        {
            return PadRight(text, '0', 2);
        }

        /// <summary>
        /// Pad the right side of a string with characters to make the total length.
        /// </summary>
        public static string PadRight(this string text, char c, Int32 totalLength)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            if (totalLength < text.Length)
            {
                return text;
            }

            return string.Concat(text, new String(c, totalLength - text.Length));
        }

        /// <summary>
        /// Left of the first occurance of c
        /// </summary>
        public static string LeftOf(this string text, char c)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = text.IndexOf(c);
            
            if (i == -1)
            {
                return text;
            }

            return text.Substring(0, i);
        }

        /// <summary>
        /// Left of the first occurance of text
        /// </summary>
        public static string LeftOf(this string text, string value)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = text.IndexOf(value);
            
            if (i == -1)
            {
                return text;
            }

            return text.Substring(0, i);
        }

        /// <summary>
        /// Left of the n'th occurance of c
        /// </summary>
        public static string LeftOf(this string text, char c, int n)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = -1;
            
            while (n != 0)
            {
                i = text.IndexOf(c, i + 1);
                if (i == -1)
                {
                    return text;
                }
                --n;
            }
            
            return text.Substring(0, i);
        }

        /// <summary>
        /// Right of the first occurance of c
        /// </summary>
        public static string RightOf(this string text, char c)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = text.IndexOf(c);
            
            if (i == -1)
            {
                return "";
            }
            
            return text.Substring(i + 1);
        }

        /// <summary>
        /// Right of the first occurance of text
        /// </summary>
        public static string RightOf(this string text, string value)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = text.IndexOf(value);
            
            if (i == -1)
            {
                return "";
            }
            
            return text.Substring(i + value.Length);
        }

        /// <summary>
        /// Right of the n'th occurance of c
        /// </summary>
        public static string RightOf(this string text, char c, int n)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = -1;
            
            while (n != 0)
            {
                i = text.IndexOf(c, i + 1);
                if (i == -1)
                {
                    return "";
                }
                --n;
            }
            
            return text.Substring(i + 1);
        }

        /// <summary>
        /// Right of the n'th occurance of c
        /// </summary>
        public static string RightOf(this string text, string c, int n)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = -1;
            
            while (n != 0)
            {
                i = text.IndexOf(c, i + 1);
                if (i == -1)
                {
                    return "";
                }
                --n;
            }
            
            return text.Substring(i + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string LeftOfRightmostOf(this string text, char c)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = text.LastIndexOf(c);
            
            if (i == -1)
            {
                return text;
            }
            
            return text.Substring(0, i);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string LeftOfRightmostOf(this string text, string value)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = text.LastIndexOf(value);
            
            if (i == -1)
            {
                return text;
            }
            
            return text.Substring(0, i);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string RightOfRightmostOf(this string text, char c)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = text.LastIndexOf(c);
            
            if (i == -1)
            {
                return text;
            }
            
            return text.Substring(i + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RightOfRightmostOf(this string text, string value)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            int i = text.LastIndexOf(value);
            
            if (i == -1)
            {
                return text;
            }
            
            return text.Substring(i + value.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceLastInstanceOf(this string text, string oldValue, string newValue)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            return string.Format("{0}{1}{2}", text.LeftOfRightmostOf(oldValue), newValue, text.RightOfRightmostOf(oldValue));
        }

        /// <summary>
        /// Accepts a string like "ArrowRotateClockwise" and returns "arrow_rotate_clockwise.png".
        /// </summary>
        public static string ToCharacterSeparatedFileName(this string name, char separator, string extension)
        {
            if (name.IsEmpty())
            {
                return name;
            }

            MatchCollection match = Regex.Matches(name, @"([A-Z]+)[a-z]*|\d{1,}[a-z]{0,}");

            string temp = "";
            
            for (int i = 0; i < match.Count; i++)
            {
                if (i != 0)
                {
                    temp += separator;
                }
                
                temp += match[i].ToString().ToLowerInvariant();
            }
            
            string format = (string.IsNullOrEmpty(extension)) ? "{0}{1}" : "{0}.{1}";
            
            return string.Format(format, temp, extension);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Enquote(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            
            int i;
            int len = text.Length;
            StringBuilder sb = new StringBuilder(len + 4);
            string t;

            for (i = 0; i < len; i += 1)
            {
                char c = text[i];
                if ((c == '\\') || (c == '"') || (c == '>'))
                {
                    sb.Append('\\');
                    sb.Append(c);
                }
                else if (c == '\b')
                    sb.Append("\\b");
                else if (c == '\t')
                    sb.Append("\\t");
                else if (c == '\n')
                    sb.Append("\\n");
                else if (c == '\f')
                    sb.Append("\\f");
                else if (c == '\r')
                    sb.Append("\\r");
                else
                {
                    if (c < ' ')
                    {
                        string tmp = new string(c, 1);
                        t = "000" + int.Parse(tmp, System.Globalization.NumberStyles.HexNumber);
                        sb.Append("\\u" + t.Substring(t.Length - 4));
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EnsureSemiColon(this string text)
        {
            if (text.IsEmpty())
            {
                return text;
            }

            return (string.IsNullOrEmpty(text) || text.EndsWith(";")) ? text : string.Concat(text, ";");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="wrapByText"></param>
        /// <returns></returns>
        public static string Wrap(this string text, string wrapByText)
        {
            if (text == null)
            {
                text = "";
            }

            return wrapByText.ConcatWith(text, wrapByText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="wrapStart"></param>
        /// <param name="wrapEnd"></param>
        /// <returns></returns>
        public static string Wrap(this string text, string wrapStart, string wrapEnd)
        {
            if (text == null)
            {
                text = "";
            }

            return wrapStart.ConcatWith(text, wrapEnd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool Test(this string text, string pattern)
        {
            return Regex.IsMatch(text, pattern);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool Test(this string text, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(text, pattern, options);
        }

        /// <summary>
        /// Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length
        /// </summary>
        /// <param name="text">The string to truncate</param>
        /// <param name="length">The maximum length to allow before truncating</param>
        /// <returns>The converted text</returns>
        public static string Ellipsis(this string text, int length)
        {
            return StringUtils.Ellipsis(text, length, false);
        }

        /// <summary>
        /// Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length
        /// </summary>
        /// <param name="text">The string to truncate</param>
        /// <param name="length">The maximum length to allow before truncating</param>
        /// <param name="word">True to try to find a common work break</param>
        /// <returns>The converted text</returns>
        public static string Ellipsis(this string text, int length, bool word)
        {
            if (text != null && text.Length > length)
            {
                if (word)
                {
                    string vs = text.Substring(0, length - 2);
                    int index = Math.Max(vs.LastIndexOf(' '), Math.Max(vs.LastIndexOf('.'), Math.Max(vs.LastIndexOf('!'), vs.LastIndexOf('?'))));
                    
                    if (index == -1 || index < (length - 15))
                    {
                        return text.Substring(0, length - 3) + "...";
                    }
                    
                    return vs.Substring(0, index) + "...";
                }
                
                return text.Substring(0, length - 3) + "...";
            }
            return text;
        }

        /// <summary>
        /// Base64 string decoder
        /// </summary>
        /// <param name="text">The text string to decode</param>
        /// <returns>The decoded string</returns>
        public static string Base64Decode(this string text)
        {
            Decoder decoder = new UTF8Encoding().GetDecoder();

            byte[] bytes = Convert.FromBase64String(text);
            char[] chars = new char[decoder.GetCharCount(bytes, 0, bytes.Length)];

            decoder.GetChars(bytes, 0, bytes.Length, chars, 0);

            return new String(chars);
        }

        /// <summary>
        /// Base64 string encoder
        /// </summary>
        /// <param name="text">The text string to encode</param>
        /// <returns>The encoded string</returns>
        public static string Base64Encode(this string text)
        {
            byte[] bytes = new byte[text.Length];
            bytes = Encoding.UTF8.GetBytes(text);
            
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static string FormatRegexPattern(this string regex)
        {
            if (!regex.StartsWith("/", StringComparison.InvariantCulture))
            {
                regex = "/{0}".FormatWith(regex);
            }

            if (!regex.EndsWith("/", StringComparison.InvariantCulture))
            {
                regex = "{0}/".FormatWith(regex);
            }

            return regex;
        }

        private static readonly Random random = new Random();

        /// <summary>
        /// Generate a random string of character at a certain length
        /// </summary>
        /// <param name="chars">The Characters to use in the random string</param>
        /// <param name="length">The length of the random string</param>
        /// <returns>A string of random characters</returns>
        public static string Randomize(this string chars, int length)
        {
            char[] buf = new char[length];

            for (int i = 0; i < length; i++)
            {
                buf[i] = chars[StringUtils.random.Next(chars.Length)];
            }

            return new string(buf);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string Randomize(this string chars)
        {
            return chars.Randomize(chars.Length);
        }
    }
}