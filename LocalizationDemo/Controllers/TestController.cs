using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalizationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string GetCurrentCultureDate()
        {
            decimal d = 10000.50M;

            return DateTime.Now.ToString()+ Environment.NewLine+ d;
        }
    }
}

/*
QueryStringRequestCultureProvider
This provider allows you to pass a query string to override the culture like so http://localhost:5000/api/home?culture=en-nz

CookieRequestCultureProvider
If the user has a cookie named “.AspNetCore.Culture” and the contents is in the format of “c=en-nz|uic=en-nz”, then it will override the culture.

     */
