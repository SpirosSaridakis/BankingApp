CREATE TABLE [dbo].[Account] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [desc]     NVARCHAR (MAX) NULL,
    [balance]  FLOAT (53)     NULL,
    [currency] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC)
);

