using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Tro.DbGrade.Server.Extensions;
using Tro.DbGrade.Server.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tro.DbGrade.Server.Storage
{
    public class GradeDbContext : DbContext
    {
        public GradeDbContext(DbContextOptions options, IRenameDbService renameDbService, IConfiguration configuration) :base(options)
        {
            this.Configuration = configuration;
            this.RenameDbService = renameDbService;
            
        }

        public DbSet<StuTest> StuTests { get; set; }
        public DbSet<Student> Students { get; set; }
        public IConfiguration Configuration { get; }
        public IRenameDbService RenameDbService { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options )
        {
            options.UseSqlServer(
                RenameDbService.RenameConnectionString(
                    Configuration.GetConnectionString("GradeDatabase")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.RenameDb(RenameDbService);
        }

    }
}
