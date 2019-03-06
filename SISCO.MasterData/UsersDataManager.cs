using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using SISCO.Models.MasterData;

namespace SISCO.App.MasterData
{
    public class UsersDataManager : BaseDataManager
    {
        public UsersDataManager()
        {
            Repository = new UsersRepository();
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

        public UsersModel Login(string username, string password)
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

            //if (!string.IsNullOrEmpty(password))
            //{
                p.Add(new WhereTerm
                {
                    Value = GetMd5Hash(password),
                    TableName = String.Empty,
                    ParamDataType = EnumParameterDataTypes.Character,
                    Operator = EnumSqlOperator.Equals,
                    ColumnName = "password"
                });
            //}

            param = p.ToArray();
            return GetFirst<UsersModel>(param);
        }

        // http://stackoverflow.com/questions/827527/c-sharp-md5-hasher-example
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
