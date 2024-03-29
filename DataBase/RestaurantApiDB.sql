USE [RestaurantDB]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdRestaurant] [int] NOT NULL,
	[IdReservationStatus] [int] NOT NULL,
	[ReservationHour] [datetime] NOT NULL,
	[ReservationNotes] [varchar](200) NOT NULL,
	[ContactNumber] [varchar](20) NOT NULL,
	[ReservationName] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationStatus]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ReservationStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurant]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[OpeningHour] [time](0) NOT NULL,
	[ClosingHour] [time](0) NOT NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([Id], [IdUser], [IdRestaurant], [IdReservationStatus], [ReservationHour], [ReservationNotes], [ContactNumber], [ReservationName]) VALUES (2, 1, 1, 1, CAST(N'2022-01-17T17:56:00.000' AS DateTime), N'aaaaaa', N'wwww', N'ssss')
SET IDENTITY_INSERT [dbo].[Reservation] OFF
GO
SET IDENTITY_INSERT [dbo].[ReservationStatus] ON 

INSERT [dbo].[ReservationStatus] ([Id], [StatusName]) VALUES (1, N'Reserved')
INSERT [dbo].[ReservationStatus] ([Id], [StatusName]) VALUES (2, N'Assited')
INSERT [dbo].[ReservationStatus] ([Id], [StatusName]) VALUES (3, N'Canceled')
SET IDENTITY_INSERT [dbo].[ReservationStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Restaurant] ON 

INSERT [dbo].[Restaurant] ([Id], [Name], [Address], [OpeningHour], [ClosingHour]) VALUES (1, N'Restaurant 1', N'cll 13 13 13', CAST(N'08:00:00' AS Time), CAST(N'20:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Restaurant] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Email], [Password], [Name], [Address]) VALUES (1, N'raulforero@hotmail.com', N'Taminango1@', N'Raul Forero', N'lll')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_ReservationStatus] FOREIGN KEY([IdReservationStatus])
REFERENCES [dbo].[ReservationStatus] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_ReservationStatus]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Restaurant] FOREIGN KEY([IdRestaurant])
REFERENCES [dbo].[Restaurant] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Restaurant]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_User]
GO
/****** Object:  StoredProcedure [dbo].[PA_DEL_ReservationById]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_DEL_ReservationById]
@Id int
AS
BEGIN
	Delete from [Reservation] where id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[PA_INS_Reservation]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_INS_Reservation]
	@IdUser int,@IdRestaurant int,@IdReservationStatus int,@ReservationHour datetime,@ReservationNotes varchar(200),@ContactNumber varchar(20),@ReservationName varchar(200)
AS
BEGIN
  insert into Reservation 
		(IdUser,IdRestaurant,IdReservationStatus,ReservationHour,ReservationNotes,ContactNumber,ReservationName)
		values 
		(@IdUser,@IdRestaurant,@IdReservationStatus,@ReservationHour,@ReservationNotes,@ContactNumber,@ReservationName)

  SELECT SCOPE_IDENTITY() AS Id
END

GO
/****** Object:  StoredProcedure [dbo].[PA_INS_ReservationStatus]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_INS_ReservationStatus]
	@StatusName varchar(20)
AS
BEGIN
  insert into ReservationStatus 
		(StatusName)
		values 
		(@StatusName)

  SELECT SCOPE_IDENTITY() AS Id
END

GO
/****** Object:  StoredProcedure [dbo].[PA_INS_Restaurant]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_INS_Restaurant]
	@Name varchar(50),@Address varchar(100),@OpeningHour time,@ClosingHour time
AS
BEGIN
  insert into Restaurant 
		(Name,Address,OpeningHour,ClosingHour)
		values 
		(@Name,@Address,@OpeningHour,@ClosingHour)

  SELECT SCOPE_IDENTITY() AS Id
END

GO
/****** Object:  StoredProcedure [dbo].[PA_INS_User]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_INS_User]
	@Email varchar(100),@Password varchar(10),@Name varchar(100),@Address varchar(100)
AS
BEGIN
  insert into [User] 
		(Email,Password,Name,Address)
		values 
		(@Email,@Password,@Name,@Address)

  SELECT SCOPE_IDENTITY() AS Id
END

GO
/****** Object:  StoredProcedure [dbo].[PA_Login_User]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_Login_User]
	@Email varchar(100), @Password varchar(100)
AS
BEGIN
	SELECT * FROM [User]
	WHERE Email=@Email AND Password=@Password
END
            
GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_ReservationByHour]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_ReservationByHour]
@Hour datetime
AS
BEGIN
	select * from Reservation where ReservationHour = @Hour
END
GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_ReservationGetAll]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_ReservationGetAll]
AS
BEGIN 
    SELECT * FROM Reservation
    
END

GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_ReservationGetAllByReservationStatus]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_ReservationGetAllByReservationStatus]
@IdReservationStatus int
AS
BEGIN 
    SELECT * FROM Reservation
    WHERE IdReservationStatus=@IdReservationStatus 
END
            
GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_ReservationGetAllByRestaurant]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_ReservationGetAllByRestaurant]
@IdRestaurant int
AS
BEGIN 
    SELECT * FROM Reservation
    WHERE IdRestaurant=@IdRestaurant 
END

GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_ReservationGetAllByUser]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_ReservationGetAllByUser]
@IdUser int
AS
BEGIN 
    SELECT * FROM Reservation
    WHERE IdUser=@IdUser 
END

GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_ReservationGetById]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_ReservationGetById]
    @Id int
AS
BEGIN
    SELECT * FROM Reservation
    WHERE Id=@Id
END

GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_ReservationStatusGetAll]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_ReservationStatusGetAll]
AS
BEGIN 
    SELECT * FROM ReservationStatus
    
END

GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_ReservationStatusGetById]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_ReservationStatusGetById]
    @Id int
AS
BEGIN
    SELECT * FROM ReservationStatus
    WHERE Id=@Id
END

GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_RestaurantGetAll]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_RestaurantGetAll]
AS
BEGIN 
    SELECT * FROM Restaurant
    
END

GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_RestaurantGetById]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_RestaurantGetById]
    @Id int
AS
BEGIN
    SELECT * FROM Restaurant
    WHERE Id=@Id
END

GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_UserByEmail]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_UserByEmail]
@Email varchar(100)
AS
BEGIN
	Select * from [User] where email=@Email
END
GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_UserGetAll]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_UserGetAll]
AS
BEGIN 
    SELECT * FROM [User]
    
END

GO
/****** Object:  StoredProcedure [dbo].[PA_SEL_UserGetById]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_SEL_UserGetById]
    @Id int
AS
BEGIN
    SELECT * FROM [User]
    WHERE Id=@Id
END

GO
/****** Object:  StoredProcedure [dbo].[PA_UPD_Reservation]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_UPD_Reservation]
    @Id int,@IdUser int,@IdRestaurant int,@IdReservationStatus int,@ReservationHour datetime,@ReservationNotes varchar(200),@ContactNumber varchar(20),@ReservationName varchar(200)
AS
BEGIN
    UPDATE Reservation SET
    IdUser = @IdUser,IdRestaurant = @IdRestaurant,IdReservationStatus = @IdReservationStatus,ReservationHour = @ReservationHour,ReservationNotes = @ReservationNotes,ContactNumber = @ContactNumber,ReservationName = @ReservationName
    WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[PA_UPD_ReservationStatus]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_UPD_ReservationStatus]
    @Id int,@StatusName varchar(20)
AS
BEGIN
    UPDATE ReservationStatus SET
    StatusName = @StatusName
    WHERE Id = @Id
END

            
GO
/****** Object:  StoredProcedure [dbo].[PA_UPD_Restaurant]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_UPD_Restaurant]
    @Id int,@Name varchar(50),@Address varchar(100),@OpeningHour time,@ClosingHour time
AS
BEGIN
    UPDATE Restaurant SET
    Name = @Name,Address = @Address,OpeningHour = @OpeningHour,ClosingHour = @ClosingHour
    WHERE Id = @Id
END

            
GO
/****** Object:  StoredProcedure [dbo].[PA_UPD_User]    Script Date: 18/01/2022 5:50:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_UPD_User]
    @Id int,@Email varchar(100),@Password varchar(10),@Name varchar(100),@Address varchar(100)
AS
BEGIN
    UPDATE [User] SET
    Email = @Email,Password = @Password,Name = @Name,Address = @Address
    WHERE Id = @Id
END

GO
