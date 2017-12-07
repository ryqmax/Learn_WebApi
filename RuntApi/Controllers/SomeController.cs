using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using RuntApi.Com.Entity;

namespace RuntApi.Controllers
{
    /// <summary>
    /// api参数
    /// </summary>
    [RoutePrefix("some")]
    public class SomeController : ApiController
    {
        #region Get请求
        /// <summary>
        /// Get请求会默认把参数拼接到url里
        /// ep:some/ruler?count=3
        /// </summary>
        [Route("ruler")]
        [HttpGet]
        public IHttpActionResult Rulers(int count)
        {
            return Json($"The ruler is {count} meter.");
        }
        /// <summary>
        /// 参数是实体类可使用申明[FromUri]
        /// 或用JSON.stringify(),再string转换
        ///  $.ajax({
        ///     type: 'get',
        ///     url: 'http://enlin.api.cn/some/star',
        ///     data: { "Name": "Stars" },
        ///     dataType: 'json',
        ///     success: function(result){}
        /// });
        /// </summary>
        [Route("star")]
        [HttpGet]
        public IHttpActionResult Stars([FromUri]Goods goods)
        {
            return Json($"The {goods.Name} are all over the sky.");
        }
        /// <summary>
        /// 一般get请求不建议将数组作为参数，get请求传递参数的大小是有限制的，最大1024字节，
        /// 数组里面内容较多时，将其作为参数传递可能会发生参数超限丢失的情况
        /// 方法名以Get开头，WebApi会自动默认这个请求就是get请求
        /// 否则不能省略请求类型
        /// ep:some/rabbit
        /// </summary>
        [Route("rabbit")]
        public IHttpActionResult GetRabbits()
        {
            return Json("The rabbits were all leaving me.");
        }
        #endregion

        #region Post请求
        /// <summary>
        /// post请求的参数是通过http的请求体中传过来的
        /// post可以直接传递Json实体类
        /// </summary>
        [Route("candy")]
        [HttpPost]
        public IHttpActionResult Candy(Goods goods)
        {
            return Json($"The {goods.Name} are all sweet."); 
        }
        /// <summary>
        /// 一般的通过url取参数的机制是键值对，
        /// 即某一个key等于某一个value，而这里的FromBody和我们一般通过url取参数的机制则不同，
        /// 它的机制是=value，没有key的概念，
        /// 并且如果你写了key(比如你的ajax参数写的{NAME:"Jim"})，后台反而得到的NAME等于null
        /// 正确写法如下
        ///  $.ajax({
        ///     type: 'post',
        ///     url: 'http://enlin.api.cn/some/flower',
        ///     data: { "": "Math" },
        ///     dataType: 'json',
        ///     success: function(result){}
        /// });
        /// </summary>
        [Route("flower")]
        [HttpPost]
        public IHttpActionResult Flower([FromBody]string month)
        {
            return Json($"The flowers were all opened in {month}.");
        }
        /// <summary>
        /// dynamic动态类型能顺利得到多个参数，省掉了[FromBody]这个累赘，
        /// 注意1：ajax的请求需要加上 contentType: 'application/json'
        /// 注意2：参数要拼写
        /// 注意3：注释掉Web.congig里的 <remove name='OPTIONSVerbHandler'/>的申明
        /// $.ajax({
        ///     type: 'post',
        ///     url: "http://enlin.api.cn/some/bird",
        ///     contentType: "application/json",
        ///     data: "{\"Direct\":\"South\",\"Reason\":\"NGY\"}",
        ///     success:function(result){}
        /// });
        /// </summary>
        [Route("bird")]
        [HttpPost]
        public IHttpActionResult Bird(dynamic data)
        {
            return Json($"The birds are gone to the {data.Direct}.");
        }

        #endregion
    }
}
