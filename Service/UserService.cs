using Dal;
using Model.Dao;

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
            return _userDa.SelectByUserId(userId);
        }
    }
}
