﻿using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devenlab.Common
{
    public class WhereTermDateTimeRange : IListRangeParameter
    {
        public EnumParameterDataTypes ParamDataType { get; set; }
        public WhereTermDateTimeRange(DateTime? date1, DateTime? date2)
        {
            Value1 = date1;
            Value2 = date2;
        }

        public WhereTermDateTimeRange()
        {
            Value1 = null;
            Value2 = null;
        }

        public object GetValue()
        {
            return Value1;
        }

        public static WhereTermDateTimeRange Parameter(DateTime v1, DateTime v2, string column)
        {
            return new WhereTermDateTimeRange(v1, v2)
            {
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.DateTimeRange,
                Operator = EnumSqlOperator.Equals,
                ColumnName = column,
                ColumnName2 = column
            };
        }

        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public EnumSqlOperator Operator { get; set; }
        public bool HasValue
        {
            get { return Value1 != null; }
        }

        public object Value { get; set; }

        public object GetValue2()
        {
            return Value2;
        }
        public DateTime? Value1 { get; set; }
        public DateTime? Value2 { get; set; }
        public string TableName2 { get; set; }
        public string ColumnName2 { get; set; }
        public bool HasValue2 { get { return Value2 != null; } }
    }
}
