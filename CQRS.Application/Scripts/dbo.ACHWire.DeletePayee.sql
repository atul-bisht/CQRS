CREATE PROCEDURE [dbo].[DeletePayee]
	@PayeeId nvarchar(50),
	@isSuccesful int output
AS
	
	if exists(select * from dbo.Payee where Id=@PayeeId)
	begin
		update dbo.Payee set IsDeleted=1 where Id=@PayeeId;
		set @isSuccesful=1;
	end
	else
	begin
		set @isSuccesful=0;
	end
RETURN 0