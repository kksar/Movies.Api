USE [master]
GO
/****** Object:  Database [dbmovies]    Script Date: 27/07/2022 13:58:56 ******/
CREATE DATABASE [dbmovies]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbmovies', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSRV\MSSQL\DATA\dbmovies.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbmovies_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSRV\MSSQL\DATA\dbmovies_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbmovies] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbmovies].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbmovies] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbmovies] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbmovies] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbmovies] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbmovies] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbmovies] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbmovies] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbmovies] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbmovies] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbmovies] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbmovies] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbmovies] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbmovies] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbmovies] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbmovies] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbmovies] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbmovies] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbmovies] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbmovies] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbmovies] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbmovies] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbmovies] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbmovies] SET RECOVERY FULL 
GO
ALTER DATABASE [dbmovies] SET  MULTI_USER 
GO
ALTER DATABASE [dbmovies] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbmovies] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbmovies] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbmovies] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbmovies] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbmovies] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbmovies', N'ON'
GO
ALTER DATABASE [dbmovies] SET QUERY_STORE = OFF
GO
USE [dbmovies]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/07/2022 13:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 27/07/2022 13:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 27/07/2022 13:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 27/07/2022 13:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ReleaseYear] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[OriginalLanguageId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieStaff]    Script Date: 27/07/2022 13:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieStaff](
	[MoviesId] [int] NOT NULL,
	[StaffsId] [int] NOT NULL,
 CONSTRAINT [PK_MovieStaff] PRIMARY KEY CLUSTERED 
(
	[MoviesId] ASC,
	[StaffsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 27/07/2022 13:58:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220727085428_MyFirstMigration', N'6.0.7')
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Drama')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Action')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Humor')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([Id], [Name]) VALUES (1, N'English')
INSERT [dbo].[Languages] ([Id], [Name]) VALUES (2, N'Francais')
INSERT [dbo].[Languages] ([Id], [Name]) VALUES (3, N'Español')
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([Id], [Title], [Description], [ReleaseYear], [LanguageId], [OriginalLanguageId], [GenreId]) VALUES (1, N'Heat', NULL, 2000, 1, 2, 2)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [ReleaseYear], [LanguageId], [OriginalLanguageId], [GenreId]) VALUES (2, N'Armagedon', NULL, 2010, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
INSERT [dbo].[MovieStaff] ([MoviesId], [StaffsId]) VALUES (1, 1)
INSERT [dbo].[MovieStaff] ([MoviesId], [StaffsId]) VALUES (2, 1)
INSERT [dbo].[MovieStaff] ([MoviesId], [StaffsId]) VALUES (1, 2)
INSERT [dbo].[MovieStaff] ([MoviesId], [StaffsId]) VALUES (2, 2)
INSERT [dbo].[MovieStaff] ([MoviesId], [StaffsId]) VALUES (1, 3)
INSERT [dbo].[MovieStaff] ([MoviesId], [StaffsId]) VALUES (2, 3)
GO
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([Id], [FirstName], [LastName], [Role]) VALUES (1, N'khalid', N'ksar', N'Actor')
INSERT [dbo].[Staffs] ([Id], [FirstName], [LastName], [Role]) VALUES (2, N'ahmed', N'aniss', N'Director')
INSERT [dbo].[Staffs] ([Id], [FirstName], [LastName], [Role]) VALUES (3, N'Ayoub', N'Jala', N'Senariste')
SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO
/****** Object:  Index [IX_Movies_GenreId]    Script Date: 27/07/2022 13:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_GenreId] ON [dbo].[Movies]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_LanguageId]    Script Date: 27/07/2022 13:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_LanguageId] ON [dbo].[Movies]
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MovieStaff_StaffsId]    Script Date: 27/07/2022 13:58:56 ******/
CREATE NONCLUSTERED INDEX [IX_MovieStaff_StaffsId] ON [dbo].[MovieStaff]
(
	[StaffsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres_GenreId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Languages_LanguageId]
GO
ALTER TABLE [dbo].[MovieStaff]  WITH CHECK ADD  CONSTRAINT [FK_MovieStaff_Movies_MoviesId] FOREIGN KEY([MoviesId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieStaff] CHECK CONSTRAINT [FK_MovieStaff_Movies_MoviesId]
GO
ALTER TABLE [dbo].[MovieStaff]  WITH CHECK ADD  CONSTRAINT [FK_MovieStaff_Staffs_StaffsId] FOREIGN KEY([StaffsId])
REFERENCES [dbo].[Staffs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieStaff] CHECK CONSTRAINT [FK_MovieStaff_Staffs_StaffsId]
GO
USE [master]
GO
ALTER DATABASE [dbmovies] SET  READ_WRITE 
GO
