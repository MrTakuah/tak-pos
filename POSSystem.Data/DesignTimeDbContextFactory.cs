using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace POSSystem.Data
{
    // This class helps Entity Framework create a database context during design-time operations
    // (like when creating migrations or updating the database)
    // IDesignTimeDbContextFactory is an interface that EF Core looks for when running commands
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<POSSystemContext>
    {
        // This method is called by EF Core to create a new instance of our database context
        // The string[] args parameter allows for command-line arguments (though we don't use them here)
        public POSSystemContext CreateDbContext(string[] args)
        {
            // Create a new builder object that will help configure our database context
            var optionsBuilder = new DbContextOptionsBuilder<POSSystemContext>();

            // Configure the builder to use SQL Server with our connection string
            // Connection string parts:
            // Server=(localdb)\\mssqllocaldb  -> Use local SQL Server instance
            // Database=POSSystem              -> Name of our database
            // Trusted_Connection=True         -> Use Windows authentication
            // MultipleActiveResultSets=true   -> Allow multiple active result sets
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=POSSystem;Trusted_Connection=True;MultipleActiveResultSets=true");

            // Create and return a new instance of our database context with these options
            return new POSSystemContext(optionsBuilder.Options);
        }
    }
}


