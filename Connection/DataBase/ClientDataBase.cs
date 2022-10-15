using Connection.Commons;
using Connection.Dispatcher;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.DataBase
{
    public class ClientDataBase : DbContext
    {
        public DbSet<Pokemon> MyProperty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"DataSource={GlobalParameters.DataBasePath}");        
    }
}
