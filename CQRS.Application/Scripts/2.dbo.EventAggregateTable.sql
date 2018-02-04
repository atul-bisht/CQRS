CREATE TABLE [dbo].[Aggregate]
(
    [AggregateId] UNIQUEIDENTIFIER NOT NULL, 
    [AggregateType] NCHAR(10) NOT NULL, 
    [Version] NCHAR(10) NOT NULL, 
    CONSTRAINT [PK_Aggregate] PRIMARY KEY ([AggregateId]) 
)
