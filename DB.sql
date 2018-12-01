USE master 
GO 

IF EXISTS(SELECT * FROM sys.databases WHERE name='Parsing') 
BEGIN 
DROP DATABASE Parsing
END 
GO 

CREATE DATABASE Parsing
GO 

USE Parsing
GO

CREATE TABLE [Site](
	id int IDENTITY(1,1) CONSTRAINT[PK_SITE] primary key,
	[Name] varchar(100) NOT NULL UNIQUE
)
GO

CREATE TABLE Shop(
	id int identity(1,1) constraint[PK_SHOP] primary key,
	[Name] varchar(100) NOT NULL,
	Discount float NOT NULL,
	Url_on_site varchar(200) NOT NULL,
	[Image] varchar(200) NOT NULL,
	Date_add datetime NOT NULL,
	id_site int NOT NULL,
	Label varchar(15) NOT NULL
)
GO

Create table Account(
	id int identity(1,1) constraint[PK_ACCOUNT] primary key,
	[Name] varchar(300) NOT NULL UNIQUE,
	[Password] varchar(500) NOT NULL,
	[Access] int,
)
GO

INSERT INTO dbo.Account
	([Name],
	[Password],
	[Access])
Values
	('admin',
	'admin',
	1)
GO


ALTER TABLE Shop add constraint[FK_Shop_Site]
Foreign key (id_site) references [Site](id)
on delete cascade
on update cascade
GO

create procedure AddSite
	@Name varchar(100)
AS
BEGIN
	INSERT INTO [dbo].[Site]
		([Name])
	Values(
		@Name)

	SELECT SCOPE_IDENTITY()
END
GO

create procedure AddShop
	@Name varchar(100),
	@Discount float,
	@Url varchar(200),
	@Image varchar(200),
	@DateAdd datetime,
	@SiteID int,
	@Label varchar(15)
AS
BEGIN
	INSERT INTO [dbo].[Shop]
		([Name],
		[Discount],
		[Url_on_site],
		[Image],
		[Date_add],
		[id_site],
		[Label])
	Values(
		@Name,
		@Discount,
		@Url,
		@Image,
		@DateAdd,
		@SiteID,
		@Label)

	SELECT SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE GetAllSite
AS
BEGIN
	SELECT [Name],
	id
	FROM [Site]
END
GO

CREATE PROCEDURE GetAllShop
AS
BEGIN
	Select id,
	[Name],
	Discount,
	Url_on_site,
	[Image],
	Date_add,
	id_site,
	Label
	FROM Shop
END
GO

CREATE PROCEDURE GetShopsBySiteID
	@SiteID int
AS
BEGIN
	Select Shop.id,
	Shop.[Name],
	Discount,
	Url_on_site,
	[Image],
	Date_add,
	id_site,
	Label
	FROM Shop
	JOIN [Site] ON Shop.id_site = [Site].id
	WHERE [Site].id = @SiteID
END
GO

CREATE PROCEDURE GetSiteByID
	@SiteID int
AS
Begin
	SELECT id,
	[Name]
	FROM [Site]
	WHERE id = @SiteID
END
GO

Create procedure GetShopByName
	@Name varchar(100)
AS
begin
	Select id,
	[Name],
	Discount,
	Url_on_site,
	[Image],
	Date_add,
	id_site,
	Label
	FROM Shop
	WHERE [Name]=@Name
end
go

create procedure GetShopByDiscount
	@Discount float
as
begin
	Select id,
	[Name],
	Discount,
	Url_on_site,
	[Image],
	Date_add,
	id_site,
	Label
	FROM Shop
	WHERE Discount = @Discount
end
go

create procedure GetSiteByName
	@Name varchar(100)
as
begin
	SELECT id,
	[Name]
	FROM [Site]
	WHERE [Name] = @Name
end
go

create procedure UpdateSite
	@Name varchar(100),
	@SiteID int
AS
begin
UPDATE [dbo].[Site]
   SET [Name] = @Name
 WHERE id = @SiteID
end
GO

create procedure DeleteDataFromShop
AS
begin
	DELETE FROM [dbo].[Shop]
end
go

create procedure Registration
	@Name varchar(300),
	@Password varchar(500),
	@Access int = 0
AS
begin
	INSERT INTO dbo.Account
	([Name],
	[Password],
	[Access])
	Values
	(@Name,
	@Password,
	@Access)
End
go

create procedure GetUsers
AS
begin
	select id,
	[Name],
	[Password]
	from Account
end
go

create procedure GetUserByID
	@UserID int
as
begin
	Select id,
	[Name],
	[Password]
	FROM Account
	Where id = @UserID
end
go

Create procedure GetUserByName
	@Name varchar(300)
as
begin
	Select id,
	[Name],
	[Password]
	From Account
	where [Name] = @Name
end
