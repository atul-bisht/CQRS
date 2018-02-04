CREATE PROCEDURE [dbo].[AddEvent]
	@Id UNIQUEIDENTIFIER,
	@AggregateId UNIQUEIDENTIFIER,
	@TimeStamp datetime,
	@PayLoad nvarchar(max),
	@EventName nvarchar(max),
	@isSuccesful bit
AS
begin	
		insert into dbo.eventlog values(@Id,@AggregateId,@TimeStamp,@PayLoad,@EventName)
		set @isSuccesful=1;
end
RETURN 0