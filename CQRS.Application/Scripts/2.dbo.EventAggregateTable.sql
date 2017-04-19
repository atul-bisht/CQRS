CREATE TABLE [dbo].[Aggregate]
(
    [AggregateId] NVARCHAR(50) NOT NULL, 
    [AggregateType] NCHAR(10) NOT NULL, 
    [Version] NCHAR(10) NOT NULL, 
    CONSTRAINT [PK_Aggregate] PRIMARY KEY ([AggregateId]) 
)
