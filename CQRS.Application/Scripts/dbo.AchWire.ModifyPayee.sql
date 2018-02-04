CREATE PROCEDURE [dbo].[ModifyPayee]
	@PayeeId nvarchar(50),
	@name nvarchar(50),
	@AccounNumber nvarchar(50),
	@Bsb nvarchar(20),
	@isSuccesful int output
AS
	
	if exists(select * from dbo.Payee where Id=@PayeeId and IsDeleted=0)
	begin
		update dbo.Payee set Bsb=@Bsb,  AccountNumber=@AccounNumber , Name=@name where Id=@PayeeId
		set @isSuccesful=1;
	end
	else
	begin
		set @isSuccesful=0;
	end
RETURN 0