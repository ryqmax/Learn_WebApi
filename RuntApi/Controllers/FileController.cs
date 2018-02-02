using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace RuntApi.Controllers
{
    /// <summary>
    /// 文件Api
    /// </summary>
    [RoutePrefix("file")]
    public class FileController : ApiController
    {
        /// <summary>
        /// 文档下载
        /// </summary>
        [Route("download")]
        [HttpGet]
        public HttpResponseMessage DownLoadFile(string url, string fileName)
        {
            try
            {
                if(string.IsNullOrEmpty(url) || string.IsNullOrEmpty(fileName))
                    return new HttpResponseMessage(HttpStatusCode.NoContent);

                var fileRespone = (HttpWebResponse) ((HttpWebRequest) WebRequest.Create(url)).GetResponse();
                var response = new HttpResponseMessage(HttpStatusCode.OK);

                byte[] buffer;
                using (var stream = fileRespone.GetResponseStream())
                {
                    buffer = new byte[fileRespone.ContentLength];
                    int offset = 0, actuallyRead;
                    do
                    {
                        actuallyRead = stream?.Read(buffer, offset, buffer.Length - offset) ?? 0;
                        offset += actuallyRead;
                    }
                    while (actuallyRead > 0);
                }
                response.Content = new StreamContent(new MemoryStream(buffer));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }

    }
}
