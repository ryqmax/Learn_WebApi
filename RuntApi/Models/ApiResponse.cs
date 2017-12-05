using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RuntApi.Models
{
    public class ApiResponse
    {
        public ApiResponse ()
        {
            IsSuccess = false;
            Msg = "传参错误啦";
        }
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}