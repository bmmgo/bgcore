using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dao;
using Model.ViewModel;
using Service;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public User GetUser(string userId)
        {
            return _userService.GetUser(userId);
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return _userService.GetUsers(10);
        }

        [HttpPost]
        public string SaveUser([FromBody] SaveUser user)
        {
            return _userService.SaveUser(user);
        }
    }
}