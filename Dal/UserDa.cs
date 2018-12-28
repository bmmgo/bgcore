using System;
using Model.Dao;

namespace Dal
{
    public class UserDa : BaseDal
    {
        public User SelectByUserId(string userId)
        {
            return new User
            {
                UserId = userId,
                Nick = "admin",
                CreateTime = DateTime.Now
            };
        }
    }
}
