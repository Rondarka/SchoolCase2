USE [Case2DB]
GO
/****** Object:  Table [dbo].[ChatHistory]    Script Date: 02.03.2022 2:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [int] NOT NULL,
	[RecipientId] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Chat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 02.03.2022 2:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[Symbol] [nvarchar](1) NOT NULL,
	[Year of admission] [int] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 02.03.2022 2:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 02.03.2022 2:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 02.03.2022 2:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[Mark] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Marks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 02.03.2022 2:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LessonId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[DayOfTheWeek] [nvarchar](max) NOT NULL,
	[Start] [time](7) NOT NULL,
	[End] [time](7) NOT NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02.03.2022 2:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](30) NOT NULL,
	[Adress] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Birthday] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChatHistory] ON 

INSERT [dbo].[ChatHistory] ([Id], [SenderId], [RecipientId], [Text], [Date]) VALUES (26, 1, 4, N'Здравствуйте', CAST(N'2022-03-02T01:55:49.157' AS DateTime))
INSERT [dbo].[ChatHistory] ([Id], [SenderId], [RecipientId], [Text], [Date]) VALUES (27, 1, 7, N'Добрый день', CAST(N'2022-03-02T01:55:56.767' AS DateTime))
INSERT [dbo].[ChatHistory] ([Id], [SenderId], [RecipientId], [Text], [Date]) VALUES (28, 1, 6, N'Здравствуйте, можно исправить оценку?', CAST(N'2022-03-02T01:56:18.120' AS DateTime))
SET IDENTITY_INSERT [dbo].[ChatHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([Id], [Year], [Symbol], [Year of admission]) VALUES (1, 6, N'А', 2015)
INSERT [dbo].[Class] ([Id], [Year], [Symbol], [Year of admission]) VALUES (2, 6, N'B', 2015)
INSERT [dbo].[Class] ([Id], [Year], [Symbol], [Year of admission]) VALUES (3, 6, N'C', 2015)
INSERT [dbo].[Class] ([Id], [Year], [Symbol], [Year of admission]) VALUES (4, 6, N'D', 2016)
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [ClassId], [StudentId]) VALUES (1, 1, 1)
INSERT [dbo].[Group] ([Id], [ClassId], [StudentId]) VALUES (2, 1, 7)
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessons] ON 

INSERT [dbo].[Lessons] ([Id], [Name], [TeacherId]) VALUES (1, N'Русский', 4)
INSERT [dbo].[Lessons] ([Id], [Name], [TeacherId]) VALUES (2, N'Литература', 4)
INSERT [dbo].[Lessons] ([Id], [Name], [TeacherId]) VALUES (3, N'Алгебра', 6)
INSERT [dbo].[Lessons] ([Id], [Name], [TeacherId]) VALUES (4, N'Геометрия', 6)
INSERT [dbo].[Lessons] ([Id], [Name], [TeacherId]) VALUES (5, N'Физика', 6)
INSERT [dbo].[Lessons] ([Id], [Name], [TeacherId]) VALUES (7, N'ОБЖ', 4)
SET IDENTITY_INSERT [dbo].[Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Marks] ON 

INSERT [dbo].[Marks] ([Id], [StudentId], [LessonId], [Mark], [Comment], [Date]) VALUES (3, 1, 7, N'3', N'Удовлетворительно', CAST(N'2022-02-26' AS Date))
INSERT [dbo].[Marks] ([Id], [StudentId], [LessonId], [Mark], [Comment], [Date]) VALUES (4, 7, 7, N'Б', N'Болел', CAST(N'2022-02-26' AS Date))
INSERT [dbo].[Marks] ([Id], [StudentId], [LessonId], [Mark], [Comment], [Date]) VALUES (5, 1, 7, N'4', N'Ответ на уроке', CAST(N'2022-02-26' AS Date))
SET IDENTITY_INSERT [dbo].[Marks] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeTable] ON 

INSERT [dbo].[TimeTable] ([Id], [LessonId], [Count], [ClassId], [DayOfTheWeek], [Start], [End]) VALUES (1, 1, 1, 1, N'Saturday', CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [LessonId], [Count], [ClassId], [DayOfTheWeek], [Start], [End]) VALUES (2, 2, 2, 1, N'Saturday', CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [LessonId], [Count], [ClassId], [DayOfTheWeek], [Start], [End]) VALUES (3, 3, 3, 1, N'Saturday', CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [LessonId], [Count], [ClassId], [DayOfTheWeek], [Start], [End]) VALUES (4, 4, 4, 1, N'Saturday', CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [LessonId], [Count], [ClassId], [DayOfTheWeek], [Start], [End]) VALUES (5, 5, 5, 1, N'Saturday', CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time))
INSERT [dbo].[TimeTable] ([Id], [LessonId], [Count], [ClassId], [DayOfTheWeek], [Start], [End]) VALUES (6, 7, 6, 1, N'Saturday', CAST(N'01:00:00' AS Time), CAST(N'02:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[TimeTable] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Login], [Password], [Name], [Position], [Adress], [Phone], [Birthday]) VALUES (1, N'student1', N'studentpas1', N'Инжуров Сергей Владимирович', N'Ученик', N'г. Копировка д. 15', N'+79772342311', CAST(N'2002-10-30' AS Date))
INSERT [dbo].[Users] ([Id], [Login], [Password], [Name], [Position], [Adress], [Phone], [Birthday]) VALUES (4, N'teacher1', N'teacherpas1', N'Лебедев Леодин Петрович', N'Учитель', N'г. Перекопировка д. 8', N'+79852713212', CAST(N'1978-09-06' AS Date))
INSERT [dbo].[Users] ([Id], [Login], [Password], [Name], [Position], [Adress], [Phone], [Birthday]) VALUES (6, N'teacher2', N'teacherpas2', N'Анексия Лидия Петровна', N'Учитель', N'г. Воскресенск д. 15', N'+79234271232', CAST(N'1973-03-02' AS Date))
INSERT [dbo].[Users] ([Id], [Login], [Password], [Name], [Position], [Adress], [Phone], [Birthday]) VALUES (7, N'student2', N'studentpas2', N'Клумбов Генадий Петрович', N'Ученик', N'г. Коломна д. 99', N'+79231532823', CAST(N'2003-03-02' AS Date))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[ChatHistory]  WITH CHECK ADD  CONSTRAINT [FK_Chat_User] FOREIGN KEY([SenderId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ChatHistory] CHECK CONSTRAINT [FK_Chat_User]
GO
ALTER TABLE [dbo].[ChatHistory]  WITH CHECK ADD  CONSTRAINT [FK_Chat_User1] FOREIGN KEY([RecipientId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ChatHistory] CHECK CONSTRAINT [FK_Chat_User1]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Class]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_User] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_User]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_User] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_User]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Lessons] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([Id])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Lessons]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_User] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_User]
GO
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTable_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTable_Class]
GO
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTable_Lessons] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([Id])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTable_Lessons]
GO
