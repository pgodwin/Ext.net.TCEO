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

using System;
using System.Globalization;
using Newtonsoft.Json;
using Ext.Net.Utilities;

namespace Ext.Net
{
    // JSONDateTimeJsonConverter based on Newtonsoft.Json.Converters.IsoDateTimeConverter
    // The JSONDateTimeJsonConverter returns the server's local time.
    // Copyright (c) 2007 James Newton-King

    /// <summary>
    /// Converts a <see cref="DateTime" /> to and from the ISO 8601 date format (e.g. 2008-04-12T12:53) using the server
    /// time. Does not adjust for timezone.
    /// </summary>
    public partial class JSONDateTimeJsonConverter : ExtJsonConverter
    {
        private const string DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fff";

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                DateTime date = (DateTime) value;

                if (date != DateTime.MinValue)
                {
                    writer.WriteValue(date.ToString(DateTimeFormat, CultureInfo.InvariantCulture));
                }
                else
                {
                    writer.WriteRawValue("null");
                }

                return;
            }

            writer.WriteRawValue("null");
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">Existing Value</param>
        /// <param name="serializer">Serializer</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw new Exception("Unexpected token parsing date. Expected String, got {0}.".FormatWith(reader.TokenType));

            if (reader.Value.ToString().IsEmpty())
            {
                return null;
            }

            return DateTime.Parse(reader.Value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return (typeof(DateTime).IsAssignableFrom(objectType)
              || typeof(DateTimeOffset).IsAssignableFrom(objectType));
        }
    }
}