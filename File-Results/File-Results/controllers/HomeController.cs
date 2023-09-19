using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System;

namespace ContentResultExamples.controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("home")]
        [Route("/")]

        public ContentResult Index()
        {
            // return new ContentResult() { Content="Hello From Index",ContentType="text/Plain"};
            /*            return Content("Hello From Index","text/Plain");*/
            return Content("<div style='text-align:center'><h2 style='color:red;'>Welcome</h2> <h3>Hello from Index</h3></div>", "text/html");
        }

      
        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return new VirtualFileResult("/JASAE0.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return new PhysicalFileResult(@"D:\Asp.Net Core 2023\Solutions\File-Results\File-Results\v2.png", "image/png");
        }
    }
}