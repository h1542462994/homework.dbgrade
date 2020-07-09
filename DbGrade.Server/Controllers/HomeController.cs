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

        public HomeController(GradeDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public GradeDbContext DbContext { get; }

        public IActionResult Index()
        {
            return new JsonResult("hello world");
        }

        [HttpGet("students")]
        public IActionResult Students()
        {
            return new JsonResult(from item in DbContext.Students select item);
        }


    }
}
