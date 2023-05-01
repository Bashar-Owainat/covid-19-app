IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501122736_AdddDB')
BEGIN
    CREATE TABLE [Records] (
        [ID] nvarchar(450) NOT NULL,
        [Country] nvarchar(max) NULL,
        [TotalConfirmed] int NOT NULL,
        [TotalDeaths] int NOT NULL,
        [TotalRecovered] int NOT NULL,
        [Date] nvarchar(max) NULL,
        CONSTRAINT [PK_Records] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230501122736_AdddDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230501122736_AdddDB', N'5.0.14');
END;
GO

COMMIT;
GO

