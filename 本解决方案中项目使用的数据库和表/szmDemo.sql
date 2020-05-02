
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[szmDemo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_szmDemo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[szmDemo] ON
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (1, N'李四', N'北极        ')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (2, N'王五', N'西伯利亚      ')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (3, N'张三', N'中国江苏')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (4, N'王五', N'云南')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (5, N'赵六', N'广州')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (6, N'小明', N'广西')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (7, N'小亮', N'海南')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (8, N'小红', N'浙江')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (9, N'小军', N'安徽')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (10, N'小王', N'河南')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (11, N'小张', N'河北')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (12, N'小李', N'山东')
SET IDENTITY_INSERT [dbo].[szmDemo] OFF