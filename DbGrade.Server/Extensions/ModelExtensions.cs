#nullable enable

using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        /// 获取<typeparamref name="T"/>的默认模型名。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static string DefaultName<T>(this EntityTypeBuilder<T> builder) where T:class
        {
            Type entityType = typeof(T);
            string name = entityType.Name;
            TableAttribute? tableAttribute = entityType.GetCustomAttribute<TableAttribute>();
            if(tableAttribute != null)
            {
                name = tableAttribute.Name;
            }

            return name;
        }

        public static void RenameDb(this ModelBuilder modelBuilder, IRenameDbService service)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                Console.WriteLine(item.Name);
            }
            
                
        }
    }
}
