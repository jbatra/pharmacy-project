using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

 namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data.Data
 {
    // public class PharmacyDbContextFactory : IDesignTimeDbContextFactory<PharmacyDbContext>
    // {      
    //     //  PharmacyDbContext IDesignTimeDbContextFactory<PharmacyDbContext>.CreateDbContext(string[] args)
    //     //  {
    //         // IConfigurationRoot configuration = new ConfigurationBuilder()
    //         //     .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../Nuvem.PharmacyManagementSystem.Pharmacy.Api"))
    //         //     .AddJsonFile("appsettings.json")
    //         //     .Build();

    //         // var builder = new DbContextOptionsBuilder<PharmacyDbContext>();
    //         // var connectionString = configuration.GetConnectionString("EFConnectionString");

    //         // builder.UseSqlServer(connectionString);

    //         // return new PharmacyDbContext(builder.Options);

    //         private const string _databaseName = "DerivedDb";
    //         private const string _migrationAssembly = "Nuvem.PharmacyManagementSystem.Pharmacy.Data";

    //         public PharmacyDbContext CreateDbContext(string[] args)
    //         {
    //             var configurationBuilder = new ConfigurationBuilder();
    //             var configuration = configurationBuilder
    //                 .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../Nuvem.PharmacyManagementSystem.Pharmacy.Api"))
    //                 .AddJsonFile("appsettings.json")
    //                 .Build();

    //             var connectionString = configuration.GetConnectionString("EFConnectionString");

    //             var dbContextOptionsBuilder = new DbContextOptionsBuilder<PharmacyDbContext>()
    //                 .UseSqlServer(connectionString, x => x.MigrationsAssembly(_migrationAssembly));

    //             return new PharmacyDbContext(dbContextOptionsBuilder.Options);
    //     }
    // }
 }