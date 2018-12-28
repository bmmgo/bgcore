using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Model.Dao;

namespace Dal
{
    public class UserDa : BaseDal<User>
    {
        public List<User> SelectUsers(int count)
        {
            using (var conn = GetConnection())
            {
                return conn.Query<User>($"select top {count} * from [User] order by CreateTime desc").ToList();
            }
        }
    }
}
