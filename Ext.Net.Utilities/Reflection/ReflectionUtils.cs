/********
 * @version   : 1.0.0
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-06-15
 * @copyright : Copyright (c) 2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI;

namespace Ext.Net.Utilities
{
    public class ReflectionUtils
    {
        public static object GetDefaultValue(PropertyDescriptor property)
        {
            DefaultValueAttribute attr = property.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
            return attr != null ? attr.Value : null;
        }

        public static object GetDefaultValue(PropertyInfo property)
        {
            object[] att = property.GetCustomAttributes(typeof(DefaultValueAttribute), false);
            return att.Length > 0 ? ((DefaultValueAttribute)att[0]).Value : null;
        }

        public static bool IsTypeOf(Object obj, Type type)
        {
            return IsTypeOf(obj, type.FullName, false);
        }

        public static bool IsTypeOf(Object obj, Type type, bool shallow)
        {
            return IsTypeOf(obj, type.FullName, shallow);
        }

        public static bool IsTypeOf(Object obj, string typeFullName)
        {
            return IsTypeOf(obj, typeFullName, false);
        }

        public static bool IsTypeOf(Object obj, string typeFullName, bool shallow)
        {
            if (obj != null)
            {
                if (shallow)
                {
                    return obj.GetType().FullName.Equals(typeFullName);
                }
                else
                {
                    Type type = obj.GetType();
                    string fullName = type.FullName;

                    while (!fullName.Equals("System.Object"))
                    {
                        if (fullName.Equals(typeFullName))
                        {
                            return true;
                        }
                        type = type.BaseType;
                        fullName = type.FullName;
                    }
                }
            }

            return false;
        }

        public static bool IsInTypeOf(Control control, Type type)
        {
            return IsInTypeOf(control, type.FullName);
        }

        public static bool IsInTypeOf(Control control, string typeFullName)
        {
            Control temp = GetTypeOfParent(control, typeFullName);

            return (temp != null);
        }

        public static Control GetTypeOfParent(Control control, Type type)
        {
            return GetTypeOfParent(control, type.FullName);
        }

        public static Control GetTypeOfParent(Control control, string typeFullName)
        {
            for (Control parent = control.Parent; parent != null; parent = parent.Parent)
            {
                if (ReflectionUtils.IsTypeOf(parent, typeFullName))
                {
                    return parent;
                }
            }

            return null;
        }
    }
}