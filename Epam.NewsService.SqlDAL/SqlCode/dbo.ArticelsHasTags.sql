CREATE TABLE [dbo].[ArticelsHasTags] (
    [ArticleId] INT NOT NULL,
    [TagId]     INT NOT NULL,
    FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([Id]),
    FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tags] ([Id])
);

