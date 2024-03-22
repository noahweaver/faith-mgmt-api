using FaithMgmtAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaithMgmtAPI.Data
{
    // This class represents the database context for the Faith Management API.
    public class FaithMgmtContext : DbContext
    {
        // This field holds the configuration information for the application.
        private readonly IConfiguration _configuration;

        // This constructor initializes the database context with the specified options and configuration.
        public FaithMgmtContext(DbContextOptions<FaithMgmtContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        // The DbSet represents the collection of all the entities in the context, or that can be queried from the database, of a given type.
        // Each individual set maps to a table in the database.
        // If the name does not match the existing table, it will create a new table with the name of the DbSet.
        // This DbSet represents the Members table in the database.
        public DbSet<Member> Members_Table { get; set; } = null!;

        // This DbSet represents the Prayer Requests table in the database.
        public DbSet<Request> Prayer_Requests_Table { get; set; } = null!;

        // This method configures the database context. It is called by the framework when the context is initialized.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get the connection string from the configuration.
            var connectionString = _configuration.GetConnectionString("FaithMgmt");
            // Configure the context to use MySQL and automatically detect the server version.
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
