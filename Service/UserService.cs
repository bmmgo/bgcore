using System;
using Dal;
using Model.Dao;

namespace Service
{
    public class UserService
    {
        private readonly UserDa _userDa;
        public UserService(UserDa userDa)
        {
            _userDa = userDa;
        }

        public User GetUser(string userId)
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
