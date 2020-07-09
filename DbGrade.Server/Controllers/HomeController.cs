using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tro.DbGrade.Server.Model;
using Tro.DbGrade.Server.Storage;


namespace Tro.DbGrade.Server.Controllers
{
    [Route("")]

    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return new JsonResult("hello world");
        }



    }
}
