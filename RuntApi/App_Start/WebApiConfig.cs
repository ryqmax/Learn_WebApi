using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RuntApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //请求不设限
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            //全局定义
            //var allowOrigins = ConfigurationManager.AppSettings["cors_allowOrigins"];
            //var allowHeaders = ConfigurationManager.AppSettings["cors_allowHeaders"];
            //var allowMethods = ConfigurationManager.AppSettings["cors_allowMethods"];
            //var globalCors = new EnableCorsAttribute(allowOrigins, allowHeaders, allowMethods);
            //config.EnableCors(globalCors);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //默认路由规则
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //路由规则
            config.Routes.MapHttpRoute(
                name: "RootApi",
                routeTemplate: "rootapi/{controller}/{action}/{id}",
                constraints: new { id = @"\d*" },//参数约束，配置0和多个数字
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "VariableApi",
                routeTemplate: "variapi/{controller}/{type}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Filters.Add(new ApiExceptionFilterAttribute());
        }
    }
}
