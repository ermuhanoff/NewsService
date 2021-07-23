CREATE TABLE [dbo].[Tags] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Label]       NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

