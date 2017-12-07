using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RuntApi.Com.Entity;

namespace RuntApi.Controllers
{
    /// <summary>
    /// api路径
    /// </summary>
    public class RootController : ApiController
    {
        /// <summary>
        /// 指定路由获取数据
        /// ep:root/getinfo
        /// </summary>
        [Route("root/getinfo")]
        [HttpPost]
        public IHttpActionResult GetInfo(UserInfo u)
        {
            var user = new UserInfo()
            {
                Id = u.Id,
                Name = "麦兜",
                Sex = 1,
                IsDel = false,
                Remark = "走到遥远的地方"
            };
            return Json(user);
        }
        /// <summary>
        /// 动态路由获取数据
        /// 参数在链接里
        /// ep:root/10/ddd/getUserName
        /// </summary>
        [Route("root/{id}/{name}/getUserName")]
        [HttpPost]
        public IHttpActionResult GetUserName(int id,string name)
        {
            var list = new List<int>() {1, 2, 3, 4};
            return Json(new {IsSuccess = true, Msg = $"迈克Jack-{id}-{name}", data = list});
        }
        /// <summary>
        /// 指定方法名
        /// ep:rootapi/root/good
        /// </summary>
        [ActionName("good")]
        [HttpPost]
        public IHttpActionResult GetRunInfo()
        {
            return Json(new { IsSuccess = true, Msg = "你是个大笨蛋！"});
        }

        /// <summary>
        /// 变量路径
        /// ep:variapi/root/maidou
        /// </summary>
        [HttpPost]
        public IHttpActionResult GetArrayList(string type)
        {
            var array = new string[] {type, "今", "天", "十", "点", "半", "睡", "觉"};
            return Json(new { IsSuccess = true, Msg = array });
        }

    }
}
