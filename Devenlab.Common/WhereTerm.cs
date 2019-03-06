using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devenlab.Common
{
    /// <summary>
    /// Helper class for create dynamic where conditions
    /// </summary>
    public class WhereTerm : IListParameter
    {
        
        public WhereTerm()
        {
            Operator = EnumSqlOperator.Equals;
            ParamDataType = EnumParameterDataTypes.Character;
        }

        /// <summary>
        /// Get value of whereterm
        /// </summary>
        /// <returns>object</returns>
        public object GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Get & set name of table. 
        /// Notes: Must set this property if query using more than 1 table
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Get & set column name. Must set this property for where term sql 
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Get & Set Data type of column
        /// </summary>
        public EnumParameterDataTypes ParamDataType { get; set; }

        /// <summary>
        /// Get & Set Sql operator 
        /// </summary>
        public EnumSqlOperator Operator { get; set; }

        public bool HasValue
        {
            get { return Value != null; }
        }

        /// <summary>
        /// Get & set value of where term
        /// </summary>
        public object Value { get; set; }

        public static WhereTerm AllActiveRow()
        {
            return new WhereTerm
            {
                Value = DefaultValue.ROW_STATUS_ACTIVE,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = EnumSqlOperator.Equals,
                ColumnName = DefaultValue.COLUMN_ROW_STATUS
            };
        }

        public static WhereTerm AllRow()
        {
            return new WhereTerm
            {
                Value = -1,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = EnumSqlOperator.GreatThanEqual,
                ColumnName = DefaultValue.COLUMN_ROW_STATUS
            };
        }

        /// <summary>
        /// To create where term condition with default value TableName = string.Empty, ParamDataType = EnumParamterDataTypes.Character & Operator = SqlOperator.Equals
        /// </summary>
        /// <param name="value">Fill string value of where term</param>
        /// <param name="column">Fill string value of column name</param>
        /// <returns>WhereTerm</returns>
        public static WhereTerm Default(string value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Character,
                Operator = EnumSqlOperator.Equals,
                ColumnName = column
            };
        }

        public static WhereTerm Default(Guid value, string column)
        {
            return new WhereTerm
            {
                Value = value.ToString(),
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Guid,
                Operator = EnumSqlOperator.Equals,
                ColumnName = column
            };
        }

        public static WhereTerm Default(Guid value, string column, EnumSqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value.ToString(),
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Guid,
                Operator = sqlOperator,
                ColumnName = column
            };
        }

        public static WhereTerm Default(string value, string column, string tableName)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = tableName,
                ParamDataType = EnumParameterDataTypes.Character,
                Operator = EnumSqlOperator.Equals,
                ColumnName = column
            };
        }

        /// <summary>
        /// To create where term condition with default value TableName = string.Empty, ParamDataType = EnumParamterDataTypes.DateTime
        /// </summary>
        /// <param name="value">Fill DateTime value of where term</param>
        /// <param name="column">Fill string value of column name</param>
        /// <param name="sqlOperator">Fill sql operator</param>
        /// <returns>WhereTerm</returns>
        public static WhereTerm Default(DateTime value, string column, EnumSqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.DateTime,
                Operator = sqlOperator,
                ColumnName = column
            };
        }

        public static WhereTerm Default(DateTime value, string column, EnumSqlOperator sqlOperator, string tableName)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = tableName,
                ParamDataType = EnumParameterDataTypes.DateTime,
                Operator = sqlOperator,
                ColumnName = column
            };
        }

        /// <summary>
        /// To create where term condition with default value TableName = string.Empty, ParamDataType = EnumParamterDataTypes.DateTime
        /// </summary>
        /// <param name="value">Fill integer value of where term</param>
        /// <param name="column">Fill string value of column name</param>
        /// <param name="sqlOperator">Fill sql operator</param>
        /// <returns>WhereTerm</returns>
        public static WhereTerm Default(int value, string column, EnumSqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = sqlOperator,
                ColumnName = column
            };
        }

        /// <summary>
        /// to create where term condition with default value is decimal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="column"></param>
        /// <param name="sqlOperator"></param>
        /// <returns></returns>
        public static WhereTerm Default(decimal value, string column, EnumSqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = sqlOperator,
                ColumnName = column
            };
        }

        public static WhereTerm Default(Int64 value, string column, EnumSqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = sqlOperator,
                ColumnName = column
            };
        }

        /// <summary>
        /// To create where term condition with default value TableName = string.Empty, ParamDataType = EnumParamterDataTypes.DateTime & Operator = SqlOperator.Equals
        /// </summary>
        /// <param name="value">Fill DateTime value of where term</param>
        /// <param name="column">Fill string value of column name</param>
        /// <returns>WhereTerm</returns>
        public static WhereTerm Default(DateTime value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.DateTime,
                Operator = EnumSqlOperator.Equals,
                ColumnName = column
            };
        }

        /// <summary>
        /// To create where term condition with default value TableName = string.Empty, ParamDataType = EnumParamterDataTypes.Character
        /// </summary>
        /// <param name="value">Fill string value of where term</param>
        /// <param name="column">Fill string value of column name</param>
        /// <param name="sqlOperator">Fill sql operator</param>
        /// <returns>WhereTerm</returns>
        public static WhereTerm Default(string value, string column, EnumSqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Character,
                Operator = sqlOperator,
                ColumnName = column
            };
        }

        /// <summary>
        /// to create where term condition with value is null
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static WhereTerm Default(string column)
        {
            return new WhereTerm
            {
                TableName = string.Empty,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = EnumSqlOperator.IsNull,
                ColumnName = column,
            };
        }

        /// <summary>
        /// To create where term condition with default value TableName = string.Empty, ParamDataType = EnumParamterDataTypes.Bool & Operator = SqlOperator.Equals
        /// </summary>
        /// <param name="value">Fill bool value of where term</param>
        /// <param name="column">Fill string value of column name</param>
        /// <returns>WhereTerm</returns>
        public static WhereTerm Default(bool value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Bool,
                Operator = EnumSqlOperator.Equals,
                ColumnName = column
            };
        }

        /// <summary>
        /// To create where term condition with default value TableName = string.Empty, ParamDataType = EnumParamterDataTypes.Number & Operator = SqlOperator.Equals
        /// </summary>
        /// <param name="value">Fill int value of where term</param>
        /// <param name="column">Fill string value of column name</param>
        /// <returns>WhereTerm</returns>
        public static WhereTerm Default(int value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = EnumSqlOperator.Equals,
                ColumnName = column
            };
        }

        public static IListParameter Default(object value, string column, string table)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = table,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = EnumSqlOperator.Equals,
                ColumnName = column
            };
        }

        public static IListParameter[] GetParameters(IListParameter[] parameter, params IListParameter[] parameters)
        {
            if (parameter == null)
            {
                return parameters;
            }
            var a = parameter.ToList();
            a.AddRange(parameters);
            return a.ToArray();
        }

        public static bool ResizeParameter(ref IListParameter[] parameters, int size)
        {
            var hasRowParams = false;
            if (parameters == null)
            {
                Array.Resize(ref parameters, size);
            }
            else
            {
                if (parameters.Any(param => param.ColumnName.Equals(DefaultValue.COLUMN_ROW_STATUS)))
                    hasRowParams = true;
                if (!hasRowParams)
                    Array.Resize(ref parameters, parameters.Length + size);
            }
            return hasRowParams;
        }

        public static IListParameter Default(int value, string column, EnumSqlOperator sqlOperator, string tableName)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = tableName,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = sqlOperator,
                ColumnName = column
            };
        }

        public static string GetParamaterForMessage(params IListParameter[] parameters)
        {
            var sb = new StringBuilder();
            foreach (var listParameter in parameters)
            {
                sb.AppendLine(string.Format("Column: {0}Value: {1}",
                                            listParameter.ColumnName, listParameter.Value));
                //sb.AppendLine(string.Format("Column: {0}|Value: {1}|TableName:{2}|Operator:{3}|DataType:{4}",
                //                            listParameter.ColumnName, listParameter.GetValue(), listParameter.TableName,
                //                            listParameter.Operator, listParameter.ParamDataType));
            }
            return sb.ToString();
        }
    }
}
