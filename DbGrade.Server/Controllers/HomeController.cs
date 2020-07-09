﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tro.DbGrade.FrameWork.Extensions.DataAcesses;
using Tro.DbGrade.Server.Model;
using Tro.DbGrade.Server.Storage;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tro.DbGrade.Server.Controllers
{
    [Route("")]

    public class HomeController : Controller
    {

        public HomeController(GradeDbContext dbContext, DataAccessService<GradeDbContext> dataAccessService)
        {
            this.DbContext = dbContext;
            DataAccessService = dataAccessService;
        }

        public GradeDbContext DbContext { get; }
        public DataAccessService<GradeDbContext> DataAccessService { get; }

        public IActionResult Index()
        {
            return new JsonResult("hello world");
        }

        [HttpGet("students")]
        public IActionResult Students()
        {
            return new JsonResult(from item in DbContext.Students select item);
        }

        [HttpGet("test")]
        public IActionResult Test(int pageIndex = 0, string orders = null)
        {
            return new JsonResult(
                DataAccessService.Data(pageIndex, orders.ToOrders<Student>())
                );
        }


        [HttpGet("test2")]
        public IActionResult Test2()
        {
           
        }
    }
}
