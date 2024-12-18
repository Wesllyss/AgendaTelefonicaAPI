BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Contatos] (
    [ContatoId] int NOT NULL IDENTITY,
    [nome] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NULL,
    [Endereco] nvarchar(max) NULL,
    CONSTRAINT [PK_Contatos] PRIMARY KEY ([ContatoId])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241118130940_Contato', N'9.0.0');

COMMIT;
GO


