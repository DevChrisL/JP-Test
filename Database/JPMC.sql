/****** Object:  Table [dbo].[Account]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](30) NULL,
	[AccountType] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditLog]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLog](
	[NewLeadsOutput] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catagory]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catagory](
	[CatagoryID] [int] IDENTITY(1,1) NOT NULL,
	[CatagoryName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CatagoryID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](40) NULL,
	[fName] [varchar](20) NULL,
	[lName] [varchar](20) NULL,
	[CompanyID] [int] NULL,
	[PhoneNum] [numeric](10, 0) NULL,
	[EmpID] [int] NULL,
	[CatagoryID] [int] NULL,
	[JoinDate] [datetime] NULL,
	[inactive] [int] NULL,
 CONSTRAINT [PK__Client__E67E1A04F0C233F8] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[CompanyRevenue] [int] NULL,
	[CatagoryID] [int] NULL,
	[employees] [int] NULL,
 CONSTRAINT [PK__Company__2D971C4CB58FBC89] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deal]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deal](
	[DealID] [int] IDENTITY(1,1) NOT NULL,
	[DealDate] [date] NULL,
	[ClientID] [int] NULL,
	[EmpID] [int] NULL,
	[ProductID] [int] NULL,
	[CatagoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DealID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EMPID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](40) NULL,
	[fName] [varchar](20) NULL,
	[lName] [varchar](20) NULL,
	[AccountID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EMPID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting](
	[MeetingID] [int] IDENTITY(1,1) NOT NULL,
	[MeetingTime] [varchar](15) NULL,
	[MeetingDate] [date] NULL,
	[ClientID] [int] NULL,
	[EmpID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MeetingID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[NoteID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NULL,
	[NoteName] [varchar](30) NULL,
	[Contents] [varchar](1024) NULL,
	[CatagoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NoteID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(100000,1) NOT NULL,
	[ProductName] [varchar](50) NULL,
	[ProductPrice] [int] NULL,
	[CatagoryID] [int] NULL,
	[CreateDate] [date] NULL,
	[ProductDescription] [varchar](1024) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[SaleID] [int] NOT NULL,
	[SaleDate] [date] NULL,
	[ClientID] [int] NULL,
	[EmpID] [int] NULL,
	[ProductID] [int] NULL,
	[CatagoryID] [int] NULL,
	[Alert] [bit] NULL,
	[fk_DealID] [int] NULL,
	[SaleRevenue] [int] NULL,
 CONSTRAINT [PK__Sale__1EE3C41F0760B393] PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 4/28/2023 4:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [varchar](30) NULL,
	[EmpID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK__Client__Catagory__2B0A656D] FOREIGN KEY([CatagoryID])
REFERENCES [dbo].[Catagory] ([CatagoryID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK__Client__Catagory__2B0A656D]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK__Client__CompanyI__29221CFB] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK__Client__CompanyI__29221CFB]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK__Client__EmpID__2A164134] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EMPID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK__Client__EmpID__2A164134]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK__Company__Catagor__160F4887] FOREIGN KEY([CatagoryID])
REFERENCES [dbo].[Catagory] ([CatagoryID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK__Company__Catagor__160F4887]
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD FOREIGN KEY([CatagoryID])
REFERENCES [dbo].[Catagory] ([CatagoryID])
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD  CONSTRAINT [FK__Deal__ClientID__3F115E1A] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Deal] CHECK CONSTRAINT [FK__Deal__ClientID__3F115E1A]
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EMPID])
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK__Meeting__ClientI__46B27FE2] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK__Meeting__ClientI__46B27FE2]
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EMPID])
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD FOREIGN KEY([CatagoryID])
REFERENCES [dbo].[Catagory] ([CatagoryID])
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EMPID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CatagoryID])
REFERENCES [dbo].[Catagory] ([CatagoryID])
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK__Sale__CatagoryID__3587F3E0] FOREIGN KEY([CatagoryID])
REFERENCES [dbo].[Catagory] ([CatagoryID])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK__Sale__CatagoryID__3587F3E0]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK__Sale__ClientID__32AB8735] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK__Sale__ClientID__32AB8735]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK__Sale__EmpID__339FAB6E] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EMPID])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK__Sale__EmpID__339FAB6E]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK__Sale__ProductID__3493CFA7] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK__Sale__ProductID__3493CFA7]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EMPID])
GO
