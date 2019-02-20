using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShadowsocksWebAPI.Controllers
{
    public class UserInfoController : ApiController
    {
        // GET: api/UserInfo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserInfo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserInfo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserInfo/5
        public void Delete(int id)
        {
        }

        //检查用户名是否已注册
        private ApiTools tool = new ApiTools();
        [HttpPost]
        public HttpResponseMessage CheckUserName(string userName)
        {
            int num = UserInfoGetCount(userName);//查询是否存在该用户
            if (num > 0)
            {
                return tool.MsgFormat(ResponseCode.操作失败, "不可注册/用户已注册", "1 " + userName);
            }
            else
            {
                return tool.MsgFormat(ResponseCode.成功, "可注册", "0 " + userName);
            }
        }

        private int UserInfoGetCount(string username)
        {
            //return Convert.ToInt32(SearchValue("select count(id) from userinfo where username='" + username + "'"));
            return username == "admin" ? 1 : 0;
        }
    }
}
