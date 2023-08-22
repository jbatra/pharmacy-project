USE [PharmacyManagementStore]
GO


INSERT INTO [dbo].[Pharmacy]
([Name], [Address],	[City],[State],[Zip],[FilledPrescriptionMTD], [CreatedDate])
VALUES('Walgreens #1234', '1234 Renner Rd',	'Richardson','Texas','75082-1234',5,GETDATE())
GO 

INSERT INTO [dbo].[Pharmacy]
([Name], [Address],	[City],[State],[Zip],[FilledPrescriptionMTD], [CreatedDate])
VALUES('CVS #542', '1234 Renner Rd',	'Richardson','Texas','75082-1234',3,GETDATE())
GO

INSERT INTO [dbo].[Pharmacy]
([Name], [Address],	[City],[State],[Zip],[FilledPrescriptionMTD], [CreatedDate])
VALUES('Rite Aid #165', '1234 Renner Rd',	'Richardson','Texas','75082-1234',0,GETDATE())
GO

INSERT INTO [dbo].[Pharmacy]
([Name], [Address],	[City],[State],[Zip],[FilledPrescriptionMTD], [CreatedDate])
VALUES('Bartell Drugs #763', '1234 Renner Rd',	'Richardson','Texas','75082-1234',6,GETDATE())
GO

INSERT INTO [dbo].[Pharmacy]
([Name], [Address],	[City],[State],[Zip],[FilledPrescriptionMTD], [CreatedDate])
VALUES('Kroger #307', '1234 Renner Rd',	'Richardson','Texas','75082-1234',6,GETDATE())
GO