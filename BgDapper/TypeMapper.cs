using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;

namespace BgDapper
{
    public class TypeMapper : SqlMapper.ITypeMap
    {
        private readonly IEnumerable<SqlMapper.ITypeMap> _mappers;

        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            foreach (var mapper in _mappers)
            {
                var result = mapper.FindConstructor(names, types);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public ConstructorInfo FindExplicitConstructor()
        {
            return _mappers
                .Select(mapper => mapper.FindExplicitConstructor())
                .FirstOrDefault(result => result != null);
        }

        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            foreach (var mapper in _mappers)
            {
                var result = mapper.GetConstructorParameter(constructor, columnName);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            foreach (var mapper in _mappers)
            {
                var result = mapper.GetMember(columnName);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
