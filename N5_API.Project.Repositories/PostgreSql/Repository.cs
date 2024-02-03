using Dapper;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace N5_API.Project.Repositories.PostgreSql
{
    public abstract class Repository
    {
        protected string _connectionString;
        Assembly Assembly { get; set; }
        public Repository()
        {
            SetTypeMap();
        }

        public void SetTypeMap()
        {
            const string nameSpace = "N5_API.Project.Models";
            if (Assembly == null)
            {
                Assembly = AppDomain.CurrentDomain.Load(nameSpace);
            }
            IEnumerable<Type> types = null;
            types = Assembly?.GetTypes().Where(w => w.FullName.Contains(nameSpace));
            types.ToList().ForEach(type =>
            {
                var map = new CustomPropertyTypeMap(type, (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetDescriptionFromAttribute(prop) == columnName));
                SqlMapper.SetTypeMap(type, map);
            });
        }

        static string GetDescriptionFromAttribute(MemberInfo member)
        {
            if (member == null) return null;
            var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
            return attrib?.Description;
        }

        public NpgsqlParameter CreateParam(string name, object value, NpgsqlDbType pgType)
        {
            return new NpgsqlParameter(name, pgType) { Value = value == null ? DBNull.Value : value };
        }

        private NpgsqlParameter CreateParam(string name, object value)
        {
            return new NpgsqlParameter(name, value);
        }

        public void BuildSPCommand(IDbCommand cmd, string function, NpgsqlParameter[] pgParams, out NpgsqlParameter outIdParam, out NpgsqlParameter outTidParam)
        {
            cmd.CommandText = function;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < pgParams.Length; i++)
            {
                cmd.Parameters.Add(pgParams[i]);
            }
            outIdParam = new NpgsqlParameter("@ret_id", NpgsqlDbType.Bigint) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outIdParam);
            outTidParam = new NpgsqlParameter("@ret_tid", NpgsqlDbType.Uuid) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outTidParam);
        }

    }
}