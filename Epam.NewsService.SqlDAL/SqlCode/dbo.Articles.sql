CREATE TABLE [dbo].[Articles] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Text]           NVARCHAR (MAX) NOT NULL,
    [Title]          NVARCHAR (255) NOT NULL,
    [CreationTime]   DATETIME       NOT NULL,
    [ModeratorId]    INT            NOT NULL,
    [IntroImageLink] NVARCHAR (255) NOT NULL,
    [CategoryId]     INT            NOT NULL,
    [Likes]          INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ModeratorId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id])
);

