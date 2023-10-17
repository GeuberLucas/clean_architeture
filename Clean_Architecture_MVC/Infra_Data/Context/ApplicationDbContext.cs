using Domain.Entities;
using Infra_Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra_Data.Context
{
    //Context do Banco de Dados com EntityFramework
    //CODE FIRST
    //class ApplicationDbContext : DbContext
    //{
    //    
    //    //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    //    //{
    //    //}
    //    //public DbSet<Category> Categories { get; set; }
    //    //public DbSet<Product> Products { get; set; }

    //    //protected override void OnModelCreating(ModelBuilder builder)
    //    //{
    //    //    base.OnModelCreating(builder);
    //    //    builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    //    //}

    //}

    //Context do Banco de Dados com DAPPER
    //DATABASE FIRST
    class ApplicationDbContext : IApplicationDbContext
    {
        public MySqlConnection GetConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(getConnectionString()))
            {
                return connection;
            }
        }

        public string getConnectionString()
        {
            string connectionString = "";
            connectionString += "Server=" + Constants.dabase_url + ";Database=" + Constants.database_name + ";Uid=" + Constants.database_user + ";Pwd=" + Constants.database_password + ";convert zero datetime=True; Allow User Variables=True;";
            //connectionString += "Server=tcp:"+ Constants.dabase_url_mariadb + ",1433;Initial Catalog=" + Constants.database_name_mariadb + ";Persist Security Info=False;User ID=" + Constants.database_user_mariadb + ";Password=" + Constants.database_password_mariadb + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return connectionString;
        }
    }
}
