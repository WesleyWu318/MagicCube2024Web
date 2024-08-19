USE [MagicCube]
GO
/****** Object:  Table [dbo].[RegistrationAccount]    Script Date: 2024/8/7 下午 03:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrationAccount](
	[SchoolCode] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[SchoolName] [nvarchar](50) NULL,
	[TeacherName] [nvarchar](50) NULL,
	[TeacherPhone] [nvarchar](50) NULL,
	[TeacherEmail] [nvarchar](50) NULL,
 CONSTRAINT [PK_RegistrationAccount] PRIMARY KEY CLUSTERED 
(
	[SchoolCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student2024]    Script Date: 2024/8/7 下午 03:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student2024](
	[SchoolCode] [nvarchar](50) NOT NULL,
	[ID] [nvarchar](50) NOT NULL,
	[StudentName] [nvarchar](50) NULL,
	[TeacherName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Student2024] PRIMARY KEY CLUSTERED 
(
	[SchoolCode] ASC,
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[RegistrationAccount] ([SchoolCode], [Password], [SchoolName], [TeacherName], [TeacherPhone], [TeacherEmail]) VALUES (N'313501', N'0000', N'市立介壽國中', N'阿雄雄', N'0912345678', N'bear@gmail.com')
INSERT [dbo].[RegistrationAccount] ([SchoolCode], [Password], [SchoolName], [TeacherName], [TeacherPhone], [TeacherEmail]) VALUES (N'313502', N'0000', N'市立民生國中', N'阿雄', N'0912345678', N'bear@gmail.com')
INSERT [dbo].[RegistrationAccount] ([SchoolCode], [Password], [SchoolName], [TeacherName], [TeacherPhone], [TeacherEmail]) VALUES (N'313504', N'0000', N'市立中山國中', N'阿雄', N'0912345678', N'bear@gmail.com')
INSERT [dbo].[RegistrationAccount] ([SchoolCode], [Password], [SchoolName], [TeacherName], [TeacherPhone], [TeacherEmail]) VALUES (N'313505', N'0000', N'市立敦化國中', N'阿雄', N'0912345678', N'bear@gmail.com')
INSERT [dbo].[RegistrationAccount] ([SchoolCode], [Password], [SchoolName], [TeacherName], [TeacherPhone], [TeacherEmail]) VALUES (N'323502', N'0000', N'市立興雅國中', NULL, NULL, NULL)
GO
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313501', N'1', N'阿雄3', N'雄哥')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313501', N'2', N'雄哥', N'大雄')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313501', N'3', N'大熊', N'老雄')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313501', N'4', N'老雄', N'雄大')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313501', N'5', N'雄大', N'熊熊')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313501', N'6', N'熊熊遇見你', N'兇雄')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313502', N'1', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313504', N'1', N'阿雄1', N'雄哥')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313504', N'2', N'阿雄2', N'雄哥')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313504', N'3', N'阿雄3', N'雄哥')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313504', N'4', N'阿雄4', N'雄哥')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313504', N'5', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313504', N'6', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313505', N'1', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313505', N'2', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313505', N'3', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313505', N'4', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313505', N'5', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'313505', N'6', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'323502', N'1', N'阿雄1', N'雄哥')
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'323502', N'2', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'323502', N'3', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'323502', N'4', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'323502', N'5', NULL, NULL)
INSERT [dbo].[Student2024] ([SchoolCode], [ID], [StudentName], [TeacherName]) VALUES (N'323502', N'6', NULL, NULL)
GO
