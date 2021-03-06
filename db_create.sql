USE [master]
GO

/****** Object:  Database [unblockme]    Script Date: 7/5/2021 5:26:13 PM ******/
CREATE DATABASE [unblockme]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'unblockme', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\unblockme.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'unblockme_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\unblockme_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [unblockme].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [unblockme] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [unblockme] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [unblockme] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [unblockme] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [unblockme] SET ARITHABORT OFF 
GO

ALTER DATABASE [unblockme] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [unblockme] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [unblockme] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [unblockme] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [unblockme] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [unblockme] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [unblockme] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [unblockme] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [unblockme] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [unblockme] SET  DISABLE_BROKER 
GO

ALTER DATABASE [unblockme] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [unblockme] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [unblockme] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [unblockme] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [unblockme] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [unblockme] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [unblockme] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [unblockme] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [unblockme] SET  MULTI_USER 
GO

ALTER DATABASE [unblockme] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [unblockme] SET DB_CHAINING OFF 
GO

ALTER DATABASE [unblockme] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [unblockme] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [unblockme] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [unblockme] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [unblockme] SET QUERY_STORE = OFF
GO

ALTER DATABASE [unblockme] SET  READ_WRITE 
GO


