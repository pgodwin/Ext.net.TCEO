/********
 * @version   : 1.0.0
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-06-15
 * @copyright : Copyright (c) 2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.IO;
using System.Collections;

namespace Ext.Net.Utilities
{
    public class FileUtils
    {
        public static string ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                sr.Close();
                return text;
            }
        }

        public static void WriteFile(string path, string value)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(value);
            sw.Close();
        }

        public static void WriteToStart(string path, string value)
        {
            string temp = ReadFile(path);
            WriteFile(path, value.Trim() + temp.Trim());
        }

        public static void WriteToEnd(string path, string value)
        {
            string temp = ReadFile(path);
            WriteFile(path, temp.Trim() + value.Trim());
        }
    }
}
