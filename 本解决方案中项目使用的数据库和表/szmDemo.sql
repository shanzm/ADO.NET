
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
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (1, N'����', N'����        ')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (2, N'����', N'��������      ')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (3, N'����', N'�й�����')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (4, N'����', N'����')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (5, N'����', N'����')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (6, N'С��', N'����')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (7, N'С��', N'����')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (8, N'С��', N'�㽭')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (9, N'С��', N'����')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (10, N'С��', N'����')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (11, N'С��', N'�ӱ�')
INSERT [dbo].[szmDemo] ([ID], [Name], [Address]) VALUES (12, N'С��', N'ɽ��')
SET IDENTITY_INSERT [dbo].[szmDemo] OFF