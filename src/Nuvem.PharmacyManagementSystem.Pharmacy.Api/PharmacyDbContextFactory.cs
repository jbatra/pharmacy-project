using Nuvem.PharmacyManagementSystem.Pharmacy.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Api
{
    //TODO: Not Working...
public class PharmacyDbContextFactory : IDesignTimeDbContextFactory<PharmacyDbContext>
    {      
        //  PharmacyDbContext IDesignTimeDbContextFactory<PharmacyDbContext>.CreateDbContext(string[] args)
        //  {
            // IConfigurationRoot configuration = new ConfigurationBuilder()
            //     .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../Nuvem.PharmacyManagementSystem.Pharmacy.Api"))
            //     .AddJsonFile("appsettings.json")
            //     .Build();

            // var builder = new DbContextOptionsBuilder<PharmacyDbContext>();
            // var connectionString = configuration.GetConnectionString("EFConnectionString");

            // builder.UseSqlServer(connectionString);

            // return new PharmacyDbContext(builder.Options);

            private const string _databaseName = "EFConnectionString";
            private const string _migrationAssembly = "Nuvem.PharmacyManagementSystem.Pharmacy.Data";

            public PharmacyDbContext CreateDbContext(string[] args)
            {
                var configurationBuilder = new ConfigurationBuilder();
                var configuration = configurationBuilder                    
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration.GetConnectionString(_databaseName);

                var dbContextOptionsBuilder = new DbContextOptionsBuilder<PharmacyDbContext>()
                    .UseSqlServer(connectionString, x => x.MigrationsAssembly(_migrationAssembly));

                return new PharmacyDbContext(dbContextOptionsBuilder.Options);
        }
    }
}



// public class PharmacyDbContextFactory: IDesignTimeDbContextFactory<PharmacyDbContext>
//     {
//         public PharmacyDbContext CreateDbContext(string[] args)
//         {
//             // Build config
//         // IConfiguration config = new ConfigurationBuilder()
//         //     .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
//         //     .AddJsonFile("appsettings.json")
//         //     .Build();
//         // Get environment
//         // string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

//         // IConfiguration config = new ConfigurationBuilder()
//         //     .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EfDesignDemo.Web"))
//         //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//         //     .AddJsonFile($"appsettings.{environment}.json", optional: true)
//         //     .AddEnvironmentVariables()
//         //     .Build();    

//         // // Get connection string
//         // var optionsBuilder = new DbContextOptionsBuilder<PharmacyDbContext>();
//         // var connectionString = config.GetConnectionString(nameof(PharmacyDbContext));
//         // optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("EfDesignDemo.EF.Design"));
//         // return new PharmacyDbContext(optionsBuilder.Options);
//             // DbContextOptionsBuilder<PharmacyDbContext> optionsBuilder = new();
//             // optionsBuilder.UseSqlServer(@"Server=DESKTOP-EPGKLH7\SQLEXPRESS_2022;Initial Catalog=PharmacyManagementStore;User ID=jodi;Password=dallas;TrustServerCertificate=True;");
            
//             // return  new PharmacyDbContext(optionsBuilder.Options);
//         }
//     }