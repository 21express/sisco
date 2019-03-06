using Devenlab.Common.Helpers;
using Devenlab.Common.Interfaces;
using K.Common.Fault;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Devenlab.Common.Patterns
{
    public abstract class BaseRepository : IBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        const string DATA_PROTECTION_PROVIDER = "DataProtectionConfigurationProvider";
        // ReSharper disable once InconsistentNaming
        public static string connStr = string.Empty;//public string ConnectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["CurrentConnection"]].ConnectionString;

        public abstract void Dispose();

        public abstract void Save<T>(T businessModel) where T : IBaseModel;
        public abstract void Update<T>(T businessModel) where T : IBaseModel;
        public abstract void Update<T>(T businessModel, params IListParameter[] parameter) where T : IBaseModel;
        public abstract void DeActive(int id, string userName, DateTime deleteDate);
        public abstract void Delete(int id);
        public abstract IEnumerable<T> Get<T>(params IListParameter[] parameter) where T : IBaseModel;
        public abstract T GetSingle<T>(params IListParameter[] parameter) where T : IBaseModel;
        public abstract IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter) where T : IBaseModel;

        public string ObjectName { get; set; }
        public IListParameter[] DefaultParameters { set; get; }
        public bool _withoutDefault { get; set; }

        public string ConnectionString
        {
            get { return connStr; }
            set { connStr = value; }
        }

        public string MessageEntityNull
        {
            get { return string.Format("{0} Entity is NULL", ObjectName); }
        }

        public string MessageModelNull
        {
            get { return string.Format("{0} Model is NULL", ObjectName); }
        }

        public string MessageEntityNotFound
        {
            get { return string.Format("{0} - Data {1} Tidak ditemukan", ErrorList.RECORD_NOT_FOUND, ObjectName); }
        }

        public void ValidateSorting(ref string sort, ref string dir)
        {
            if (string.IsNullOrEmpty(sort))
                sort = "Id";
            if (string.IsNullOrEmpty(dir))
                dir = "DESC";
        }

        public Collection<object> ListValue { get; set; }
        public Collection<string> ListClause { get; set; }

        public string GetQueryParameterLinq(params IListParameter[] parameters)
        {
            var hasRowParams = WhereTerm.ResizeParameter(ref parameters, 1);
            if (!hasRowParams)
            {
                if (!_withoutDefault)
                    parameters[parameters.Length - 1] = WhereTerm.Default(true, DefaultValue.COLUMN_ROW_STATUS);
                else
                    parameters[parameters.Length - 1] = WhereTerm.Default(0, "0", EnumSqlOperator.Equals);
            }

            if (DefaultParameters != null)
            {
                foreach (var listParameter in DefaultParameters)
                {
                    var @where = (WhereTerm)listParameter;
                    Array.Resize(ref parameters, parameters.Length + 1);
                    parameters[parameters.Length - 1] = where;
                }
            }

            var query = new StringBuilder();
            ListValue = new Collection<object>();
            ListClause = new Collection<string>();

            var indexpass = 0;
            foreach (var param in parameters)
            {
                var index = parameters.ToList().IndexOf(param) + indexpass;
                
                switch (param.ParamDataType)
                {
                    case EnumParameterDataTypes.DateTime:
                        {
                            var date1 = Convert.ToDateTime(param.Value);
                            var fdate = new DateTime(date1.Year, date1.Month, date1.Day, 0, 0, 0);
                            var ldate = new DateTime(date1.Year, date1.Month, date1.Day, 23, 59, 59);
                            if (param.Operator == EnumSqlOperator.Equals)
                            {
                                var fparma = WhereTerm.Default(fdate, param.ColumnName, EnumSqlOperator.GreatThanEqual);
                                var lparma = WhereTerm.Default(ldate, param.ColumnName, EnumSqlOperator.LesThanEqual);
                                query.Append(GetValueParameterLinq(fparma, index) + DefaultValue.LOGICAL_SQL);
                                ListValue.Add(fparma.GetValue());
                                index++;
                                indexpass++;
                                query.Append(GetValueParameterLinq(lparma, index) + DefaultValue.LOGICAL_SQL);
                                ListValue.Add(lparma.GetValue());
                            }
                            else
                            {
                                query.Append(GetValueParameterLinq(param, index) + DefaultValue.LOGICAL_SQL);
                                ListValue.Add(date1);
                            }

                            GetValueClause(param);
                        }
                        break;
                    case EnumParameterDataTypes.DateTimeRange:
                        {
                            query.Append(GetValueParameterLinq(param, index) + DefaultValue.LOGICAL_SQL);
                            ListValue.Add(param.Value);
                            var date1 = Convert.ToDateTime(((IListRangeParameter)param).GetValue2());
                            //var ldate = new DateTime(date1.Year, date1.Month, date1.Day, 23, 59, 59);
                            ListValue.Add(date1);
                            indexpass++;
                        }
                        break;
                    case EnumParameterDataTypes.Guid:
                        query.Append(GetValueParameterLinq(param, index) + DefaultValue.LOGICAL_SQL);
                        ListValue.Add(new Guid(param.Value.ToString()));
                        break;
                    default:
                        query.Append(GetValueParameterLinq(param, index) + DefaultValue.LOGICAL_SQL);
                        ListValue.Add(param.Value);
                        GetValueClause(param);
                        break;
                }
            }
            if (query.Length != 0)
            {

                var qresult = query.ToString().Trim();
                if (qresult.Substring(qresult.Length - 3, 3) == DefaultValue.LOGICAL_SQL.Trim())
                {
                    qresult = qresult.Remove(qresult.Length - 3, 3);
                }
                return qresult;
            }
            return query.ToString();
        }

        public string GetQueryParameterLinqRaw(string expression, ref object[] parameters)
        {
            if (parameters != null)
            {
                Array.Resize(ref parameters, parameters.Length + 1);
                expression = string.Format("({0}) AND ({1} = @{2})", expression, DefaultValue.COLUMN_ROW_STATUS,
                    parameters.Length - 1);
                parameters[parameters.Length - 1] = true;
            }

            return expression;
        }

        public string GetQueryParameterLinqNoRowStatus(IListParameter defaultParameter, params IListParameter[] parameters)
        {
            if (defaultParameter != null)
            {
                var hasRowParams = WhereTerm.ResizeParameter(ref parameters, 1);
                if (!hasRowParams)
                    parameters[parameters.Length - 1] = defaultParameter;
            }


            var query = new StringBuilder();
            ListValue = new Collection<object>();
            var indexpass = 0;
            foreach (var param in parameters)
            {
                var index = parameters.ToList().IndexOf(param) + indexpass;
                switch (param.ParamDataType)
                {
                    case EnumParameterDataTypes.DateTime:
                        {
                            var date1 = Convert.ToDateTime(param.Value);
                            var fdate = new DateTime(date1.Year, date1.Month, date1.Day, 0, 0, 0);
                            var ldate = new DateTime(date1.Year, date1.Month, date1.Day, 23, 59, 59);
                            if (param.Operator == EnumSqlOperator.Equals)
                            {
                                var fparma = WhereTerm.Default(fdate, param.ColumnName, EnumSqlOperator.GreatThanEqual);
                                var lparma = WhereTerm.Default(ldate, param.ColumnName, EnumSqlOperator.LesThanEqual);
                                query.Append(GetValueParameterLinq(fparma, index) + DefaultValue.LOGICAL_SQL);
                                ListValue.Add(fparma.GetValue());
                                index++;
                                indexpass++;
                                query.Append(GetValueParameterLinq(lparma, index) + DefaultValue.LOGICAL_SQL);
                                ListValue.Add(lparma.GetValue());
                            }
                            else
                            {
                                query.Append(GetValueParameterLinq(param, index) + DefaultValue.LOGICAL_SQL);
                            }
                        }
                        break;
                    case EnumParameterDataTypes.DateTimeRange:
                        {
                            query.Append(GetValueParameterLinq(param, index) + DefaultValue.LOGICAL_SQL);
                            ListValue.Add(param.Value);
                            var date1 = Convert.ToDateTime(((IListRangeParameter)param).GetValue2());
                            //var ldate = new DateTime(date1.Year, date1.Month, date1.Day, 23, 59, 59);
                            ListValue.Add(date1);
                            indexpass++;
                        }
                        break;
                    case EnumParameterDataTypes.Guid:
                        query.Append(GetValueParameterLinq(param, index) + DefaultValue.LOGICAL_SQL);
                        ListValue.Add(new Guid(param.Value.ToString()));
                        break;
                    default:
                        query.Append(GetValueParameterLinq(param, index) + DefaultValue.LOGICAL_SQL);
                        ListValue.Add(param.Value);
                        break;
                }
            }
            if (query.Length != 0)
            {

                var qresult = query.ToString().Trim();
                if (qresult.Substring(qresult.Length - 3, 3) == DefaultValue.LOGICAL_SQL.Trim())
                {
                    qresult = qresult.Remove(qresult.Length - 3, 3);
                }
                return qresult;
            }
            return query.ToString();
        }

        private void GetValueClause(IListParameter param)
        {
            switch (param.ParamDataType)
            {
                case EnumParameterDataTypes.Number:
                case EnumParameterDataTypes.NumberRange:
                    ListClause.Add(string.Format("{0} {1} {2}", param.ColumnName, GetOperatorClause(param.Operator), param.Value));
                    break;
                case EnumParameterDataTypes.DateTime:
                    ListClause.Add(string.Format("{0} {1} '{2}'", param.ColumnName, GetOperatorClause(param.Operator), Convert.ToDateTime(param.Value).ToString("yyyy-MM-dd HH:mm:ss")));
                    break;
                case EnumParameterDataTypes.Character:
                    ListClause.Add(string.Format("{0} {1} '{2}'", param.ColumnName, GetOperatorClause(param.Operator), param.Value));
                    break;
                case EnumParameterDataTypes.Bool:
                    ListClause.Add(string.Format("{0} {1} {2}", param.ColumnName, GetOperatorClause(param.Operator), Convert.ToByte(param.Value)));
                    break;
            }
        }

        /// <summary>
        /// {0} Table Name
        /// {1} Column Name
        /// {2} Operator
        /// </summary>
        /// <param name="param"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static string GetValueParameterLinq(IListParameter param, int index)
        {
            switch (param.ParamDataType)
            {
                case EnumParameterDataTypes.Number:
                    return GetNumericLinq(param, index);
                case EnumParameterDataTypes.NumberRange:
                    return GetNumericLinq(param, index);
                case EnumParameterDataTypes.DateTime:
                    return GetDateTimeLinq(param, index);
                case EnumParameterDataTypes.DateTimeRange:
                    return GetDateTimeRangeLinq(param as IListRangeParameter, index);
                case EnumParameterDataTypes.Bool:
                    return GetBooleanLinq(param, index);
                case EnumParameterDataTypes.Guid:
                    return GetGuidLinq(param, index);
                default:
                    return GetCharacterLinq(param, index);
            }
        }

        private static string GetGuidLinq(IListParameter param, int index)
        {
            return string.Format(" ({0}{1}{2}) ",
                                 string.Empty,
                                 param.ColumnName, GetOperatorGuidLinq(index));
        }

        private static StringBuilder GetOperatorGuidLinq(int index)
        {
            return new StringBuilder().AppendFormat(".Equals(@{0})", index);
        }

        /// <summary>
        /// {0} Table Name
        /// {1} Column Name
        /// {2} Operator
        /// </summary>
        /// <param name="param"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static string GetCharacterLinq(IListParameter param, int index)
        {
            return string.Format(" ({0}{1}{2}) ", string.IsNullOrEmpty(param.TableName) ? string.Empty : param.TableName + ".", param.ColumnName, GetOperatorCharacterLinq(param.Operator, index));
        }

        private static string GetOperatorCharacterLinq(EnumSqlOperator @operator, int param)
        {
            switch (@operator)
            {
                case EnumSqlOperator.NotEqual:
                    return string.Format("<> @{0}", param);
                case EnumSqlOperator.GreatThan:
                    return string.Format("> @{0}", param);
                case EnumSqlOperator.GreatThanEqual:
                    return string.Format(">= @{0}", param);
                case EnumSqlOperator.LessThan:
                    return string.Format("< @{0}", param);
                case EnumSqlOperator.LesThanEqual:
                    return string.Format("<= @{0}", param);
                case EnumSqlOperator.BeginWith:
                    return string.Format(".StartsWith(@{0})", param);
                case EnumSqlOperator.EndWith:
                    return string.Format(".EndsWith(@{0})", param);
                case EnumSqlOperator.Like:
                    return string.Format(".Contains(@{0})", param);
                default:
                    return string.Format(".Equals(@{0})", param);
            }
        }

        private static string GetBooleanLinq(IListParameter control, int index)
        {
            return string.Format(" ({0}{1} {2}) ",
                                 string.Empty,
                                 control.ColumnName, GetOperatorBooleanLinq(control.Operator, index));
        }

        private static string GetOperatorBooleanLinq(EnumSqlOperator sqlOperator, int index)
        {
            switch (sqlOperator)
            {
                case EnumSqlOperator.NotEqual:
                    return string.Format("!= @{0}", index);
                default:
                    return string.Format("= @{0}", index);
            }
        }

        private static string GetDateTimeRangeLinq(IListRangeParameter rangecontrol, int index)
        {
            if (rangecontrol == null) return null;
            return string.Format(" ({0} {1} @{2} AND {3} {4} @{5})",
                                 rangecontrol.ColumnName, ">=",
                                 index,
                                  rangecontrol.ColumnName2, "<=",
                                 index + 1);
        }

        private static string GetDateTimeLinq(IListParameter param, int index)
        {
            //return string.Format(" ({0}{1}{2}) ", (string.IsNullOrEmpty(param.TableName) ? string.Empty : param.TableName + DefaultValue.DOT),
            //    param.ColumnName, GetOperatorDateTimeLinq(param.Operator, index));
            return string.Format(" ({0}{1}{2}) ", string.Empty,
                param.ColumnName, GetOperatorDateTimeLinq(param.Operator, index));
        }

        private static object GetOperatorDateTimeLinq(EnumSqlOperator sqlOperator, int index)
        {
            switch (sqlOperator)
            {
                case EnumSqlOperator.NotEqual:
                    return new StringBuilder().AppendFormat("<> @{0}", index);
                case EnumSqlOperator.GreatThan:
                    return new StringBuilder().AppendFormat("> @{0}", index);
                case EnumSqlOperator.GreatThanEqual:
                    return new StringBuilder().AppendFormat(">= @{0}", index);
                case EnumSqlOperator.LessThan:
                    return new StringBuilder().AppendFormat("< @{0}", index);
                case EnumSqlOperator.LesThanEqual:
                    return new StringBuilder().AppendFormat("<= @{0}", index);
                default:
                    return new StringBuilder().AppendFormat("= @{0}", index);
            }
        }

        private static string GetNumericLinq(IListParameter param, int index)
        {
            //return string.Format(" ({0}{1}{2}) ",
            //                     (string.IsNullOrEmpty(param.TableName) ? string.Empty : param.TableName + DefaultValue.DOT),
            //                     param.ColumnName, GetOperatorNumberLinq(param.Operator, index));
            return string.Format(" ({0}{1} {2}) ",
                                 string.Empty,
                                 param.ColumnName, GetOperatorNumberLinq(param.Operator, index));
        }

        private static StringBuilder GetOperatorNumberLinq(EnumSqlOperator sqloperator, int index)
        {
            switch (sqloperator)
            {
                case EnumSqlOperator.NotEqual:
                    return new StringBuilder().AppendFormat("<> @{0}", index);
                case EnumSqlOperator.GreatThan:
                    return new StringBuilder().AppendFormat("> @{0}", index);
                case EnumSqlOperator.GreatThanEqual:
                    return new StringBuilder().AppendFormat(">= @{0}", index);
                case EnumSqlOperator.LessThan:
                    return new StringBuilder().AppendFormat("< @{0}", index);
                case EnumSqlOperator.LesThanEqual:
                    return new StringBuilder().AppendFormat("<= @{0}", index);
                case EnumSqlOperator.IsNull:
                    return new StringBuilder().AppendFormat("= null");
                default:
                    return new StringBuilder().AppendFormat("= @{0}", index);
            }
        }

        private StringBuilder GetOperatorClause(EnumSqlOperator sqloperator)
        {
            switch (sqloperator)
            {
                case EnumSqlOperator.NotEqual:
                    return new StringBuilder().AppendFormat("<>");
                case EnumSqlOperator.GreatThan:
                    return new StringBuilder().AppendFormat(">");
                case EnumSqlOperator.GreatThanEqual:
                    return new StringBuilder().AppendFormat(">=");
                case EnumSqlOperator.LessThan:
                    return new StringBuilder().AppendFormat("<");
                case EnumSqlOperator.LesThanEqual:
                    return new StringBuilder().AppendFormat("<=");
                case EnumSqlOperator.IsNull:
                    return new StringBuilder().AppendFormat("= NULL");
                default:
                    return new StringBuilder().AppendFormat("=");
            }
        }

        protected void ConnectionStringProtection(bool protect)
        {
            try
            {

                var oConfiguration = ConfigurationHelpers.GetCurrentConfiguration();

                if (oConfiguration == null) return;
                //var blnChanged = false;
                var oSection = oConfiguration.GetSection("connectionStrings") as ConnectionStringsSection;

                if (oSection == null) return;
                if ((oSection.ElementInformation.IsLocked) || (oSection.SectionInformation.IsLocked))
                {
                    throw new Exception("File Configuration is locked");
                }
                if (protect)
                {
                    if (!(oSection.SectionInformation.IsProtected))
                    {
                        oSection.SectionInformation.ProtectSection(DATA_PROTECTION_PROVIDER);
                    }
                }
                else
                {
                    if (oSection.SectionInformation.IsProtected)
                    {
                        oSection.SectionInformation.UnprotectSection();
                        ConnectionString = oSection.ConnectionStrings["ConnectionStringEntities"].ConnectionString;
                    }
                    else
                    {
                        ConnectionString = oSection.ConnectionStrings["ConnectionStringEntities"].ConnectionString;
                        var isweb = ConfigurationManager.AppSettings["IsWebApps"];
                        if (isweb.Equals("0"))
                        {
                            oSection.SectionInformation.ProtectSection(DATA_PROTECTION_PROVIDER);
                            oSection.SectionInformation.ForceSave = true;
                            oConfiguration.Save();
                        }
                    }
                }

                //if (blnChanged)
                //{
                //    oSection.SectionInformation.ForceSave = true;
                //    oConfiguration.Save();
                //}
            }
            catch (Exception ex)
            {

                ConnectionString = ConfigurationManager.ConnectionStrings["lexyEntities"].ConnectionString;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
