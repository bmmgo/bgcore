using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Dao;
using Service;

namespace AdminWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserService _userService;

        public IndexModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
            var users = _userService.GetUsers(100);
            Users = users;
        }

        public List<User> Users { get; private set; }
    }
}
