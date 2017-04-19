if not exists(select [name] from sys.databases where name='EventStore') 
create database eventStore

CREATE TABLE [dbo].[EventLog]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AggregateId] NVARCHAR(50) NOT NULL, 
    [TimeStamp] DATETIME NOT NULL, 
    [PayLoad] NCHAR(10) NOT NULL ,
	[EventName] NCHAR(10) NOT NULL, 
    constraint  FK_AggregateId foreign key (aggregateId) references dbo.Aggregate(aggregateId)
)


