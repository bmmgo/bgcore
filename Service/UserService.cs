using System;
using System.Collections.Generic;
using Dal;
using Model.Dao;
using Model.ViewModel;

namespace Service
{
    public class UserService : BaseService
    {
        private readonly UserDa _userDa;
        public UserService(UserDa userDa)
        {
            _userDa = userDa;
        }

        public User GetUser(string userId)
        {
            return _userDa.Select(userId);
        }

        public string SaveUser(SaveUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Nick))
            {
                throw new ArgumentException("昵称不符合要求", nameof(user.Nick));
            }
            return _userDa.Insert(new User
            {
                UserId = Guid.NewGuid().ToString("N"),
                Nick = user.Nick,
                CreateTime = DateTime.Now
            });
        }

        public List<User> GetUsers(int count)
        {
            return _userDa.SelectUsers(count);
        }
    }
}
