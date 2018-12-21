using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    /// <summary>
    /// 认证
    /// </summary>
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet]
        public string GetToken(string account, string password)
        {
            return Guid.NewGuid().ToString("N");
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
