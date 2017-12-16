using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RuntApi.Controllers
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    [ApiExceptionFilter]
    public class BaseController : ApiController
    {
    }
}
