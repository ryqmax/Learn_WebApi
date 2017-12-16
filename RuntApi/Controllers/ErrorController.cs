using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RuntApi.Com.Entity;

namespace RuntApi.Controllers
{
    /// <summary>
    /// 异常处理
    /// </summary>
    [RoutePrefix("error")]
    public class ErrorController : ApiController
    {
        /// <summary>
        /// 客户端发送http请求到我们的WebApi服务里面，服务端得到结果输出response到客户端
        /// 这个过程中，一旦服务端发生异常，会统一向客户端返回500的错误
        /// Status Code:500 Internal Server Error
        /// </summary>
        [Route("backshadow")]
        [HttpPost]
        public string BackShadow()
        {
            throw new NotImplementedException("背影");
        }
        /// <summary>
        /// 异常筛选器，返回具体的异常类型
        /// Status Code:501 This Func is Not Supported
        /// </summary>
        [ApiExceptionFilter]
        [Route("beside")]
        [HttpPost]
        public string Beside()
        {
            throw new NotImplementedException("身侧");
        }
        /// <summary>
        /// Controller继承BaseController异常处理
        /// Status Code:501 This Func is Not Supported
        /// </summary>
        [Route("before")]
        [HttpPost]
        public string Before()
        {
            throw new NotImplementedException("以前");
        }
        /// <summary>
        /// 全局异常过滤
        /// Global.asax:GlobalConfiguration.Configuration.Filters.Add(new ApiExceptionFilterAttribute());
        /// WebApiConfig.cs: config.Filters.Add(new WebApiExceptionFilterAttribute());
        /// </summary>
        [Route("bad")]
        [HttpPost]
        public string Bad()
        {
            throw new NotImplementedException("坏掉");
        }
        /// <summary>
        /// 自定义异常信息
        /// HttpResonseMessage对象用来响应讯息并包含状态码及数据内容
        /// 代表着当客户端发送了一个工作请求而api正确的完成了这个工作，就能够使用HttpResponseMessage返回一个201的讯息
        /// 用HttpResponseMessage去返回一个例外错误也会让程序结构难以辨别且不够清晰
        /// HttpResponseException对象用来向客户端返回包含错误讯息的异常
        /// 当发生了与预期上不同的错误时，理当应该中止程序返回错误讯息，这时就该使用HttpResponseException
        /// Status Code:404 life goes on
        /// </summary>
        [Route("bron")]
        [HttpPost]
        public string Bron([FromBody]int id)
        {
            if (id < 5)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"{id}小于5"),
                    ReasonPhrase = "life goes on"
                };
                throw new HttpResponseException(resp);
            }
            return "新生";
        }
        /// <summary>
        /// HttpError和HttpResponseMessage都可以向客户端返回http状态码和错误讯息,并且都可以包含在HttpResponseException对象中发回到客户端
        /// 但一般情况下,HttpError只有在向客户端返回错误讯息的时候才会使用
        /// 而HttpResponseMessage对象既可以返回错误讯息,也可返回请求正确的消息
        /// Status Code:400 Bad Request
        /// </summary>
        [Route("blood")]
        [HttpPost]
        public HttpResponseMessage Blood(dynamic obj)
        {
            var goods = new Goods();
            try
            {
                goods.Name = obj.Name;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "血," + ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, goods);

        }
    }
}
