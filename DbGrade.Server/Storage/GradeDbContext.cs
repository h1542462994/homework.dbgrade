using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Tro.DbGrade.FrameWork.Extensions.Rename;
using Tro.DbGrade.FrameWork.Models;

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

        public DbSet<Student> Students { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Xclass> Xclasses { get; set; }
        public DbSet<StudentOutView> StudentOutView { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ReportsView> ReportsView { get; set; }
        public DbSet<ReportSummaryView> ReportSummaryView { get; set; }
        public DbSet<CourseSummaryView> CourseSummaryView { get; set; }
        public DbSet<XTerm> Terms { get; set; }
        public IConfiguration Configuration { get; }
        public IRenameDbService RenameDbService { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                RenameDbService.RenameConnectionString(
                    Configuration.GetConnectionString("GradeDatabase")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.RenameDb(RenameDbService);
            modelBuilder.Entity<StructView>().HasNoKey();
            modelBuilder.Entity<ReportsView>().HasNoKey();
            modelBuilder.Entity<ReportSummaryView>().HasNoKey();
            modelBuilder.Entity<XTerm>().HasNoKey();
        }

    }
}
