using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Tro.DbGrade.Server.Extensions
{
    /// <summary>
    /// 用于扩展<see cref="Microsoft.EntityFrameworkCore.DbContext"/>的相关方法，方便系统与数据库的交互。
    /// </summary>
    public static class ModelExtensions
    {
        public static void RenameEntity(ModelBuilder builder, IMutableEntityType type, IRenameDbService service)
        {
            string entityName = service.RenameEntity(type.GetTableName());
            builder.Entity(type.ClrType).ToTable(entityName);
            foreach (var item in type.GetProperties())
            {
                builder.Entity(type.ClrType)
                    .Property(
                        item.ClrType, 
                        item.GetColumnName())
                    .HasColumnName(
                        service.RenameColumn(item.GetColumnName()));
            }
        }

        public static void RenameDb(this ModelBuilder modelBuilder, IRenameDbService service)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                RenameEntity(modelBuilder, item, service);
            }
        }
    }
}
