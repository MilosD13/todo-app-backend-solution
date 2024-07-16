CREATE TABLE [dbo].[Todos] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Task]       NVARCHAR (50) NOT NULL,
    [AssignedTo] INT           NOT NULL,
    [IsComplete] BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
