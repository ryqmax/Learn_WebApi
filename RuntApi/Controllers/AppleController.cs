using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using RuntApi.Com.Entity;
using RuntApi.Models;

namespace RuntApi.Controllers
{
    [RoutePrefix("ngy/found")]
    public class AppleController : ApiController
    {
        /// <summary>
        /// ep:ngy/found/where
        /// </summary>
        [Route("where")]
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult Where()
        {
            return Json(new {IsSuccess = true, Msg = "Where are you?"});
        }
        /// <summary>
        /// 限制变量类型和默认值
        /// ep:ngy/found
        /// ep:ngy/found/6
        /// </summary>
        [Route("{age:int=4}")]
        [HttpPost]
        public IHttpActionResult Age(int age)
        {
            return Json(new { IsSuccess = true, Msg = 20 + age });
        }
        /// <summary>
        /// 返回类型:void，ajax接收到的为undefined
        /// 没有指定Route，只能匹配原有路径规则
        /// api/apple/memory
        /// </summary>
        [HttpPost]
        public void Memory()
        {
            
        }
        /// <summary>
        /// 返回类型:json
        /// ngy/found/about?year=4
        /// </summary>
        [Route("about")]
        [HttpPost]
        public IHttpActionResult About(int year)
        {
            var respons = new ApiResponse();
            if (year >= 7)
            {
                respons.IsSuccess = true;
                respons.Msg = "";
                respons.Data = "This is how...";
            }

            return Json(respons);
        }
        /// <summary>
        /// 返回类型:OkResult,可以不返回值，但告知请求成功
        /// ngy/found/final
        /// </summary>
        [Route("final")]
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult Final()
        {
            return Ok("冷漠的眼神，锥心的利刃");
        }

        /// <summary>
        /// 返回类型:NotFound,返回一个404的错误
        /// ngy/found/else
        /// </summary>
        [Route("else")]
        [HttpPost]
        public IHttpActionResult Else()
        {
            return NotFound();
        }
        /// <summary>
        /// 其他的返回类型
        /// ngy/found/ifican?type=1
        /// </summary>
        [Route("ifican")]
        [HttpPost]
        public IHttpActionResult IfICan(int type)
        {
            if (type == 1)
                return Content(HttpStatusCode.OK, "OK");//返回值和http状态码

            if (type == 2)
                return BadRequest();//返回400的http错误

            return Redirect("http://enlin.api.cn/ngy/found/final");//请求重定向
        }
        /// <summary>
        /// 自定义返回类型
        /// ngy/found/ifyoucan
        /// </summary>
        [Route("ifyoucan")]
        [HttpPost]
        public IHttpActionResult IfYouCan()
        {
            var msg = new[] {"我", "也", "想", "成", "为", "你", "眼", "中", "的", "我"};
            return new ApiResult(msg, Request);
        }
    }
}
