--ÐÂ½¨szmUserinfo--

USE [db_Tome1]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[szmUserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](10) NULL,
	[UserPwd] [nchar](10) NULL,
	[LaterErrorDateTime] [datetime] NULL,
	[ErrorTimes] [int] NULL,
 CONSTRAINT [PK_dbo.szmUserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON 
[PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[szmUserInfo] ON
INSERT [dbo].[szmUserInfo] ([Id], [UserName], [UserPwd], [LaterErrorDateTime], [ErrorTimes]) VALUES (1, N'admin1    ', N'12345     ', 
CAST(0x0000A903010DA7A4 AS DateTime), 0)
INSERT [dbo].[szmUserInfo] ([Id], [UserName], [UserPwd], [LaterErrorDateTime], [ErrorTimes]) VALUES (2, N'admin2    ', N'12345     ', 
CAST(0x0000A903010DD558 AS DateTime), 1)
INSERT [dbo].[szmUserInfo] ([Id], [UserName], [UserPwd], [LaterErrorDateTime], [ErrorTimes]) VALUES (3, N'admin3    ', N'12345     ', 
CAST(0x0000A903010DE944 AS DateTime), 2)
INSERT [dbo].[szmUserInfo] ([Id], [UserName], [UserPwd], [LaterErrorDateTime], [ErrorTimes]) VALUES (4, N'admin4    ', N'12345     ', 
CAST(0x0000A903010DF754 AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[szmUserInfo] OFF