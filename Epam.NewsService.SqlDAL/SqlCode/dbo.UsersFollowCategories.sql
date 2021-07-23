CREATE TABLE [dbo].[UsersFollowCategories] (
    [UserId]     INT NOT NULL,
    [CategoryId] INT NOT NULL,
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id])
);

