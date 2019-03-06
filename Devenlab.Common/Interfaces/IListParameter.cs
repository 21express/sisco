using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devenlab.Common.Interfaces
{
    public interface IListParameter
    {
        EnumParameterDataTypes ParamDataType { get; set; }
        string TableName { get; set; }
        string ColumnName { get; set; }
        EnumSqlOperator Operator { get; set; }
        bool HasValue { get; }
        object Value { get; set; }
    }
}
