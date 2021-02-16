-- --------------------------------------------------------------------------------
-- Abstract: This is a database used for a charity event, Golf-a-thon.
--
-- Author: Derrick Warren
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop procedure statements
-- --------------------------------------------------------------------------------

IF OBJECT_ID( 'uspAddEvent' )						IS NOT NULL DROP PROCEDURE  uspAddEvent
IF OBJECT_ID( 'uspDeleteEvent' )					IS NOT NULL DROP PROCEDURE  uspDeleteEvent
IF OBJECT_ID( 'uspAddGolfer' )						IS NOT NULL DROP PROCEDURE  uspAddGolfer
IF OBJECT_ID( 'uspUpdateGolfer' )					IS NOT NULL DROP PROCEDURE  uspUpdateGolfer
IF OBJECT_ID( 'uspDeleteGolfer' )					IS NOT NULL DROP PROCEDURE  uspDeleteGolfer
IF OBJECT_ID( 'uspAddSponsor' )						IS NOT NULL DROP PROCEDURE  uspAddSponsor
IF OBJECT_ID( 'uspUpdateSponsor' )					IS NOT NULL DROP PROCEDURE  uspUpdateSponsor
IF OBJECT_ID( 'uspDeleteSponsor' )					IS NOT NULL DROP PROCEDURE  uspDeleteSponsor
IF OBJECT_ID( 'uspAddGolferEventYear' )				IS NOT NULL DROP PROCEDURE  uspAddGolferEventYear
IF OBJECT_ID( 'uspDeleteGolferEventYear' )			IS NOT NULL DROP PROCEDURE  uspDeleteGolferEventYear
IF OBJECT_ID( 'uspAddGolferAndEvent' )				IS NOT NULL DROP PROCEDURE  uspAddGolferAndEvent
IF OBJECT_ID( 'uspAddGolferEventYearSponsor' )		IS NOT NULL DROP PROCEDURE  uspAddGolferEventYearSponsor
IF OBJECT_ID( 'uspAddSponsorandGolferEvent' )		IS NOT NULL DROP PROCEDURE  uspAddSponsorandGolferEvent
IF OBJECT_ID( 'uspDeleteGolferEventYearSponsor' )	IS NOT NULL DROP PROCEDURE  uspDeleteGolferEventYearSponsor




-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'TGolferEventYearSponsors' )		IS NOT NULL DROP TABLE	TGolferEventYearSponsors
IF OBJECT_ID( 'TGolferEventYears' )				IS NOT NULL DROP TABLE	TGolferEventYears
IF OBJECT_ID( 'TEventYears' )					IS NOT NULL DROP TABLE	TEventYears
IF OBJECT_ID( 'TGolfers' )						IS NOT NULL DROP TABLE	TGolfers
IF OBJECT_ID( 'TGenders' )						IS NOT NULL DROP TABLE	TGenders
IF OBJECT_ID( 'TShirtSizes' )					IS NOT NULL DROP TABLE	TShirtSizes
IF OBJECT_ID( 'TPaymentTypes' )					IS NOT NULL DROP TABLE	TPaymentTypes
IF OBJECT_ID( 'TPaidStatus' )					IS NOT NULL DROP TABLE	TPaidStatus
IF OBJECT_ID( 'TSponsors' )						IS NOT NULL DROP TABLE	TSponsors
IF OBJECT_ID( 'TSponsorTypes' )					IS NOT NULL DROP TABLE	TSponsorTypes

-- --------------------------------------------------------------------------------
-- Drop views
-- --------------------------------------------------------------------------------

IF OBJECT_ID( 'vAvailableGolfers' )				IS NOT NULL DROP VIEW  vAvailableGolfers
IF OBJECT_ID( 'vEventGolfers' )					IS NOT NULL DROP VIEW  vEventGolfers
IF OBJECT_ID( 'vEventGolfers1' )				IS NOT NULL DROP VIEW  vEventGolfers1
IF OBJECT_ID( 'vSponsors' )						IS NOT NULL DROP VIEW  vSponsors
IF OBJECT_ID( 'vSponsorEventGolfers' )			IS NOT NULL DROP VIEW  vSponsorEventGolfers
IF OBJECT_ID( 'vSponsorEventGolfers1' )			IS NOT NULL DROP VIEW  vSponsorEventGolfers1
IF OBJECT_ID( 'vTotalPledgedEvent' )			IS NOT NULL DROP VIEW  vTotalPledgedEvent
IF OBJECT_ID( 'vTotalPledgedSponsor' )			IS NOT NULL DROP VIEW  vTotalPledgedSponsor
IF OBJECT_ID( 'vTotalPledgedGolfer' )			IS NOT NULL DROP VIEW  vTotalPledgedGolfer

-- --------------------------------------------------------------------------------
-- Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TEventYears
(
	 intEventYearID		INTEGER			NOT NULL
	,intEventYear		INTEGER			NOT NULL
	,CONSTRAINT TEventYears_PK PRIMARY KEY ( intEventYearID	)
)

CREATE TABLE TGenders
(
	 intGenderID		INTEGER				NOT NULL
	,strGenderDesc			VARCHAR(50)		NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)

CREATE TABLE TShirtSizes
(
	 intShirtSizeID			INTEGER			NOT NULL
	,strShirtSizeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TShirtSizes_PK PRIMARY KEY ( intShirtSizeID )
)

CREATE TABLE TGolfers
(
	 intGolferID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,intShirtSizeID		INTEGER			NOT NULL
	,intGenderID		INTEGER			NOT NULL
	,CONSTRAINT TGolfers_PK PRIMARY KEY ( intGolferID )
)

CREATE TABLE TSponsors
(
	 intSponsorID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsors_PK PRIMARY KEY ( intSponsorID )
)

CREATE TABLE TPaymentTypes
(
	 intPaymentTypeID		INTEGER			NOT NULL
	,strPaymentTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TPaymentTypes_PK PRIMARY KEY ( intPaymentTypeID )
)

CREATE TABLE TPaidStatus
(
	 intPaidStatusID	INTEGER			NOT NULL
	,strPaidStatusDesc	VARCHAR(50)		NOT NULL
	,CONSTRAINT TPaid_PK PRIMARY KEY ( intPaidStatusID )
)

CREATE TABLE TGolferEventYears
(
	 intGolferEventYearID	INTEGER	IDENTITY	NOT NULL
	,intGolferID			INTEGER				
	,intEventYearID			INTEGER				
	,CONSTRAINT TGolferEventYears_UQ UNIQUE ( intGolferID, intEventYearID )
	,CONSTRAINT TGolferEventYears_PK PRIMARY KEY ( intGolferEventYearID )
)


CREATE TABLE TGolferEventYearSponsors
(
	 intGolferEventYearSponsorID	INTEGER IDENTITY	NOT NULL
	,intGolferID					INTEGER				NOT NULL
	,intEventYearID					INTEGER				NOT NULL
	,intSponsorID					INTEGER				NOT NULL
	,monPledgeAmount				MONEY				NOT NULL
	,intSponsorTypeID				INTEGER				NOT NULL
	,intPaymentTypeID				INTEGER				NOT NULL
	,intPaidStatusID				INTEGER				NOT NULL
	,CONSTRAINT TGolferEventYearSponsors_UQ UNIQUE ( intGolferID, intEventYearID, intSponsorID )
	,CONSTRAINT TGolferEventYearSponsors_PK PRIMARY KEY ( intGolferEventYearSponsorID )
)

CREATE TABLE TSponsorTypes
(
	 intSponsorTypeID		INTEGER			NOT NULL
	,strSponsorTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsorTypes_PK PRIMARY KEY ( intSponsorTypeID )
)


-- --------------------------------------------------------------------------------
-- Identify and Create Foreign Keys for table constraints
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column(s)
-- -	-----							------						---------
-- 1	TGolfers						TGenders					intGenderID
-- 2	TGolfers						TShirtSizes					intShirtSizeID
-- 3    TGolferEventYears				TGolfers					intGolferID
-- 4	TGolferEventYearSponsors		TGolferEventYears			intGolferID, intEventYearID
-- 5	TGolferEventYears				TEventYears					intEventYearID
-- 6    TGolferEventYearSponsors		TSponsors					intSponsorID
-- 7	TGolferEventYearSponsors		TSponsorTypes				intSponsorTypeID
-- 8	TGolferEventYearSponsors		TPaymentTypes				intPaymentTypeID
-- 9	TGolferEventYearSponsors		TPaidStatus					intPaidStatusID

-- 1
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TGenders_FK
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID )

-- 2
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TShirtSizes_FK
FOREIGN KEY ( intShirtSizeID ) REFERENCES TShirtSizes ( intShirtSizeID )

-- 3
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TGolfers_FK
FOREIGN KEY ( intGolferID ) REFERENCES TGolfers ( intGolferID )

-- 4
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TGolferEventYears_FK
FOREIGN KEY ( intGolferID, intEventYearID ) REFERENCES TGolferEventYears ( intGolferID, intEventYearID )

-- 5
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TEventYears_FK
FOREIGN KEY ( intEventYearID ) REFERENCES TEventYears ( intEventYearID )

-- 6
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsors_FK
FOREIGN KEY ( intSponsorID ) REFERENCES TSponsors ( intSponsorID )

-- 7
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsorTypes_FK
FOREIGN KEY ( intSponsorTypeID ) REFERENCES TSponsorTypes ( intSponsorTypeID )

-- 8
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TPaymentTypes_FK
FOREIGN KEY ( intPaymentTypeID ) REFERENCES TPaymentTypes ( intPaymentTypeID )

-- 9
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TPaidStatus_FK
FOREIGN KEY ( intPaidStatusID ) REFERENCES TPaidStatus ( intPaidStatusID )

-- --------------------------------------------------------------------------------
-- Add data to Gender
-- --------------------------------------------------------------------------------

INSERT INTO TGenders( intGenderID, strGenderDesc)
VALUES		(1, 'Female')
		,(2, 'Male')

-- --------------------------------------------------------------------------------
-- Add men's and women's shirt sizes
-- --------------------------------------------------------------------------------

INSERT INTO TShirtSizes( intShirtSizeID, strShirtSizeDesc)
VALUES		(1, 'Mens Small')
		,(2, 'Mens Medium')
		,(3, 'Mens Large')
		,(4, 'Mens XLarge')
		,(5, 'Womens Small')
		,(6, 'Womens Medium')
		,(7, 'Womens Large')
		,(8, 'Womens XLarge')

-- --------------------------------------------------------------------------------
-- Add years
-- --------------------------------------------------------------------------------
INSERT INTO TEventYears ( intEventYearID, intEventYear )
	VALUES	 ( 1, 2015)
		,( 2, 2016)
		,(3, 2017)

-- --------------------------------------------------------------------------------
-- Add sponsor types
-- --------------------------------------------------------------------------------
INSERT INTO TSponsorTypes ( intSponsorTypeID, strSponsorTypeDesc)
	VALUES (1, 'Parent')
		,(2, 'Alumni')
		,(3, 'Friend')
		,(4, 'Business')

-- --------------------------------------------------------------------------------
-- Add payment types
-- --------------------------------------------------------------------------------
INSERT INTO TPaymentTypes ( intPaymentTypeID, strPaymentTypeDesc)
	VALUES (1, 'Check')
		,(2, 'Cash')
		,(3, 'Credit Card')

-- --------------------------------------------------------------------------------
-- Add paid (yes/no)
-- --------------------------------------------------------------------------------
INSERT INTO TPaidStatus( intPaidStatusID, strPaidStatusDesc)
	VALUES (1, 'Yes')
		,(2, 'No')

-- --------------------------------------------------------------------------------
-- Add sponsors
-- --------------------------------------------------------------------------------

INSERT INTO TSponsors ( intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail )
VALUES	 ( 1, 'Jim', 'Smith', '1979 Wayne Trace Rd.', 'Willow', 'OH', '42368', '5135551212', 'jsmith@yahoo.com' )
		,( 2, 'Sally', 'Jones', '987 Mills Rd.', 'Cincinnati', 'OH', '45202', '5135551234', 'sjones@yahoo.com' )
		,( 3, 'Matt', 'Green', '8808 Locks Rd.', 'Akron', 'OH', '42114', '5134102356', 'mgreene@yahoo.com' )
		,( 4, 'Laura', 'Jennings', '2121 Moose Ln.', 'Cincinnati', 'OH', '45245', '5137892223', 'ljennings@yahoo.com' )
		,( 5, 'Paul', 'Cooper', '1745 Montana Cir.', 'Mt. Healthy', 'OH', '42141', '5138614016', 'pcooper@yahoo.com' )
		
-- --------------------------------------------------------------------------------
-- Add golfers
-- --------------------------------------------------------------------------------

INSERT INTO TGolfers ( intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID )
VALUES	 ( 1, 'Bill', 'Goldstein', '156 Main St.', 'Mason', 'OH', '45040', '5135559999', 'bGoldstein@yahoo.com', 1, 2 )
		,( 2, 'Tara', 'Everett', '3976 Deer Run', 'West Chester', 'OH', '45069', '5135550101', 'teverett@yahoo.com', 6, 1 )
		,( 3, 'Mike', 'Dawson', '1800 Dover St.', 'Fairfield', 'OH', '45220', '5139255566', 'MDawson@yahoo.com', 3, 2 )
		,( 4, 'Sara', 'Weaver', '1355 Beaver Creek', 'Norwood', 'OH', '45078', '5132228181', 'SWeaver@yahoo.com', 5, 1 )
		,( 5, 'Jane', 'Seymour', '1505 Lincoln Ave.', 'Cincinnati', 'OH', '45206', '5138641408', 'JSeymour@yahoo.com', 5, 1 )

-- --------------------------------------------------------------------------------
-- Add Golfers and sponsors to link them
-- --------------------------------------------------------------------------------

INSERT INTO TGolferEventYears ( intGolferID, intEventYearID)
	VALUES ( 1, 1 )
		,( 2, 1 )
		,( 1, 2 )
		,( 2, 2 )
		,( 4, 3 )
		,( 3, 3 )

-- --------------------------------------------------------------------------------
-- Add Events, Golfers, and Sponsors to link them
-- --------------------------------------------------------------------------------
INSERT INTO TGolferEventYearSponsors ( intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, intPaidStatusID )
VALUES	 ( 1, 1, 1, 10.00, 2, 3, 2 )
		,( 2, 1, 2, 100.00, 3, 1, 2 )
		,( 1, 2, 3, 25.00, 4, 2, 1 )
		,( 2, 2, 2, 50.00, 1, 2, 1 )
		,( 2, 1, 4, 20.00, 4, 3, 1 )
		,( 1, 2, 4, 25.00, 3, 1, 2 )
		,( 3, 3, 2, 45.00, 1, 1, 1 )
		,( 2, 1, 1, 100.00, 1, 1, 1 )
		,( 4, 3, 2, 500.00, 3, 2, 2 )
		,( 1, 1, 3, 30.00, 2, 3, 2 )
		,( 3, 3, 1, 125.00, 1, 1, 1 )
		,( 4, 3, 5, 50.00, 3, 2, 1 )

-- --------------------------------------------------------------------------------
-- Create a stored procedure to add an Event - uspAddEvent
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddEvent
	@intEventYearID AS INTEGER OUTPUT
	,@intEventYear AS INTEGER
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	SELECT @intEventYearID = MAX(intEventYearID) + 1 
	FROM TEventYears (TABLOCKX) -- lock table until end of transaction

	-- default to 1 if table is empty
	SELECT @intEventYearID = COALESCE(@intEventYearID, 1)

	INSERT INTO TEventYears (intEventYearID, intEventYear)
	VALUES					(@intEventYearID, @intEventYear)


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--DECLARE @intEventYearID AS INTEGER = 0
--EXECUTE uspAddEvent @intEventYearID OUTPUT, '2018' 
--PRINT 'EventYear ID = ' + CONVERT(VARCHAR, @intEventYearID)

-- --------------------------------------------------------------------------------
-- Create a stored procedure to delete an Event - uspDeleteEvent
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspDeleteEvent
	@intEventYearID AS INTEGER 
	,@intEventYear AS INTEGER
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	SELECT @intEventYearID 
	FROM TEventYears (TABLOCKX) -- lock table until end of transaction

	DELETE FROM TEventYears 
	WHERE		intEventYearID = @intEventYearID


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--SELECT * FROM TEventYears

--DECLARE @intEventYearID AS INTEGER = 4
--EXECUTE uspDeleteEvent @intEventYearID, '2018' 
--PRINT 'EventYear ID = ' + CONVERT(VARCHAR, @intEventYearID) 

--SELECT * FROM TEventYears

-- --------------------------------------------------------------------------------
-- Create a stored procedure to add a Golfer - uspAddGolfer
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddGolfer
	 @intGolferID		AS INTEGER OUTPUT			
	,@strFirstName		AS VARCHAR(50)		
	,@strLastName		AS VARCHAR(50)		
	,@strStreetAddress	AS VARCHAR(50)		
	,@strCity			AS VARCHAR(50)		
	,@strState			AS VARCHAR(50)		
	,@strZip			AS VARCHAR(50)		
	,@strPhoneNumber	AS VARCHAR(50)		
	,@strEmail			AS VARCHAR(50)		
	,@intShirtSizeID	AS INTEGER			
	,@intGenderID		AS INTEGER	
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	SELECT @intGolferID = MAX(intGolferID) + 1 
	FROM TGolfers (TABLOCKX) -- lock table until end of transaction

	-- default to 1 if table is empty
	SELECT @intGolferID = COALESCE(@intGolferID, 1)

	INSERT INTO TGolfers (intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID )
	VALUES				(@intGolferID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail, @intShirtSizeID, @intGenderID)


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--SELECT * FROM TGolfers

--DECLARE @intGolferID AS INTEGER = 0
--EXECUTE uspAddGolfer @intGolferID OUTPUT, 'Bas', 'Ruten', '389 Kamura Ln.', 'Norwood', 'OH', '45333', '5137415466', 'B.Ruten@gmail.com', '3', '2'
--PRINT 'Golfer ID = ' + CONVERT(VARCHAR, @intGolferID)

--SELECT * FROM TGolfers

-- --------------------------------------------------------------------------------
-- Create a stored procedure to update a Golfer - uspUpdateGolfer
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspUpdateGolfer
	 @intGolferID		AS INTEGER OUTPUT			
	,@strFirstName		AS VARCHAR(50)		
	,@strLastName		AS VARCHAR(50)		
	,@strStreetAddress	AS VARCHAR(50)		
	,@strCity			AS VARCHAR(50)		
	,@strState			AS VARCHAR(50)		
	,@strZip			AS VARCHAR(50)		
	,@strPhoneNumber	AS VARCHAR(50)		
	,@strEmail			AS VARCHAR(50)		
	,@intShirtSizeID	AS INTEGER			
	,@intGenderID		AS INTEGER	
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	--SELECT @intGolferID 
	--FROM TGolfers (TABLOCKX) -- lock table until end of transaction

	UPDATE TGolfers 
	SET				strFirstName = @strFirstName, strLastName = @strLastName, strStreetAddress = @strStreetAddress, strCity = @strCity, strState = @strState, 
					strZip = @strZip, strPhoneNumber = @strPhoneNumber, strEmail = @strEmail, intShirtSizeID = @intShirtSizeID, intGenderID = @intGenderID
	WHERE			intGolferID = @intGolferID


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--SELECT * FROM TGolfers

--DECLARE @intGolferID AS INTEGER = 4
--EXECUTE uspUpdateGolfer @intGolferID OUTPUT, 'Bas', 'Ruten', '222 Headbutt Cir.', 'Norwood', 'OH', '45333', '5137415466', 'B.Ruten@gmail.com', '3', '2'
--PRINT 'Golfer ID = ' + CONVERT(VARCHAR, @intGolferID) 

--SELECT * FROM TGolfers

-- --------------------------------------------------------------------------------
-- Create a stored procedure to delete a Golfer - uspDeleteGolfer
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspDeleteGolfer
	 @intGolferID		AS INTEGER OUTPUT			
	,@strFirstName		AS VARCHAR(50)		
	,@strLastName		AS VARCHAR(50)		
	,@strStreetAddress	AS VARCHAR(50)		
	,@strCity			AS VARCHAR(50)		
	,@strState			AS VARCHAR(50)		
	,@strZip			AS VARCHAR(50)		
	,@strPhoneNumber	AS VARCHAR(50)		
	,@strEmail			AS VARCHAR(50)		
	,@intShirtSizeID	AS INTEGER			
	,@intGenderID		AS INTEGER	
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	--SELECT @intGolferID 
	--FROM TGolfers (TABLOCKX) -- lock table until end of transaction

	DELETE FROM TGolfers 
	WHERE		intGolferID = @intGolferID


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--SELECT * FROM TGolfers

--DECLARE @intGolferID AS INTEGER = 6
--EXECUTE uspDeleteGolfer @intGolferID , 'Bas', 'Ruten', '389 Kamura Ln.', 'Norwood', 'OH', '45333', '5137415466', 'B.Ruten@gmail.com', '3', '2'
--PRINT 'Golfer ID = ' + CONVERT(VARCHAR, @intGolferID) 

--SELECT * FROM TGolfers

-- --------------------------------------------------------------------------------
-- Create a stored procedure to add a Sponsor - uspAddSponsor
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddSponsor
	 @intSponsorID		AS INTEGER OUTPUT			
	,@strFirstName		AS VARCHAR(50)		
	,@strLastName		AS VARCHAR(50)		
	,@strStreetAddress	AS VARCHAR(50)		
	,@strCity			AS VARCHAR(50)		
	,@strState			AS VARCHAR(50)		
	,@strZip			AS VARCHAR(50)		
	,@strPhoneNumber	AS VARCHAR(50)		
	,@strEmail			AS VARCHAR(50)		
	
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	SELECT @intSponsorID = MAX(intSponsorID) + 1 
	FROM TSponsors (TABLOCKX) -- lock table until end of transaction

	-- default to 1 if table is empty
	SELECT @intSponsorID = COALESCE(@intSponsorID, 1)

	INSERT INTO TSponsors (intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail )
	VALUES				(@intSponsorID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail )


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--SELECT * FROM TSponsors

--DECLARE @intSponsorID AS INTEGER = 0
--EXECUTE uspAddSponsor @intSponsorID OUTPUT, 'Max', 'Amillion', '2306 Nantucket Ln.', 'West Chester', 'OH', '45254', '5137458962', 'M.Amillion@yahoo.com'
--PRINT 'Sponsor ID = ' + CONVERT(VARCHAR, @intSponsorID)

--SELECT * FROM TSponsors

-- --------------------------------------------------------------------------------
-- Create a stored procedure to update a Sponsor - uspUpdateSponsor
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspUpdateSponsor
	 @intSponsorID		AS INTEGER OUTPUT			
	,@strFirstName		AS VARCHAR(50)		
	,@strLastName		AS VARCHAR(50)		
	,@strStreetAddress	AS VARCHAR(50)		
	,@strCity			AS VARCHAR(50)		
	,@strState			AS VARCHAR(50)		
	,@strZip			AS VARCHAR(50)		
	,@strPhoneNumber	AS VARCHAR(50)		
	,@strEmail			AS VARCHAR(50)		
	
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	--SELECT @intSponsorID 
	--FROM TSponsors (TABLOCKX) -- lock table until end of transaction

	UPDATE TSponsors 
	SET				strFirstName = @strFirstName, strLastName = @strLastName, strStreetAddress = @strStreetAddress, strCity = @strCity, strState = @strState, 
					strZip = @strZip, strPhoneNumber = @strPhoneNumber, strEmail = @strEmail
	WHERE			intSponsorID = @intSponsorID


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--SELECT * FROM TSponsors

--DECLARE @intSponsorID AS INTEGER = 2
--EXECUTE uspUpdateSponsor @intSponsorID OUTPUT, 'Max', 'Amillion', '2306 Nantucket Ln.', 'West Chester', 'OH', '45254', '5137458962', 'M.Amillion@yahoo.com'
--PRINT 'Sponsor ID = ' + CONVERT(VARCHAR, @intSponsorID) 

--SELECT * FROM TSponsors

-- --------------------------------------------------------------------------------
-- Create a stored procedure to delete a Sponsor - uspDeleteSponsor
-- --------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspDeleteSponsor
	 @intSponsorID		AS INTEGER OUTPUT			
	,@strFirstName		AS VARCHAR(50)		
	,@strLastName		AS VARCHAR(50)		
	,@strStreetAddress	AS VARCHAR(50)		
	,@strCity			AS VARCHAR(50)		
	,@strState			AS VARCHAR(50)		
	,@strZip			AS VARCHAR(50)		
	,@strPhoneNumber	AS VARCHAR(50)		
	,@strEmail			AS VARCHAR(50)		
	
AS

SET XACT_ABORT ON --terminate and rollback if any errors

BEGIN TRANSACTION

	--SELECT @intSponsorID 
	--FROM TSponsors (TABLOCKX) -- lock table until end of transaction

	DELETE FROM TSponsors 
	WHERE		intSponsorID = @intSponsorID


COMMIT TRANSACTION

GO

-- Test it and see if it works.

--SELECT * FROM TSponsors

--DECLARE @intSponsorID AS INTEGER = 3
--EXECUTE uspDeleteSponsor @intSponsorID , 'Max', 'Amillion', '2306 Nantucket Ln.', 'West Chester', 'OH', '45254', '5137458962', 'M.Amillion@yahoo.com'
--PRINT 'Sponsor ID = ' + CONVERT(VARCHAR, @intSponsorID) 

--SELECT * FROM TSponsors

-- -------------------------------------------------------------------------------------------
-- Create a stored procedure to add a Golfer to an Event - uspAddGolferEventYear
-- -------------------------------------------------------------------------------------------
	
GO

CREATE PROCEDURE uspAddGolferEventYear
	 @intGolferEventYearID 		AS INTEGER OUTPUT
	,@intGolferID 				AS INTEGER
	,@intEventYearID 			AS INTEGER
	
AS
SET NOCOUNT ON		-- Report only errors
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error

BEGIN TRANSACTION

	

	INSERT INTO TGolferEventYears WITH (TABLOCKX) ( intGolferID, intEventYearID )
	VALUES( @intGolferID, @intEventYearID )

	SELECT @intGolferEventYearID = MAX(intGolferEventYearID)
	FROM TGolferEventYears

COMMIT TRANSACTION

GO

-- Test it
--DECLARE @intGolferEventYearID AS INTEGER = 0;
--EXECUTE uspAddGolferEventYear @intGolferEventYearID OUTPUT, 5, 3
--PRINT 'Golfer Event Year ID = ' + CONVERT( VARCHAR, @intGolferEventYearID)   

-- -----------------------------------------------------------------------------------------------
-- Create a stored procedure to delete a Golfer from an Event - uspDeleteGolferEventYear
-- -----------------------------------------------------------------------------------------------
	
GO

CREATE PROCEDURE uspDeleteGolferEventYear
	 @intGolferEventYearID 		AS INTEGER OUTPUT
	,@intGolferID				AS INTEGER
	,@intEventYearID 			AS INTEGER
	
AS
SET NOCOUNT ON		-- Report only errors
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error

BEGIN TRANSACTION

	--SELECT @intGolferEventYearID 
	--FROM TGolferEventYears (TABLOCKX) -- lock table until end of transaction

	DELETE FROM TGolferEventYears 
	WHERE		intGolferEventYearID = @intGolferEventYearID

COMMIT TRANSACTION

GO


-- Test it
--DECLARE @intGolferEventYearID AS INTEGER = 4;
--EXECUTE uspDeleteGolferEventYear @intGolferEventYearID, 5, 3
--PRINT 'Golfer Event Year ID = ' + CONVERT( VARCHAR, @intGolferEventYearID)  


-- -------------------------------------------------------------------------------------------------------------
-- Create a stored procedure to delete a Sponsorship from a golfer in an Event - uspDeleteGolferEventYearSponsor
-- -------------------------------------------------------------------------------------------------------------
	
GO

CREATE PROCEDURE uspDeleteGolferEventYearSponsor
	 @intGolferEventYearSponsorID 		AS INTEGER OUTPUT
	,@intGolferID 						AS INTEGER
	,@intEventYearID 					AS INTEGER
	,@intSponsorID 						AS INTEGER
	,@monPledgeAmount 					AS MONEY 
	,@intSponsorTypeID 					AS INTEGER
	,@intPaymentTypeID 					AS INTEGER
	,@intPaidStatusID					AS INTEGER 
	
AS
SET NOCOUNT ON		-- Report only errors
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error

BEGIN TRANSACTION

	--SELECT @intGolferEventYearID 
	--FROM TGolferEventYears (TABLOCKX) -- lock table until end of transaction

	DELETE FROM TGolferEventYearSponsors 
	WHERE		intGolferEventYearSponsorID = @intGolferEventYearSponsorID

COMMIT TRANSACTION

GO


-- Test it
--DECLARE @intGolferEventYearSponsorID AS INTEGER = 5; 
--EXECUTE uspDeleteGolferEventYearSponsor @intGolferEventYearSponsorID, 4, 3, 5, '50.00', 3, 2, 1 
--PRINT 'Golfer Event Year Sponsor ID = ' + CONVERT( VARCHAR, @intGolferEventYearSponsorID)  
	
-- --------------------------------------------------------------------------------
-- Create a stored proc to add a golfer to an event - uspAddGolferAndEvent
-- --------------------------------------------------------------------------------
GO

CREATE PROCEDURE uspAddGolferAndEvent
	 @intGolferEventYearID 		AS INTEGER OUTPUT
	,@intEventYear				AS INTEGER
	,@strFirstName				AS VARCHAR(50)		
	,@strLastName				AS VARCHAR(50)		
	,@strStreetAddress			AS VARCHAR(50)		
	,@strCity					AS VARCHAR(50)		
	,@strState					AS VARCHAR(50)		
	,@strZip					AS VARCHAR(50)		
	,@strPhoneNumber			AS VARCHAR(50)		
	,@strEmail					AS VARCHAR(50)		
	,@intShirtSizeID			AS INTEGER			
	,@intGenderID				AS INTEGER

AS
SET NOCOUNT ON		-- Report only errors
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error

BEGIN TRANSACTION

	DECLARE @intEventYearID		AS INTEGER 
	DECLARE @intGolferID		AS INTEGER 
	
	EXECUTE uspAddEvent @intEventYearID OUTPUT, @intEventYear

	EXECUTE uspAddGolfer @intGolferID OUTPUT, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail, @intShirtSizeID, @intGenderID
	
	EXECUTE uspAddGolferEventYear @intGolferEventYearID OUTPUT, @intGolferID, @intEventYearID
	

COMMIT TRANSACTION

GO

--SELECT * FROM TGolfers
--SELECT * FROM TEventYears
--SELECT * FROM TGolferEventYears


--DECLARE @intGolferEventYearID AS INTEGER 
--EXECUTE uspAddGolferAndEvent @intGolferEventYearID OUTPUT, '2017', 'Anderson', 'Silva', '1206 Triangle Rd.', 'Batavia', 'OH', '45222', '5135531010', 'A.Silva@gmail.com', '2', '2'
--PRINT 'Golfer Event Year ID = ' + CONVERT( VARCHAR, @intGolferEventYearID )

--SELECT * FROM TGolfers
--SELECT * FROM TEventYears
--SELECT * FROM TGolferEventYears


-- --------------------------------------------------------------------------------------------------------------
-- Create a stored procedure to add a Sponsor to a Golfer in an Event - uspAddGolferEventYearSponsor
-- --------------------------------------------------------------------------------------------------------------
	
GO

CREATE PROCEDURE uspAddGolferEventYearSponsor
	 @intGolferEventYearSponsorID 		AS INTEGER OUTPUT
	,@intGolferID 						AS INTEGER
	,@intEventYearID 					AS INTEGER
	,@intSponsorID 						AS INTEGER
	,@monPledgeAmount 					AS MONEY 
	,@intSponsorTypeID 					AS INTEGER
	,@intPaymentTypeID 					AS INTEGER
	,@intPaidStatusID					AS INTEGER 
	
AS
SET NOCOUNT ON		-- Report only errors
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error

BEGIN TRANSACTION

	

	INSERT INTO TGolferEventYearSponsors WITH (TABLOCKX) ( intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, intPaidStatusID )
	VALUES( @intGolferID, @intEventYearID, @intSponsorID, @monPledgeAmount, @intSponsorTypeID, @intPaymentTypeID, @intPaidStatusID )

	SELECT @intGolferEventYearSponsorID = MAX(intGolferEventYearSponsorID)
	FROM TGolferEventYearSponsors

COMMIT TRANSACTION

GO

 --Test it
--DECLARE @intGolferEventYearSponsorID AS INTEGER = 0;
--EXECUTE uspAddGolferEventYearSponsor @intGolferEventYearSponsorID OUTPUT, 2, 2, 2, 25.00, 1, 1, 1 
--PRINT 'Golfer Event Year Sponsor ID = ' + CONVERT( VARCHAR, @intGolferEventYearSponsorID)  

-- -------------------------------------------------------------------------------------
-- Create a stored proc to add a sponsorship to a golfer in an event - uspAddSponsorandGolferEvent
-- -------------------------------------------------------------------------------------
GO

CREATE PROCEDURE uspAddSponsorandGolferEvent
	 @intGolferEventYearSponsorID 		AS INTEGER OUTPUT
	,@intGolferID						AS INTEGER 
	,@intEventYearID					AS INTEGER  
	,@strFirstName						AS VARCHAR(50)		
	,@strLastName						AS VARCHAR(50)		
	,@strStreetAddress					AS VARCHAR(50)		
	,@strCity							AS VARCHAR(50)		
	,@strState							AS VARCHAR(50)		
	,@strZip							AS VARCHAR(50)		
	,@strPhoneNumber					AS VARCHAR(50)		
	,@strEmail							AS VARCHAR(50)		
	,@monPledgeAmount					AS MONEY 
	,@intSponsorTypeID 					AS INTEGER 
	,@intPaymentTypeID 					AS INTEGER 
	,@intPaidStatusID					AS INTEGER 

AS
SET NOCOUNT ON		-- Report only errors
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error

BEGIN TRANSACTION

	DECLARE	@intGolferEventYearID	AS INTEGER 
	DECLARE @intSponsorID			AS INTEGER
		
	EXECUTE uspAddGolferEventYear @intGolferEventYearID OUTPUT, @intGolferID,  @intEventYearID 
	
	EXECUTE uspAddSponsor @intSponsorID OUTPUT, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail

	EXECUTE uspAddGolferEventYearSponsor @intGolferEventYearSponsorID OUTPUT, @intGolferID, @intEventYearID, @intSponsorID, @monPledgeAmount, @intSponsorTypeID, @intPaymentTypeID, @intPaidStatusID


COMMIT TRANSACTION

GO

--SELECT * FROM TGolfers
--SELECT * FROM TEventYears
--SELECT * FROM TSponsors
--SELECT * FROM TGolferEventYearSponsors


--DECLARE @intGolferEventYearSponsorID AS INTEGER 
--EXECUTE uspAddSponsorandGolferEvent @intGolferEventYearSponsorID OUTPUT, '3', '1', 'Connor', 'McGregor', '4571 Laser Cir.', 'Mason', 'OH', '45100', '5138645454', 'C.McGregor@yahoo.com', '100.00', '2', '2', '1'
--PRINT 'Golfer Event Year Sponsor ID = ' + CONVERT( VARCHAR, @intGolferEventYearSponsorID )

--SELECT * FROM TGolfers
--SELECT * FROM TEventYears
--SELECT * FROM TSponsors
--SELECT * FROM TGolferEventYearSponsors

-- --------------------------------------------------------------------------------
-- Add View for available Golfers
-- --------------------------------------------------------------------------------

GO
	
CREATE VIEW vAvailableGolfers
AS

SELECT
	 TG.intGolferID
	,TG.strFirstName + ' ' + TG.strLastName AS FullName
	,TEY.intEventYearID
	,TEY.intEventYear
	--,CONCAT(TG.intGolferID, '-', TEY.intEventYearID) AS COMBO_KEY
FROM

	TGolfers as TG 
	FULL OUTER JOIN TEventYears as TEY
	ON 1 = 1

	Where NOT EXISTS(
		SELECT 1 
		FROM TGolferEventYears AS TGEY
		WHERE TG.intGolferID = TGEY.intGolferID
				AND TEY.intEventYearID = TGEY.intEventYearID) 
   

										
GO

SELECT * FROM vAvailableGolfers

-- --------------------------------------------------------------------------------
-- Add View for Sponsors
-- --------------------------------------------------------------------------------
GO
	
CREATE VIEW vSponsors
AS

SELECT DISTINCT
	 TS.intSponsorID
	,TS.strFirstName
	,TS.strLastName
FROM
	 TSponsors AS TS
	 
GO

SELECT * FROM vSponsors

-- --------------------------------------------------------------------------------
-- Add View for Golfers in Events
-- --------------------------------------------------------------------------------

GO

CREATE VIEW vEventGolfers
AS
SELECT
	 TG.intGolferID
	,TG.strFirstName + ' ' + TG.strLastName AS FullName
	,TEY.intEventYearID	
FROM
	 TEventYears AS TEY
		JOIN TGolferEventYears AS TGEY
			ON TEY.intEventYearID = TGEY.intEventYearID
		JOIN  TGolfers AS TG
			ON TG.intGolferID = TGEY.intGolferID	
GO

SELECT * FROM vEventGolfers


-- ----------------------------------------------------------------------------------------------------
-- Add View for Golfers in Events - additional view with slightly different configuration
-- ----------------------------------------------------------------------------------------------------

GO

CREATE VIEW vEventGolfers1
AS
SELECT
	 TG.intGolferID
	,TG.strFirstName 
	,TG.strLastName 
	,TEY.intEventYearID	
FROM
	 TEventYears AS TEY
		JOIN TGolferEventYears AS TGEY
			ON TEY.intEventYearID = TGEY.intEventYearID
		JOIN  TGolfers AS TG
			ON TG.intGolferID = TGEY.intGolferID	
GO

SELECT * FROM vEventGolfers1

-- --------------------------------------------------------------------------------
-- Add View for Sponsors of Golfers in Events
-- --------------------------------------------------------------------------------

GO

CREATE VIEW vSponsorEventGolfers
AS
SELECT
	  TEY.intEventYearID AS EventYearID 
	 ,TG.intGolferID AS GolferID	
	--,TS.intSponsorID
	--,TGEYS.intGolferEventYearSponsorID 
	 ,TEY.intEventYear AS EventYear 
	 ,TG.strFirstName + ' ' + TG.strLastName AS GolferName 
	 ,TS.strFirstName + ' ' + TS.strLastName AS SponsorName 
	 ,FORMAT(TGEYS.monPledgeAmount, 'c') AS PledgeAmount
	 ,TST.strSponsorTypeDesc AS SponsorType            
	 ,TPT.strPaymentTypeDesc AS PaymentType
	 ,TPS.strPaidStatusDesc AS PaidStatus
FROM
	 TSponsors AS TS
		JOIN TGolferEventYearSponsors AS TGEYS
			ON TS.intSponsorID = TGEYS.intSponsorID 
		JOIN TGolfers AS TG
			ON TG.intGolferID = TGEYS.intGolferID
		JOIN TEventYears AS TEY
			ON TEY.intEventYearID = TGEYS.intEventYearID
		JOIN TSponsorTypes AS TST
			ON TST.intSponsorTypeID = TGEYS.intSponsorTypeID
		JOIN TPaymentTypes AS TPT
			ON TPT.intPaymentTypeID = TGEYS.intPaymentTypeID
		JOIN TPaidStatus AS TPS
			ON TPS.intPaidStatusID = TGEYS.intPaidStatusID
		 
GO

SELECT * FROM vSponsorEventGolfers

-- ----------------------------------------------------------------------------------------------------
-- Add View for Sponsors of Golfers in Events - reconfigured format for displaying output
-- ----------------------------------------------------------------------------------------------------

GO

CREATE VIEW vSponsorEventGolfers1
AS
SELECT
	 TEY.intEventYearID AS EventYearID 
	 ,TGEYS.intGolferEventYearSponsorID AS SponsorshipID
	 ,TG.intGolferID AS GolferID	
	 ,TS.intSponsorID AS SponsorID
	--,TGEYS.intGolferEventYearSponsorID 
	 ,TEY.intEventYear AS EventYear 
	 ,TG.strFirstName AS GolferFirstName
	 ,TG.strLastName  AS GolferLastName
	 ,TS.strFirstName AS SponsorFirstName  
	 ,TS.strLastName AS SponsorLastName 
	 ,FORMAT(TGEYS.monPledgeAmount, 'c') AS PledgeAmount
	 ,TST.strSponsorTypeDesc AS SponsorType            
	 ,TPT.strPaymentTypeDesc AS PaymentType
	 ,TPS.strPaidStatusDesc AS PaidStatus
FROM
	 TSponsors AS TS
		JOIN TGolferEventYearSponsors AS TGEYS
			ON TS.intSponsorID = TGEYS.intSponsorID 
		JOIN TGolfers AS TG
			ON TG.intGolferID = TGEYS.intGolferID
		JOIN TEventYears AS TEY
			ON TEY.intEventYearID = TGEYS.intEventYearID
		JOIN TSponsorTypes AS TST
			ON TST.intSponsorTypeID = TGEYS.intSponsorTypeID
		JOIN TPaymentTypes AS TPT
			ON TPT.intPaymentTypeID = TGEYS.intPaymentTypeID
		JOIN TPaidStatus AS TPS
			ON TPS.intPaidStatusID = TGEYS.intPaidStatusID

GO

SELECT * FROM vSponsorEventGolfers1

-- -------------------------------------------------------------------------------------------
-- Create a view to see total amounts pledged for golfer, by sponsor, and yearly for event	
-- -------------------------------------------------------------------------------------------
	
GO

CREATE VIEW vTotalPledgedGolfer
AS
SELECT 
		 TG.intGolferID
		,TG.strFirstName + ' ' + TG.strLastName AS GolferName
		,COUNT(TG.intGolferID) AS Pledges
		,FORMAT(SUM(TGEYS.monPledgeAmount), 'c') AS TotalPledgedGolfer
		,TEY.intEventYearID
		 
FROM  
		TSponsors AS TS
		JOIN TGolferEventYearSponsors AS TGEYS
			ON TS.intSponsorID = TGEYS.intSponsorID 
		JOIN TGolfers AS TG
			ON TG.intGolferID = TGEYS.intGolferID
		JOIN TEventYears AS TEY
			ON TEY.intEventYearID = TGEYS.intEventYearID
WHERE 
		TEY.intEventYearID = TEY.intEventYearID
		AND TG.intGolferID = TG.intGolferID
GROUP BY
	TG.strFirstName
	,TG.strLastName
	,TG.intGolferID
	,TEY.intEventYearID

GO

SELECT * FROM vTotalPledgedGolfer

-- Test it
--DECLARE @intGolferEventYearSponsorID AS INTEGER;
--EXECUTE vTotalPledgedGolfer @intGolferEventYearSponsorID OUTPUT, 1, 1, 50.00
--PRINT 'Golfer Event Year ID = ' + CONVERT( VARCHAR, @intGolferEventYearSponsorID)  

-- -------------------------------------------------------------------------------------------
-- Step #13.19: Create a view to add total amounts pledged 
--	for golfer, by sponsor, and yearly for event	- uspTotalPledgedSponsor
-- -------------------------------------------------------------------------------------------
	
GO

CREATE VIEW vTotalPledgedSponsor
AS
SELECT
		TS.intSponsorID
		,TS.strFirstName + ' ' + TS.strLastName AS SponsorName
		,COUNT(TS.intSponsorID) AS Pledges
		,FORMAT(SUM(TGEYS.monPledgeAmount), 'c') AS TotalPledgedSponsor
		,TEY.intEventYearID AS EventYearID
FROM  
		TSponsors AS TS
		JOIN TGolferEventYearSponsors AS TGEYS
			ON TS.intSponsorID = TGEYS.intSponsorID 
		JOIN TGolfers AS TG
			ON TG.intGolferID = TGEYS.intGolferID
		JOIN TEventYears AS TEY
			ON TEY.intEventYearID = TGEYS.intEventYearID
WHERE 
		TEY.intEventYearID = TEY.intEventYearID 
		AND TS.intSponsorID = TS.intSponsorID
GROUP BY
		TS.intSponsorID
	,TS.strFirstName
	,TS.strLastName
	,TEY.intEventYearID

GO

SELECT * FROM vTotalPledgedSponsor

-- Test it
--DECLARE @intGolferEventYearSponsorID AS INTEGER;
--EXECUTE vTotalPledgedSponsor @intGolferEventYearSponsorID OUTPUT, 1, 2, 15.00
--PRINT 'Golfer Event Year ID = ' + CONVERT( VARCHAR, @intGolferEventYearSponsorID)  

-- -------------------------------------------------------------------------------------------
-- Step #13.20: Create a view to add total amounts pledged for event - uspTotalPledgedEvent
-- -------------------------------------------------------------------------------------------
	
GO

CREATE VIEW vTotalPledgedEvent
AS
SELECT 
		FORMAT(SUM(TGEYS.monPledgeAmount), 'c') AS TotalPledgedEvent
	,TEY.intEventYearID
	,TEY.intEventYear	 
FROM  
		TSponsors AS TS
		JOIN TGolferEventYearSponsors AS TGEYS
			ON TS.intSponsorID = TGEYS.intSponsorID 
		JOIN TGolfers AS TG
			ON TG.intGolferID = TGEYS.intGolferID
		JOIN TEventYears AS TEY
			ON TEY.intEventYearID = TGEYS.intEventYearID
WHERE 
		TEY.intEventYearID = TEY.intEventYearID
GROUP BY
		TEY.intEventYearID
	   ,TEY.intEventYear
GO

SELECT * FROM vTotalPledgedEvent

-- Test it
--DECLARE @intGolferEventYearSponsorID AS INTEGER;
--EXECUTE vTotalPledgedEvent @intGolferEventYearSponsorID OUTPUT, 1, 25.00
--PRINT 'Golfer Event Year ID = ' + CONVERT( VARCHAR, @intGolferEventYearSponsorID)  











