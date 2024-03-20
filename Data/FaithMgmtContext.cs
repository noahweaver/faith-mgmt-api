using FaithMgmtAPI.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;


namespace FaithMgmtAPI.Data
{
    public class FaithMgmtContext : DbContext
    {
        // The DbSet represents the collection of all the entities in the context, or that can be queried from the database, of a given type.
        // Each individual set maps to a table in the database.
        // If the name does not match the existing table, it will create a new table with the name of the DbSet.
        public DbSet<Member> Members_Table { get; set; } = null!;

        public DbSet<Request> Prayer_Requests_Table { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;" +
                "Port=3306;" +
                "Database=faith-mgmt-db;" +
                "User=root;" +
                "Password=Root@dmin;",
                new MySqlServerVersion(new Version(8, 0, 36)) //Specify the server version here
                );
        }
    }
}
