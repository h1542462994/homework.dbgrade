using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tro.DbGrade.Server.Storage;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            return new JsonResult(from item in DbContext.StuTests where item.Sno == "S01" select item);
        }
    }
}
