using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace Devenlab.Common.Helpers
{
    public static class DataHelpers
    {
        public static string GetMaskNumber(int value , int l )
        {
            return string.Format (@"{0:D"+ l + @"}", value ) ;
        }

        public static string GetString(double? value)
        {
            return !value.HasValue ? string.Empty : value.Value.ToString(CultureInfo.InvariantCulture);
        }

        public static string GetString(int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public static string GetString(int? value)
        {
            return !value.HasValue ? string.Empty : value.Value.ToString(CultureInfo.InvariantCulture);
        }

        public static string GetString(DateTime? value)
        {
            //return !value.HasValue ? string.Empty : value.Value.ToString();
            return !value.HasValue ? string.Empty : value.Value.ToString(DefaultValue.DEFAULT_FORMAT_DATETIME);
        }

        public static string GetString(DateTime value)
        {
            return value.ToString(DefaultValue.DEFAULT_FORMAT_DATETIME);
        }

        public static string GetString(Boolean? value)
        {
            return !value.HasValue ? string.Empty : value.Value.ToString();
        }

        public static string GetString(Boolean value)
        {
            return value.ToString();
        }

        public static string GetCsv(IEnumerable<IBaseModel> model)
        {
            if (model == null) return string.Empty;
            var list = model.ToList();
            var prop = list[0].GetType().GetProperties();
            var result = new StringBuilder();
            var listproperties = new List<string>();
            foreach (var a in prop)
            {
                result.Append(a.Name + DefaultValue.DEFAULT_SEPARATOR);
                listproperties.Add(a.Name);
            }
            foreach (var a in list )
            {
                foreach (var field in listproperties)
                {
                    var property = a.GetType().GetProperty(field);
                    result.Append(property.GetValue(a, null) + DefaultValue.DEFAULT_SEPARATOR);
                }
            }
            return result.ToString();
        }

        private static readonly Random RandomText = new Random();
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string RandomString(int size)
        {
            var buffer = new char[size];

            for (var i = 0; i < size; i++)
            {
                buffer[i] = CHARS[RandomText.Next(CHARS.Length)];
            }
            return new string(buffer);
        }

        public static string StringUpperCaseSpliter(string value)
        {
            var output = new StringBuilder();

            foreach (char letter in value)
            {
                if (Char.IsUpper(letter) && output.Length > 0)
                    output.Append(" " + letter);
                else
                    output.Append(letter);
            }
            return output.ToString();
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof (T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public static string GetByLengthMax(string value, int max)
        {
            return value.Length < max ? value : value.Substring(0, max);
        }
    }
}
