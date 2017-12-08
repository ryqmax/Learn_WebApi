using System.Collections.Generic;
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
        /// <summary>
        /// post请求Content-Type的类型默认为：application/x-www-form-urlencoded
        /// 也就是说post请求默认是将表单里面的数据的key/value形式发送到服务器，
        /// 而如果使用application/json，则表示将前端的数据以序列化过的json传递到后端，
        /// 后端要把它变成实体对象，还需要一个反序列化的过程
        /// $.ajax({
        ///     type: 'post',
        ///     url: "http://enlin.api.cn/some/wooden",
        ///     contentType: "application/json",
        ///     data: JSON.stringify({ Name: "roof" }),
        ///     success:function(result){}
        /// });
        /// </summary>
        [Route("wooden")]
        [HttpPost]
        public IHttpActionResult Wooden(Goods goods)
        {
            return Json($"The wooden has a red {goods.Name}.");
        }
        /// <summary>
        /// post传递数组
        /// $.ajax({
        ///     type: 'post',
        ///     url: "http://enlin.api.cn/some/cloud",
        ///     contentType: "application/json",
        ///     data: JSON.stringify(["red", "white", "orange"]),
        ///     success:function(result){}
        /// });
        /// </summary>
        [Route("cloud")]
        [HttpPost]
        public IHttpActionResult Clouds(string[] strs)
        {
            return Json($"The blue sky and {strs[1]} clouds.");
        }
        /// <summary>
        /// post传递多个实体类
        /// $.ajax({
        ///     type: 'post',
        ///     url: "http://enlin.api.cn/some/lake",
        ///     contentType: "application/json",
        ///     data: JSON.stringify([{ Name: "chicken" },{ Name: "duck" },{ Name: "fish" }]),
        ///     success:function(result){}
        /// });
        /// </summary>
        [Route("lake")]
        [HttpPost]
        public IHttpActionResult Lake(List<Goods> list)
        {
            return Json($"The lake has no {list[2].Name} but light.");
        }
        #endregion

        #region Put请求
        /// <summary>
        /// put请求一般用于对象的更新,用法和post请求基本相同
        /// $.ajax({
        ///     type: 'put',
        ///     url: "http://enlin.api.cn/some/memory",
        ///     contentType: "application/json",
        ///     data: "{\"Accident\":\"branches\"}",
        ///     success:function(result){}
        /// });
        /// </summary>
        [Route("memory")]
        [HttpPut]
        public IHttpActionResult Memory(dynamic data)
        {
            return Json($"The memory has produced many {data.Accident}.");
        }
        #endregion

        #region Delete
        /// <summary>
        /// delete请求是用于删除操作的,用法和post也是基本相同
        /// $.ajax({
        ///     type: 'delete',
        ///     url: "http://enlin.api.cn/some/missing",
        ///     contentType: "application/json",
        ///     data: JSON.stringify([{ Name: "you" },{ Name: "me" }]),
        ///     success:function(result){}
        /// });
        /// </summary>
        [Route("missing")]
        [HttpDelete]
        public IHttpActionResult Missing(List<Goods> list)
        {
            return Json($"The missing has swallowed {list[1].Name} up.");
        }
        #endregion
    }
}
