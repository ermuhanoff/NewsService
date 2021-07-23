CREATE TABLE [dbo].[Comments] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CreationTime] DATETIME       NOT NULL,
    [EditedTime]   DATETIME       NULL,
    [Content]      NVARCHAR (MAX) NOT NULL,
    [UserId]       INT            NOT NULL,
    [ArticleId]    INT            NOT NULL,
    [Likes] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([Id])
);

