using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Corporate
{
    public class CorporateUserDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public CorporateUserDataManager()
        {
            Repository = new CorporateUserRepository();
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] listParameter)
        {
            return Repository.Get<T>(listParameter);
        }

        public override T GetFirst<T>(params IListParameter[] listParameter)
        {
            return Repository.GetSingle<T>(listParameter);
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
        {
            return Repository.Get<T>(paging, out count, listParameter);
        }

        public List<CorporateUserModel> GetUserList(params IListParameter[] listParameter)
        {
            return new CorporateUserRepository().GetUserList(listParameter);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            return ((CorporateUserRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public CorporateUserModel Login(string username, string password, int corporateId)
        {
            IListParameter[] param;
            List<WhereTerm> p = new List<WhereTerm>();

            p.Add(new WhereTerm
            {
                Value = username,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Character,
                Operator = EnumSqlOperator.Equals,
                ColumnName = "username"
            });

            p.Add(new WhereTerm
            {
                Value = GetMd5Hash(password),
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Character,
                Operator = EnumSqlOperator.Equals,
                ColumnName = "password"
            });

            p.Add(new WhereTerm
            {
                Value = corporateId,
                TableName = String.Empty,
                ParamDataType = EnumParameterDataTypes.Number,
                Operator = EnumSqlOperator.Equals,
                ColumnName = "corporate_id"
            });

            param = p.ToArray();
            return GetFirst<CorporateUserModel>(param);
        }

        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
