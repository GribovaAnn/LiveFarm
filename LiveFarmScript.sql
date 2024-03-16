USE [LiveFarm]
GO
/****** Object:  Table [dbo].[Assortment]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assortment](
	[IdProduct] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[MakerId] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [int] NULL,
	[PhotoPath] [nvarchar](200) NULL,
 CONSTRAINT [PK_Assortment] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[IdBasketProd] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED 
(
	[IdBasketProd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Makers]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Makers](
	[IdMaker] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Makers] PRIMARY KEY CLUSTERED 
(
	[IdMaker] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MakingStatuses]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MakingStatuses](
	[IdStatus] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MakingStatuses] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[IdOrder] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PointId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[DateOrder] [nvarchar](50) NOT NULL,
	[InStock] [bit] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PickupPoints]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PickupPoints](
	[IdPoint] [int] IDENTITY(1,1) NOT NULL,
	[Adress] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_PickupPoints] PRIMARY KEY CLUSTERED 
(
	[IdPoint] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsInOrder]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsInOrder](
	[IdProdOrder] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_ProductsInOrder] PRIMARY KEY CLUSTERED 
(
	[IdProdOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[IdUnit] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[IdUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16.03.2024 17:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Fname] [nvarchar](50) NOT NULL,
	[Sname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assortment] ON 

INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (1, N'Отривин, 0.1%, спрей назальный дозированный, с ментолом и эвкалиптом', N'Бесцветный опалесцирующий раствор с характерным запахом ментола и эвкалипта.', 2, 186, 2, 44, 5, N'../Assets/Images/otrivin.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (2, N'Но-шпа, 40 мг, таблетки', N'Таблетки желтого с зеленоватым или оранжеватым оттенком цвета, круглые, двояковыпуклые, с гравировкой "spa" на одной стороне.', 2, 212, 2, 15, NULL, N'../Assets/Images/noshpa.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (3, N'Бромгексин 8 Берлин-Хеми, 8 мг, таблетки, покрытые оболочкой', N'Таблетки, покрытые оболочкой от желтого до зеленовато-желтого цвета слегка двояковыпуклые с почти белым ядром.', 3, 169, 2, 0, NULL, N'../Assets/Images/bromgeksin.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (4, N'Артра, 500 мг+500 мг, таблетки, покрытые пленочной оболочкой', N'Двояковыпуклые таблетки овальной формы, покрытые пленочной оболочкой от белого до белого с желтоватым оттенком цвета, с гравировкой «ARTRA» с одной стороны таблетки, с характерным запахом.', 1, 2399, 2, 4, 1, N'../Assets/Images/artra.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (5, N'Фестал, таблетки кишечнорастворимые, покрытые оболочкой', N'Глянцевые, круглые таблетки, покрытые оболочкой белого цвета, со слабым запахом ванили.', 3, 459, 2, 97, 10, N'../Assets/Images/festal.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (6, N'Бифиформ, капсулы кишечнорастворимые', N'Твердые желатиновые капсулы номер 3 белого или почти белого цвета. Содержимое капсулы - порошок от белого до светло-желтого цвета.', 3, 647, 2, 12, NULL, N'../Assets/Images/bifiform.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (7, N'Эссенциале форте Н, 300 мг, капсулы', N'Твердые желатиновые непрозрачные капсулы №1 коричневого цвета, содержащие маслянистую пастообразную массу желтовато-коричневого цвета.', 1, 1355, 2, 48, 4, N'../Assets/Images/essenciale.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (8, N'ТераФлю от гриппа и простуды, порошок для приготовления раствора', N'Сыпучий белый гранулированный порошок с желтыми вкраплениями без посторонних частиц с цитрусовым запахом. Допускается наличие мягких комков.', 4, 645, 2, 24, NULL, N'../Assets/Images/teraflu.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (9, N'Вольтарен Эмульгель, 2%, гель для наружного применения, 100 г', N'Гель для наружного применения 2 %. По 100 г в ламинированной тубе (полиэтилен низкой плотности, алюминий, полиэтилен высокой плотности) с плечом и цельнолитой фигурной защитной мембраной из полиэтилена высокой плотности и полипропиленовой навинчивающейся крышкой, круглой или треугольной формы.', 4, 840, 2, 0, NULL, N'../Assets/Images/voltaren.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (10, N'Бепантен, 5%, мазь для наружного применения, 100 г', N'Мягкая эластичная гомогенная непрозрачная мазь бледно-желтого цвета со слабым запахом ланолина.', 5, 927, 2, 0, NULL, N'../Assets/Images/bepanten.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (11, N'Peha-haft Бинт самофиксирующийся, 4смх4м, белого цвета', N'Peha-haft  –  самофиксирующийся бинт для удобной и надежной фиксации любых видов повязок. ', 6, 169, 2, 98, NULL, N'../Assets/Images/pehahaft.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (12, N'Бранолинд Н с перуанским бальзамом Повязка мазевая, 7.5х10, повязка', N'Сетка: хлопчатобумажная однослойная сетчатая крупноячеистая ткань. Хлопок натуральный 100% Защитный слой: пергаментная бумага с двух сторон повязки внутри индивидуальной упаковки Мазевая основа: вазелин, перуанский бальзам', 7, 148, 2, 75, 1, N'../Assets/Images/branolind.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (13, N'Магне B6 форте, таблетки, покрытые пленочной оболочкой', N'В 1 таблетке содержится: Ядро таблетки: действующие вещества: магния цитрат - 618,43 мг, что соответствует 100 мг магния (Mg++), пиридоксина гидрохлорид -10 мг; вспомогательные вещества: лактоза 50,57 мг, макрогол-6000 - 120,00 мг, магния стеарат - 1,00 мг. Оболочка таблетки: гипромеллоза 6 мПа.с - 14,08 мг, макрогол-6000 - 1,17 мг, титана диоксид (Е 171) - 4,75 мг, тальк - следы.', 6, 610, 2, 46, 5, N'../Assets/Images/magne.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (14, N'Мирамистин, 0.01%, раствор для местного применения, с насадкой-распылителем, 150 мл', N'Бесцветная прозрачная жидкость, пенящаяся при встряхивании.', 6, 428, 2, 53, NULL, N'../Assets/Images/miramistin.png')
INSERT [dbo].[Assortment] ([IdProduct], [Title], [Description], [MakerId], [Price], [UnitId], [Quantity], [Discount], [PhotoPath]) VALUES (15, N'Racionika Diet батончик', N'со вкусом ананаса, 60 г, 1 шт', 7, 99, 2, 19, 20, N'../Assets/Images/racionika.png')
SET IDENTITY_INSERT [dbo].[Assortment] OFF
GO
SET IDENTITY_INSERT [dbo].[Makers] ON 

INSERT [dbo].[Makers] ([IdMaker], [Name]) VALUES (1, N'Актива')
INSERT [dbo].[Makers] ([IdMaker], [Name]) VALUES (2, N'Новосибхимфарм')
INSERT [dbo].[Makers] ([IdMaker], [Name]) VALUES (3, N'Биотех')
INSERT [dbo].[Makers] ([IdMaker], [Name]) VALUES (4, N'Биотики')
INSERT [dbo].[Makers] ([IdMaker], [Name]) VALUES (5, N'Фармпроект')
INSERT [dbo].[Makers] ([IdMaker], [Name]) VALUES (6, N'СИЛМА')
INSERT [dbo].[Makers] ([IdMaker], [Name]) VALUES (7, N'Эдас')
SET IDENTITY_INSERT [dbo].[Makers] OFF
GO
SET IDENTITY_INSERT [dbo].[MakingStatuses] ON 

INSERT [dbo].[MakingStatuses] ([IdStatus], [Name]) VALUES (1, N'Оформлен (в пути)')
INSERT [dbo].[MakingStatuses] ([IdStatus], [Name]) VALUES (2, N'Готов к выдаче')
SET IDENTITY_INSERT [dbo].[MakingStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[PickupPoints] ON 

INSERT [dbo].[PickupPoints] ([IdPoint], [Adress], [UserId]) VALUES (1, N'ул. Авиаторов 12', 2)
INSERT [dbo].[PickupPoints] ([IdPoint], [Adress], [UserId]) VALUES (5, N'ул. Монтажников 11', 3)
INSERT [dbo].[PickupPoints] ([IdPoint], [Adress], [UserId]) VALUES (6, N'ул. Искровцев 40', 4)
INSERT [dbo].[PickupPoints] ([IdPoint], [Adress], [UserId]) VALUES (7, N'пр. Ленина 29', 5)
SET IDENTITY_INSERT [dbo].[PickupPoints] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IdRole], [Name]) VALUES (1, N'Пользователь')
INSERT [dbo].[Roles] ([IdRole], [Name]) VALUES (2, N'Сотрудник')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Units] ON 

INSERT [dbo].[Units] ([IdUnit], [Name]) VALUES (1, N'упак.')
INSERT [dbo].[Units] ([IdUnit], [Name]) VALUES (2, N'шт.')
INSERT [dbo].[Units] ([IdUnit], [Name]) VALUES (3, N'мл.')
SET IDENTITY_INSERT [dbo].[Units] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([IdUser], [Login], [Password], [RoleId], [Fname], [Sname]) VALUES (1, N'qwerty123', N'pass', 1, N'Александр', N'Иванов')
INSERT [dbo].[Users] ([IdUser], [Login], [Password], [RoleId], [Fname], [Sname]) VALUES (2, N'zxczxc', N'123', 2, N'Владислав', N'Куимов')
INSERT [dbo].[Users] ([IdUser], [Login], [Password], [RoleId], [Fname], [Sname]) VALUES (3, N'albert1414', N'albert2009', 2, N'Альберт', N'Мятный')
INSERT [dbo].[Users] ([IdUser], [Login], [Password], [RoleId], [Fname], [Sname]) VALUES (4, N'RufinaArkadeva603', N'yrNcqmar6Tmq', 2, N'Руфина', N'Аркадьева')
INSERT [dbo].[Users] ([IdUser], [Login], [Password], [RoleId], [Fname], [Sname]) VALUES (5, N'AntipPresnyakov766', N'ZtoriqkRfWL4', 2, N'Антип', N'Пресняков')
INSERT [dbo].[Users] ([IdUser], [Login], [Password], [RoleId], [Fname], [Sname]) VALUES (6, N'asdfasdf', N'148', 1, N'Петр', N'Владимирович')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Assortment]  WITH CHECK ADD  CONSTRAINT [FK_Assortment_Makers] FOREIGN KEY([MakerId])
REFERENCES [dbo].[Makers] ([IdMaker])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Assortment] CHECK CONSTRAINT [FK_Assortment_Makers]
GO
ALTER TABLE [dbo].[Assortment]  WITH CHECK ADD  CONSTRAINT [FK_Assortment_Units] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Units] ([IdUnit])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Assortment] CHECK CONSTRAINT [FK_Assortment_Units]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Assortment] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Assortment] ([IdProduct])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Assortment]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Users]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_MakingStatuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[MakingStatuses] ([IdStatus])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_MakingStatuses]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PickupPoints] FOREIGN KEY([PointId])
REFERENCES [dbo].[PickupPoints] ([IdPoint])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PickupPoints]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[PickupPoints]  WITH CHECK ADD  CONSTRAINT [FK_PickupPoints_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PickupPoints] CHECK CONSTRAINT [FK_PickupPoints_Users]
GO
ALTER TABLE [dbo].[ProductsInOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductsInOrder_Assortment] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Assortment] ([IdProduct])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductsInOrder] CHECK CONSTRAINT [FK_ProductsInOrder_Assortment]
GO
ALTER TABLE [dbo].[ProductsInOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductsInOrder_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([IdOrder])
GO
ALTER TABLE [dbo].[ProductsInOrder] CHECK CONSTRAINT [FK_ProductsInOrder_Orders]
GO
ALTER TABLE [dbo].[ProductsInOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductsInOrder_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([IdUser])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductsInOrder] CHECK CONSTRAINT [FK_ProductsInOrder_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([IdRole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
