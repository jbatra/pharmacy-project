# pharmacy-project

The solution contains 3 projects:
.net 7 Web API - Api :
.net 7 Class Library - Services : Models and business logic, uses Automapper to map models to/from DB entites
.net 7 Class Library - Data : EFCore(Code first migrations, scaffolding), repo and DB entites

Note: Logging,Exception handling and security has not been implemented at this point and will be revisited to do these add-ons. Currently, the intention is to create the basic microservice to fetch the data to provide to SPA(React with RTK).

#TODO: IDesignTimeDbContextFactory<TDbContext> is not working and needs to be fixed in order to remove the hard-coded configation in the OnConfiguring method of PharmacyDbContext.