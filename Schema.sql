/*****************************************************************
  File:        NorthwestLabs.sql
  Description: Used for creating the tables 
               into the Northwest Labs schema for SQL Server
  Created:     December 3, 2019 -- Chris Young, Chris McLeod, Bonnie McDougal, Dallin Fairbanks
  Modified:    December 3, 2019 -- Chris Young, Chris McLeod, Bonnie McDougal, Dallin Fairbanks
  Version:     1.0
******************************************************************/
​

CREATE TABLE [Clients] (
  [ClientID]		int				not null,
  [ClFName]			VARCHAR(30)		null,
  [ClLName]			VARCHAR(50)		null,
  [CompanyName]		VARCHAR(60)		null,
  [ClAddress1]		VARCHAR(60)		null,
  [ClAddress2]		VARCHAR(60)		null,
  [ClEmail]			VARCHAR(60)		null,
  [ClPhone]			VARCHAR(15)		null,
  [BankAccouNum]	VARCHAR(30)		null,
  [Password]		VARCHAR(60)		null,
  [ClStatus]		VARCHAR(10)		null,
  [BankID]			int				null,
  [DisID]			int				null,
  PRIMARY KEY ([ClientID])
);
​
CREATE INDEX [FK] ON  [Clients] ([BankID], [DisID]);
​
CREATE TABLE [Banks] (
  [BankID]			int				not null,
  [BankName]		VARCHAR(60)		null,
  [BankRoutingNum]	VARCHAR(50)		null,
  PRIMARY KEY ([BankID])
);
​
CREATE TABLE [Discounts] (
  [DisID]			int				not null,
  [DisAmt]			float			null,
  PRIMARY KEY ([DisID])
);
​
CREATE TABLE [WorkOrders] (
  [WrkOrdID]		int				not null,
  [ReceivedDate]	date			null,
  [DueDate]			date			null,
  [RushOrder]		bit				null,
  [comments]		text			null,
  [WOReport]		text			null,
  [ReceivedBy]		int				null,
  [ClientID]		int				null,
  PRIMARY KEY ([WrkOrdID])
);
​
CREATE INDEX [FK] ON  [WorkOrders] ([ReceivedBy], [ClientID]);
​
CREATE TABLE [Compounds] (
  [CompoundID]		VARCHAR(8)		not null,
  [CompQty]			int				null,
  [GivenWeight]		float			null,
  [GivenMass]		float			null,
  [ActualWeight]	float			null,
  [SampleAppearance] VARCHAR(75)	null,
  [MTD]				float			null,
  [Status]			VARCHAR(15)		null,
  [SequenceCode]	int				null,
  [WrkOrdID]		int				null,
  [AssayID]			int				null,
  [LTNumber]		int				null,
  PRIMARY KEY ([CompoundID])
);
​
CREATE INDEX [FK] ON  [Compounds] ([WrkOrdID], [AssayID], [LTNumber]);
​
CREATE TABLE [Assays] (
  [AssayID]			int				not null,
  [AssayName]		VARCHAR(50)		null,
  [BasePrice]		float			null,
  [AssayProcedure]	text			null,
  [DaysEstimate]	float			null,
  PRIMARY KEY ([AssayID])
);
​
CREATE TABLE [Assay_Has_TestType] (
  [AssayID]			int				not null,
  [TestTypeID]		int				not null,
  PRIMARY KEY ([AssayID], [TestTypeID])
);
​
CREATE TABLE [Materials] (
  [MatID]			int				not null,
  [MatName]			VARCHAR(50)		null,
  [MatUnitMeas]		VARCHAR(50)		null,
  [MatCostPerUnit]	float			null,
  PRIMARY KEY ([MatID])
);
​
CREATE TABLE [Test_Has_Material] (
  [TestID]			int				not null,
  [MatID]			int				not null,
  [UnitQty]			float			null,
  PRIMARY KEY ([TestID], [MatID])
);
​
CREATE TABLE [Employees] (
  [EmpID]			int				not null,
  [EmpFName]		VARCHAR(30)		null,
  [EmpLName]		VARCHAR(50)		null,
  [EmpWage]			float			null,
  [EmpPassword]		VARCHAR(15)		null,
  [EmpType]			int				null,
  PRIMARY KEY ([EmpID])
);
​
CREATE INDEX [FK] ON  [Employees] ([EmpType]);

CREATE TABLE [Test_Has_Employee] (
  [TestID]			int				not null,
  [EmpID]			int				not null,
  [TestDuration]	float			null,
  PRIMARY KEY ([TestID], [EmpID])
);
​
CREATE TABLE [Tests] (
  [TestID]			int				not null,
  [TestResult]		text			null,
  [TestTubeNum]		int				null,
  [AssayDate]		date			null,
  [AssayID]			int				null,
  [LTNumber]		int				null,
  [TestTypeID]		int				null,
  PRIMARY KEY ([TestID])
);
​
CREATE INDEX [FK] ON  [Tests] ([AssayID], [LTNumber], [TestTypeID]);

CREATE TABLE [EmployeeTypes] (
  [EmpType]			int				not null,
  [EmpTypeDesc]		VARCHAR(30)		null,
  PRIMARY KEY ([EmpType])
);

CREATE TABLE [TestTypes] (
  [TestTypeID]		int				not null,
  [TestTypeDesc]	VARCHAR(30)		null,
  [Procedure]		text			null,
  PRIMARY KEY ([TestTypeID])
);

CREATE TABLE [CompoundTypes] (
  [LTNumber]		int				not null,
  [CompName]		VARCHAR(60)		null,
  PRIMARY KEY ([LTNumber])
);




