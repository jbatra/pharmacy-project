# pharmacy-project

The objective is to create the microservices framework that will expose API endpoints (backed by business logic and Data) to be used by SPA(React with RTK). 

The source(src) solution contains 3 projects:
1) .Net 7 Web API - API : This API exposes 3 endpoints to .... The primary user of this API is SPA(React with RTK).
2) .Net 7 Class Library - Services : Models and business logic for Pharmacy, uses Automapper to map models to/from DB entites
3) .Net 7 Class Library - Data : EFCore(Code first migrations, scaffolding), repo and DB entites. This is the Data Access Layer to connect to DB (SQL Server).

Note: Logging, exception handling and security has not been implemented at this point and will be revisited to do these add-ons. 
