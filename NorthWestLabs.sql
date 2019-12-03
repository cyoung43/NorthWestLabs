/*****************************************************************
  File:        NorthwestLabs.sql
  Description: Used for creating the tables 
               into the Northwest Labs schema for SQL Server
  Created:     December 3, 2019 -- Chris Young, Chris McLeod, Bonnie McDougal, Dallin Fairbanks
  Modified:    December 3, 2019 -- Chris Young, Chris McLeod, Bonnie McDougal, Dallin Fairbanks
  Version:     1.0
******************************************************************/

CREATE TABLE [Discounts] (
  [DisID]			int		identity (1, 1)		not null,
  [DisAmt]			float						null,
  PRIMARY KEY		clustered ([DisID] asc)
);

CREATE TABLE [Assays] (
  [AssayID]			int		identity (1, 1)		not null,
  [AssayName]		varchar(50)					null,
  [BasePrice]		float						null,
  [AssayProcedure]	text						null,
  [DaysEstimate]	float						null,
  PRIMARY KEY		clustered ([AssayID] asc)
);

CREATE TABLE [Banks] (
  [BankID]			int		identity (1, 1)		not null,
  [BankName]		varchar(60)					null,
  [BankRoutingNum]	varchar(50)					null,
  PRIMARY KEY		clustered ([BankID] asc)
);

CREATE TABLE [Compounds] (
  [LTNumber]		int		identity (1, 1)		not null,
  [CompName]		varchar(60)					null,
  [CompQty]			int							null,
  [GivenWeight]		float						null,
  [GivenMass]		float						null,
  [ActualWeight]	float						null,
  [SampleAppearance] varchar(75)				null,
  [MTD]				float						null,
  [Status]			varchar(15)					null,
  [WrkOrdID]		int							null,
  PRIMARY KEY		clustered ([LTNumber] asc)
);

CREATE INDEX [FK] ON  [Compounds] ([WrkOrdID]);

CREATE TABLE [Materials] (
  [MatID]			int		identity (1, 1)		not null,
  [MatName]			varchar(50)					null,
  [MatUnitMeas]		varchar(50)					null,
  [MatCostPerUnit]	float						null,
  PRIMARY KEY		clustered ([MatID] asc)
);

CREATE TABLE [Assay_Has_Employee] (
  [TestID]			int		identity (1, 1)		not null,
  [EmpID]			int							null,
  [TestDuration]	float						null,
  PRIMARY KEY		clustered ([TestID], [EmpID] asc)
);

CREATE TABLE [WorkOrders] (
  [WrkOrdID]		int		identity (1, 1)		not null,
  [ReceivedDate]	date						null,
  [DueDate]			date						null,
  [RushOrder]		bit							null,
  [comments]		text						null,
  [ReceivedBy]		int							null,
  [ClientID]		int							null,
  PRIMARY KEY		clustered ([WrkOrdID] asc)
);

CREATE INDEX [FK] ON  [WorkOrders] ([ReceivedBy], [ClientID]);

CREATE TABLE [Clients] (
  [ClientID]		int		identity (1, 1)		not null,
  [ClFName]			varchar(30)					null,
  [ClLName]			varchar(50)					null,
  [CompanyName]		varchar(60)					null,
  [ClAddress1]		varchar(60)					null,
  [ClAddress2]		varchar(60)					null,
  [ClEmail]			varchar(60)					null,
  [ClPhone]			varchar(15)					null,
  [BankAccouNum]	varchar(30)					null,
  [Password]		varchar(60)					null,
  [ClStatus]		varchar(10)					null,
  [BankID]			int							null,
  [DisID]			int							null,
  PRIMARY KEY		clustered ([ClientID] asc)
);

CREATE INDEX [FK] ON  [Clients] ([BankID], [DisID]);

CREATE TABLE [Test_Has_Material] (
  [TestID]			int		identity (1, 1)		not null,
  [MatID]			int							null,
  [UnitQty]			float						null,
  PRIMARY KEY		clustered ([TestID], [MatID] asc)
);

CREATE TABLE [Compound_Has_Assay] (
  [LTNumber]		int		identity (1, 1)		not null,
  [AssayID]			int							null,
  [SequenceCode]	int							null,
  [AssayDate]		date						null,
  PRIMARY KEY		clustered ([LTNumber], [AssayID] asc)
);

CREATE TABLE [Employees] (
  [EmpID]			int		identity (1, 1)		not null,
  [EmpFName]		varchar(30)					null,
  [EmpLName]		varchar(50)					null,
  [EmpWage]			float						null,
  [EmpType]			int							null,
  PRIMARY KEY		clustered ([EmpID] asc)
);

CREATE INDEX [FK] ON  [Employees] ([EmpType]);

CREATE TABLE [Tests] (
  [TestID]			int		identity (1, 1)		not null,
  [TestResult]		bit							null,
  [TestTubeNum]		int							null,
  [AssayID]			int							null,
  PRIMARY KEY		clustered ([TestID] asc)
);

CREATE INDEX [FK] ON  [Tests] ([AssayID]);

CREATE TABLE [EmployeeTypes] (
  [EmpType]			int		identity (1, 1)		not null,
  [EmpTypeDesc]		varchar(30)					null,
  PRIMARY KEY		clustered ([EmpType] asc)
);

