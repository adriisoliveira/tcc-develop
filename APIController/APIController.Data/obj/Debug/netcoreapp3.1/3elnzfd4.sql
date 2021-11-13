BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'CPF');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] ALTER COLUMN [CPF] nvarchar(11) NOT NULL;
GO

CREATE TABLE [ApiAccessLogs] (
    [Id] uniqueidentifier NOT NULL,
    [IP] nvarchar(255) NOT NULL,
    [UserAgent] nvarchar(255) NOT NULL,
    [RequestedAction] nvarchar(255) NOT NULL,
    [RequestDate] datetime2 NOT NULL,
    CONSTRAINT [PK_ApiAccessLogs] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ApiTokenLogs] (
    [Id] uniqueidentifier NOT NULL,
    [IP] nvarchar(255) NOT NULL,
    [UserAgent] nvarchar(255) NOT NULL,
    [Token] nvarchar(255) NOT NULL,
    [TokenGenerationDate] datetime2 NOT NULL,
    [TokenExpireDate] datetime2 NOT NULL,
    CONSTRAINT [PK_ApiTokenLogs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211103230520_Create-Api-Log-Tables', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[ApiTokenLogs].[TokenGenerationDate]', N'TokenGenerateDate', N'COLUMN';
GO

EXEC sp_rename N'[ApiAccessLogs].[RequestedAction]', N'RequestAction', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211104004852_Update-Log-Fields', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ApiTokenLogs]') AND [c].[name] = N'Token');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ApiTokenLogs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [ApiTokenLogs] ALTER COLUMN [Token] nvarchar(max) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211105015054_Update-ApiTokenLog-Token-MaxLength', N'5.0.10');
GO

COMMIT;
GO

