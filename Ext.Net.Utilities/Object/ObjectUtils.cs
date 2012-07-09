/********
 * @version   : 1.0.0
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-06-15
 * @copyright : Copyright (c) 2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Reflection;
using System;
using System.ComponentModel;

namespace Ext.Net.Utilities
{
    public static class ObjectUtils
    {
        public static bool IsNull(this object instance)
        {
            return instance == null;
        }

        public static T Apply<T>(object to, object from) where T : IComponent
        {
            return (T)ObjectUtils.Apply(to, from);
        }

        public static object Apply(object to, object from)
        {
            return ObjectUtils.Apply(to, from, true);
        }

        public static object Apply(object to, object from, bool ignoreDefaultValues)
        {
            PropertyInfo toProperty;

            object fromValue = null;
            object defaultValue = null;

            foreach (PropertyInfo fromProperty in from.GetType().GetProperties())
            {
                if (fromProperty.CanRead)
                {
                    fromValue = fromProperty.GetValue(from, null);

                    if (ignoreDefaultValues)
                    {
                        defaultValue = ReflectionUtils.GetDefaultValue(fromProperty);

                        if (fromValue != null && fromValue.Equals(defaultValue))
                        {
                            continue;
                        }
                    }

                    if (fromValue != null)
                    {
                        toProperty = to.GetType().GetProperty(fromProperty.Name, BindingFlags.Instance | BindingFlags.Public);

                        if (toProperty != null && toProperty.CanWrite && toProperty != null && toProperty.GetType().Equals(fromProperty.GetType()))
                        {
                            toProperty.SetValue(to, fromValue, null);
                        }
                    }
                }
            }

            return to;
        }
    }
}