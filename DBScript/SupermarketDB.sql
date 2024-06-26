CREATE DATABASE [Supermarket]

USE [Supermarket]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producers]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[country] [varchar](100) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Producers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[barcode] [varchar](10) NOT NULL,
	[category_id] [int] NOT NULL,
	[producer_id] [int] NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[issuance_date] [date] NOT NULL,
	[total] [real] NOT NULL,
	[cashier_id] [int] NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stocks]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [int] NOT NULL,
	[unit] [varchar](10) NOT NULL,
	[supply_date] [date] NOT NULL,
	[expiration_date] [date] NOT NULL,
	[purchase_price] [real] NOT NULL,
	[sale_price] [real] NOT NULL,
	[vat] [real] NOT NULL,
	[product_id] [int] NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Stocks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stocks_Receipts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocks_Receipts](
	[stock_id] [int] NOT NULL,
	[receipt_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[subtotal] [real] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Stocks_Receipts] PRIMARY KEY CLUSTERED 
(
	[stock_id] ASC,
	[receipt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](15) NOT NULL,
	[user_type] [varchar](13) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([id], [name], [active]) VALUES (1, N'Diary', 1)
INSERT [dbo].[Categories] ([id], [name], [active]) VALUES (2, N'Fruits', 1)
INSERT [dbo].[Categories] ([id], [name], [active]) VALUES (3, N'Drinks', 1)
INSERT [dbo].[Categories] ([id], [name], [active]) VALUES (5, N'Tools', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Producers] ON 

INSERT [dbo].[Producers] ([id], [name], [country], [active]) VALUES (1, N'Zuzu', N'Romania', 1)
INSERT [dbo].[Producers] ([id], [name], [country], [active]) VALUES (2, N'BanAnAN', N'Spain', 1)
INSERT [dbo].[Producers] ([id], [name], [country], [active]) VALUES (3, N'ExoticsFruiz', N'Ecuador', 1)
INSERT [dbo].[Producers] ([id], [name], [country], [active]) VALUES (4, N'Aquauaua', N'Italy', 1)
INSERT [dbo].[Producers] ([id], [name], [country], [active]) VALUES (5, N'Coca Cola', N'America', 1)
SET IDENTITY_INSERT [dbo].[Producers] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (1, N'Milk', N'123457', 1, 1, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (2, N'Banana', N'6345462', 2, 2, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (5, N'Pomegranate', N'77424', 2, 3, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (6, N'Pineapple', N'86536', 2, 3, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (7, N'Smart Water', N'6665551', 3, 4, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (8, N'Coca Cola', N'976434735', 3, 5, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (9, N'Milk', N'123455', 1, 1, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (10, N'Cheese', N'634722222', 1, 1, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (11, N'Butter', N'22313333', 1, 1, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (13, N'Sparkling Water', N'857236', 3, 4, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (14, N'Hammer', N'265234', 5, 2, 1)
INSERT [dbo].[Products] ([id], [name], [barcode], [category_id], [producer_id], [active]) VALUES (16, N'Peach', N'634235', 2, 2, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Receipts] ON 

INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (1, CAST(N'2024-05-12' AS Date), 2634.9, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (2, CAST(N'2024-05-12' AS Date), 627.1, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (3, CAST(N'2024-05-12' AS Date), 544.5, 1, 0)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (4, CAST(N'2024-05-13' AS Date), 8325.4, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (5, CAST(N'2024-05-15' AS Date), 218.4, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (6, CAST(N'2024-05-15' AS Date), 5236, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (7, CAST(N'2024-05-20' AS Date), 947.9, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (8, CAST(N'2024-05-20' AS Date), 9.6, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (9, CAST(N'2024-05-20' AS Date), 9.6, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (10, CAST(N'2024-05-20' AS Date), 0, 1, 0)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (11, CAST(N'2024-05-20' AS Date), 0, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (12, CAST(N'2024-05-20' AS Date), 0, 1, 1)
INSERT [dbo].[Receipts] ([id], [issuance_date], [total], [cashier_id], [active]) VALUES (13, CAST(N'2024-05-21' AS Date), 0, 1, 0)
SET IDENTITY_INSERT [dbo].[Receipts] OFF
GO
SET IDENTITY_INSERT [dbo].[Stocks] ON 

INSERT [dbo].[Stocks] ([id], [quantity], [unit], [supply_date], [expiration_date], [purchase_price], [sale_price], [vat], [product_id], [active]) VALUES (7, 22, N'L', CAST(N'2024-05-07' AS Date), CAST(N'2024-05-31' AS Date), 5, 6, 0.2, 1, 1)
INSERT [dbo].[Stocks] ([id], [quantity], [unit], [supply_date], [expiration_date], [purchase_price], [sale_price], [vat], [product_id], [active]) VALUES (8, 49, N'Kg', CAST(N'2024-05-07' AS Date), CAST(N'2024-06-19' AS Date), 7, 9.1, 0.3, 2, 1)
INSERT [dbo].[Stocks] ([id], [quantity], [unit], [supply_date], [expiration_date], [purchase_price], [sale_price], [vat], [product_id], [active]) VALUES (9, 18, N'Kg', CAST(N'2024-05-07' AS Date), CAST(N'2024-05-21' AS Date), 9, 12.6, 0.4, 5, 0)
INSERT [dbo].[Stocks] ([id], [quantity], [unit], [supply_date], [expiration_date], [purchase_price], [sale_price], [vat], [product_id], [active]) VALUES (10, 20, N'Kg', CAST(N'2024-05-07' AS Date), CAST(N'2024-05-25' AS Date), 11, 36.3, 2.3, 6, 0)
INSERT [dbo].[Stocks] ([id], [quantity], [unit], [supply_date], [expiration_date], [purchase_price], [sale_price], [vat], [product_id], [active]) VALUES (11, 91, N'L', CAST(N'2024-05-07' AS Date), CAST(N'2025-11-14' AS Date), 6, 7.8, 0.3, 7, 1)
INSERT [dbo].[Stocks] ([id], [quantity], [unit], [supply_date], [expiration_date], [purchase_price], [sale_price], [vat], [product_id], [active]) VALUES (13, 24, N'L', CAST(N'2024-05-07' AS Date), CAST(N'2026-01-01' AS Date), 6, 9.6, 0.6, 8, 1)
INSERT [dbo].[Stocks] ([id], [quantity], [unit], [supply_date], [expiration_date], [purchase_price], [sale_price], [vat], [product_id], [active]) VALUES (15, 0, N'Pcs', CAST(N'2024-05-12' AS Date), CAST(N'2028-08-01' AS Date), 36.5, 51.1, 0.4, 14, 0)
INSERT [dbo].[Stocks] ([id], [quantity], [unit], [supply_date], [expiration_date], [purchase_price], [sale_price], [vat], [product_id], [active]) VALUES (16, 80, N'Pcs', CAST(N'2024-05-15' AS Date), CAST(N'2029-12-28' AS Date), 34, 47.6, 0.4, 14, 1)
SET IDENTITY_INSERT [dbo].[Stocks] OFF
GO
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (7, 5, 14, 84, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (8, 1, 24, 218.4, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (9, 4, 30, 378, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (10, 3, 15, 544.5, 0)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (10, 7, 13, 471.9, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (11, 1, 15, 117, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (11, 4, 10, 78, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (13, 2, 60, 576, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (13, 5, 14, 134.4, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (13, 8, 1, 9.6, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (13, 9, 1, 9.6, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (15, 1, 45, 2299.5, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (15, 2, 1, 51.1, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (15, 4, 154, 7869.4, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (16, 6, 110, 5236, 1)
INSERT [dbo].[Stocks_Receipts] ([stock_id], [receipt_id], [quantity], [subtotal], [active]) VALUES (16, 7, 10, 476, 1)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [username], [password], [user_type], [active]) VALUES (1, N'cashier', N'123', N'Cashier', 1)
INSERT [dbo].[Users] ([id], [username], [password], [user_type], [active]) VALUES (2, N'gataa', N'ajunge', N'Administrator', 0)
INSERT [dbo].[Users] ([id], [username], [password], [user_type], [active]) VALUES (5, N'admin', N'123', N'Administrator', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Barcode]    Script Date: 5/25/2024 4:07:44 PM ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [UQ_Barcode] UNIQUE NONCLUSTERED 
(
	[barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_username]    Script Date: 5/25/2024 4:07:44 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[Producers] ADD  CONSTRAINT [DF_Producers_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[Receipts] ADD  CONSTRAINT [DF_Receipts_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[Stocks] ADD  CONSTRAINT [DF_Stocks_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[Stocks_Receipts] ADD  CONSTRAINT [DF_Stocks_Receipts_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Producers] FOREIGN KEY([producer_id])
REFERENCES [dbo].[Producers] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Producers]
GO
ALTER TABLE [dbo].[Receipts]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Users] FOREIGN KEY([cashier_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Receipts] CHECK CONSTRAINT [FK_Receipts_Users]
GO
ALTER TABLE [dbo].[Stocks]  WITH CHECK ADD  CONSTRAINT [FK_Stocks_Products] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[Stocks] CHECK CONSTRAINT [FK_Stocks_Products]
GO
ALTER TABLE [dbo].[Stocks_Receipts]  WITH CHECK ADD  CONSTRAINT [FK_Stocks_Receipts_Receipts] FOREIGN KEY([receipt_id])
REFERENCES [dbo].[Receipts] ([id])
GO
ALTER TABLE [dbo].[Stocks_Receipts] CHECK CONSTRAINT [FK_Stocks_Receipts_Receipts]
GO
ALTER TABLE [dbo].[Stocks_Receipts]  WITH CHECK ADD  CONSTRAINT [FK_Stocks_Receipts_Stocks] FOREIGN KEY([stock_id])
REFERENCES [dbo].[Stocks] ([id])
GO
ALTER TABLE [dbo].[Stocks_Receipts] CHECK CONSTRAINT [FK_Stocks_Receipts_Stocks]
GO
/****** Object:  StoredProcedure [dbo].[ActivateCategory]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActivateCategory]
	@categoryId int

AS
BEGIN
	Update Categories
	set [active] = 1
	where id = @categoryId;
END
GO
/****** Object:  StoredProcedure [dbo].[ActivateProducer]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActivateProducer]
	@producerId int

AS
BEGIN
	Update Producers
	set [active] = 1
	where id = @producerId;
END
GO
/****** Object:  StoredProcedure [dbo].[ActivateProduct]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActivateProduct]
	@productId int

AS
BEGIN
	Update Products
	set [active] = 1
	where id = @productId;
END
GO
/****** Object:  StoredProcedure [dbo].[ActivateStock]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActivateStock]
	@stockId int
AS
BEGIN
	Update Stocks 
	set active = 1
	where id = @stockId;
END
GO
/****** Object:  StoredProcedure [dbo].[ActivateUser]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActivateUser]
	@userId int
AS
BEGIN
	Update Users 
	set active = 1
	where id = @userId;
END
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategory]
	@categoryName varchar(100)
AS
BEGIN
	insert into Categories([name],[active])
	values (@categoryName, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddProducer]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProducer]
	@producerName varchar(50),
	@country varchar(100)
AS
BEGIN
	insert into Producers([name],[country],[active])
	values (@producerName, @country, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct]
	@productName varchar(100),
	@productBarcode varchar(10),
	@categoryId int,
	@producerId int

AS
BEGIN
	INSERT INTO Products([name], [barcode], [category_id], [producer_id], [active])
	VALUES(@productName, @productBarcode, @categoryId, @producerId, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddReceiptProduct]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddReceiptProduct]
	@stockId int,
	@receiptId int,
	@quantity int,
	@subtotal real
AS
BEGIN
	INSERT INTO Stocks_Receipts([stock_id], [receipt_id], [quantity], [subtotal], [active])
	values (@stockId, @receiptId, @quantity, @subtotal, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddStock]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStock]
	@quantity int,
	@unit varchar(10),
	@supplyDate date,
	@expirationDate date,
	@purchasePrice real,
	@vat real,
	@productId int
AS
BEGIN
	insert into Stocks([quantity], [unit], [supply_date], [expiration_date], [purchase_price], [sale_price], [vat], [product_id], [active])
	values(@quantity, @unit, @supplyDate, @expirationDate, ROUND(@purchasePrice, 2), ROUND(@purchasePrice + @purchasePrice * @vat, 2), ROUND(@vat, 2), @productId, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@username varchar(30),
	@password varchar(15),
	@userType varchar(13)
AS
BEGIN
	insert into Users([username],[password],[user_type],[active])
	values (@username, @password, @userType, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[CreateNewReceipt]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateNewReceipt]
	@issuanceDate date,
	@total real,
	@cashierId int,
	@receiptId int OUTPUT
AS
BEGIN
	INSERT into Receipts([issuance_date], [total], [cashier_id], [active])
	values (@issuanceDate, @total, @cashierId, 1);
	select @receiptID = scope_identity();
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategory]
	@categoryId int
AS
BEGIN
	Update Categories
	set [active] = 0
	where id = @categoryId;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProducer]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProducer]
	@producerId int
AS
BEGIN
	Update Producers
	set [active] = 0
	where id = @producerId;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
	@productId int
AS
BEGIN
	Update Products
	set [active] = 0
	where id = @productId;

	update Stocks
	set [active] = 0
	where product_id = @productId;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStock]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStock]
	@stockId int
AS
BEGIN
	update Stocks
	set active = 0
	where id = @stockId;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
	@userId int
AS
BEGIN
	Update Users
	set [active] = 0
	where id = @userId;
END
GO
/****** Object:  StoredProcedure [dbo].[DropReceipt]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DropReceipt]
	@receiptId int
AS
BEGIN
	Update Receipts
	set [active] = 0
	where id = @receiptId;

	Update Stocks_Receipts
	set [active] = 0
	where Stocks_Receipts.receipt_id = @receiptId;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsCategory]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsCategory]
	@categoryName varchar(100)

AS
BEGIN
	SELECT Count(*)
	FROM Categories 
	WHERE [name] = @categoryName
	and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsInactiveCategory]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsInactiveCategory]
	@categoryName varchar(100)

AS
BEGIN
	SELECT Count(*)
	FROM Categories 
	WHERE [name] = @categoryName
	and active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsInactiveProducer]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsInactiveProducer]
	@producerName varchar(50),
	@country varchar(100)

AS
BEGIN
	SELECT Count(*)
	FROM Producers 
	WHERE [name] = @producerName
	and [country] = @country
	and active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsInactiveProduct]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsInactiveProduct]
	@productName varchar(100),
	@productBarcode varchar(10),
	@categoryId int,
	@producerId int

AS
BEGIN
	SELECT Count(*)
	FROM Products 
	WHERE [name] = @productName 
	and [barcode] = @productBarcode
	and [category_id] = @categoryId
	and [producer_id] = @producerId
	and active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsInactiveStock]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsInactiveStock]
	@quantity int,
	@unit varchar(10),
	@supplyDate date,
	@expirationDate date,
	@purchasePrice real,
	@vat real,
	@productId int
AS
BEGIN
	SELECT COUNT(*)
	FROM Stocks
	WHERE quantity = @quantity
	and unit = @unit
	and supply_date = @supplyDate
	and expiration_date = @expirationDate
	and purchase_price = @purchasePrice
	and vat = @vat
	and product_id = @productId
	and active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsInactiveUser]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsInactiveUser]
	@username varchar(30),
	@password varchar(15),
	@userType varchar(13)
AS
BEGIN
	SELECT Count(*)
	FROM Users 
	WHERE username = @username 
	and [password] = @password
	and user_type = @userType
	and active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsProducer]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsProducer]
	@producerName varchar(50),
	@country varchar(100)

AS
BEGIN
	SELECT Count(*)
	FROM Producers 
	WHERE [name] = @producerName
	and [country] = @country
	and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsProduct]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsProduct]
	@productName varchar(100),
	@productBarcode varchar(10),
	@categoryId int,
	@producerId int

AS
BEGIN
	SELECT Count(*)
	FROM Products 
	WHERE [name] = @productName 
	and [barcode] = @productBarcode
	and [category_id] = @categoryId
	and [producer_id] = @producerId
	and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsStock]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsStock]
	@quantity int,
	@unit varchar(10),
	@supplyDate date,
	@expirationDate date,
	@purchasePrice real,
	@vat real,
	@productId int
AS
BEGIN
	SELECT COUNT(*)
	FROM Stocks
	WHERE quantity = @quantity
	and unit = @unit
	and supply_date = @supplyDate
	and expiration_date = @expirationDate
	and purchase_price = @purchasePrice
	and vat = @vat
	and product_id = @productId
	and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[ExistsUser]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistsUser]
	@username varchar(30),
	@password varchar(15),
	@user_type varchar(13),
	@userId int OUTPUT
AS
BEGIN
	SELECT TOP 1 @userId = Users.id
	FROM Users 
	WHERE username = @username 
	and [password] = @password
	and user_type = @user_type
	and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllActiveCategories]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllActiveCategories]

AS
BEGIN
	select * 
	from Categories 
	where active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllActiveProducers]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllActiveProducers]

AS
BEGIN
	select * 
	from Producers 
	where active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllActiveProducts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllActiveProducts]

AS
BEGIN
	select *
	from Products 
	where active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllActiveReceipts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllActiveReceipts]

AS
BEGIN
	select *
	from Receipts 
	where active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllActiveStocks]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllActiveStocks]

AS
BEGIN
	select *
	from Stocks 
	where active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllActiveUsers]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllActiveUsers]

AS
BEGIN
	select *
	from Users 
	where active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategoriesName]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCategoriesName]

AS
BEGIN
	select Categories.[name] 
	from Categories 
	where active = 1
	order by Categories.[name];
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllInactiveCategories]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllInactiveCategories]

AS
BEGIN
	select * 
	from Categories 
	where active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllInactiveProducers]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllInactiveProducers]

AS
BEGIN
	select * 
	from Producers 
	where active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllInactiveProducts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllInactiveProducts]

AS
BEGIN
	select *
	from Products 
	where active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllInactiveReceipts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllInactiveReceipts]

AS
BEGIN
	select *
	from Receipts 
	where active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllInactiveStocks]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllInactiveStocks]

AS
BEGIN
	select *
	from Stocks 
	where active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllInactiveUsers]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllInactiveUsers]

AS
BEGIN
	select *
	from Users 
	where active = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducersName]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProducersName]

AS
BEGIN
	select Producers.[name] 
	from Producers 
	where active = 1
	order by Producers.[name] asc;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProducts]

AS
BEGIN
	select * 
	from Products 
	where active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductsBarcode]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProductsBarcode]

AS
BEGIN
	select Products.[barcode]
	from Products 
	where active = 1
	order by Products.[barcode] asc;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductsName]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProductsName]

AS
BEGIN
	select Products.[name]
	from Products 
	where active = 1
	order by Products.[name] asc;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStocksThatMatchParameters]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStocksThatMatchParameters]
	@productName varchar(100) = NULL,
	@productBarcode int = NULL,
	@stockExpirationDate date = NULL,
	@categoryName varchar(100) = NULL,
	@producerName varchar(50) = NULL
AS
BEGIN

SELECT Stocks.* 
FROM Stocks 
    INNER JOIN Products ON Stocks.product_id = Products.id
    INNER JOIN Categories ON Products.category_id = Categories.id
    INNER JOIN Producers ON Products.producer_id = Producers.id
WHERE 
(lower(Products.[name]) = lower(@productName) or @productName is null)
and 
(Products.barcode = @productBarcode or @productBarcode is null)
and
(lower(Categories.[name]) = lower(@categoryName) or @categoryName is null)
and
(lower(Producers.[name]) = lower(@producerName) or @producerName is null)
and
(Stocks.expiration_date = @stockExpirationDate or @stockExpirationDate is null) 
and
Products.active = 1 and Producers.active = 1 and Categories.active = 1 and Stocks.active = 1
ORDER BY Stocks.supply_date ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[GetBiggestReceipts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBiggestReceipts]
	@issuanceDate date
AS
BEGIN
	select TOP 1 id
	from Receipts 
	where issuance_date = issuance_date
	and active = 1
	ORDER BY total DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCashedAmounts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCashedAmounts]
	@cashierId int,
	@reportMonth varchar(10),
	@reportYear varchar(10)

AS
BEGIN
	SELECT DAY(issuance_date), SUM(total)
	FROM Receipts
	WHERE [cashier_id] = @cashierId
	and MONTH(issuance_date) = @reportMonth
	and YEAR(issuance_date) = @reportYear
	and active = 1
	GROUP BY DAY(issuance_date)
	ORDER BY DAY(issuance_date) ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategory]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategory]
	@categoryId int
AS
BEGIN
	select * 
	from Categories 
	where id = @categoryId and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryValue]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryValue]
	@categoryId int
AS
BEGIN
	SELECT SUM(Stocks.sale_price)
	FROM Stocks
	INNER JOIN Products ON Stocks.product_id = Products.id
    INNER JOIN Categories ON Categories.id = Products.category_id
	WHERE Stocks.active = 1
	and Products.category_id = @categoryId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProducer]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducer]
	@producerId int
AS
BEGIN
	select * 
	from Producers 
	where id = @producerId and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProduct]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProduct]
	@productId int
AS
BEGIN
	select * 
	from Products 
	where id = @productId and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsIdFromCategory]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsIdFromCategory]
	@categoryId int
AS
BEGIN
	Select id
	from Products
	where category_id = @categoryId
	and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsIdFromProducer]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsIdFromProducer]
	@producerId int
AS
BEGIN
	Select id
	from Products
	where producer_id = @producerId
	and active = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[GetReceiptProducts]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetReceiptProducts]
	@receiptId int
AS
BEGIN
	SELECT *
	FROM Stocks_Receipts
	WHERE receipt_id = @receiptId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetStock]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStock]
	@stockId int
AS
BEGIN
	SELECT *
	FROM Stocks
	WHERE id = @stockId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUser]
	@userId int
AS
BEGIN
	select * 
	from Users 
	where id = @userId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCategory]
	@categoryId int,
	@name varchar(100)
AS
BEGIN
	Update Categories
	set  
		[name] = @name
	where id = @categoryId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProducer]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProducer]
	@producerId int,
	@name varchar(50),
	@country varchar(100)
AS
BEGIN
	Update Producers
	set  
		[name] = @name,
		[country] = @country
	where id = @producerId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProduct]
	@productId int,
	@productName varchar(100),
	@productBarcode varchar(10),
	@categoryId int,
	@producerId int
AS
BEGIN
	Update Products
	set [name] = @productName,
		[barcode] = @productBarcode,
		[category_id] = @categoryId,
		[producer_id] = @producerId
	where id = @productId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateReceiptTotal]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateReceiptTotal]
	@receiptId int,
	@total real
AS
BEGIN
	Update Receipts 
	set total = @total
	where id = @receiptId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStockQuantity]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStockQuantity]
	@stockId int,
	@quantity int
AS
BEGIN
	Update Stocks 
	set quantity = @quantity
	where id = @stockId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStockSalePrice]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStockSalePrice]
	@stockId int,
	@salePrice real
AS
BEGIN
	Update Stocks 
	set sale_price = @salePrice, vat = (@salePrice / purchase_price + 1)
	where id = @stockId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@userId int,
	@username varchar(30),
	@password varchar(15),
	@userType varchar(13)
AS
BEGIN
	Update Users
	set [username] = @username,
		[password] = @password,
		[user_type] = @userType
	where id = @userId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateVAT]    Script Date: 5/25/2024 4:07:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateVAT]
	@stockId int,
	@vat real
AS
BEGIN
	Update Stocks
	set vat = ROUND(@vat, 2)
	WHERE id = @stockId;

	Update Stocks
	set sale_price = ROUND(purchase_price + purchase_price * vat, 2)
	WHERE id = @stockId;
END
GO
USE [master]
GO
ALTER DATABASE [Supermarket] SET  READ_WRITE 
GO
