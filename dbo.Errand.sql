CREATE TABLE [dbo].[Errand] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Description]         NVARCHAR (MAX) NOT NULL,
    [CreationTime]        DATETIME       NOT NULL,
    [CustomerFirstName]   NVARCHAR (50)  NOT NULL,
    [CustomerLastName]    NVARCHAR (50)  NOT NULL,
    [CustomerEmail]       NVARCHAR (50)  NOT NULL,
    [CustomerPhonenumber] INT            NULL,
    [Status]              NVARCHAR (20)  NOT NULL,
    [Category]            NVARCHAR (20)  NOT NULL,
    [Createdby]           NVARCHAR (50)  NOT NULL,
    [Comment]             NCHAR (100)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

