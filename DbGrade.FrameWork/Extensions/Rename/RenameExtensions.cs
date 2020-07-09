using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.Server.DataAcesses;

namespace Tro.FrameWork.Extensions.Rename
{
    public static class RenameExtensions
    {
        public static IServiceCollection AddRenameDbService<T>(this IServiceCollection collection) where T: class, IRenameDbService 
        {
            return collection.AddSingleton<IRenameDbService, T>();
        }

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
