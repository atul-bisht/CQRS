create PROCEDURE [dbo].[AddPayee]
	@name nvarchar(50),
	@AccounNumber nvarchar(50),
	@Bsb nvarchar(20),
	@Description nvarchar(10),
	@CustomerNumber nvarchar(10),
	@isSuccesful int output
AS
	declare @payeeId int=null
	select @payeeId = Id from dbo.Payee where Bsb=@Bsb and AccountNumber=@AccounNumber and IsDeleted=0;
	if(@payeeId is null)
	begin
		insert into dbo.Payee(Name,AccountNumber,Bsb,Description,CustomerNumber, IsDeleted) values(@name,@AccounNumber,@Bsb,@Description,@CustomerNumber,0)
		set @isSuccesful=1;
	end
	else
	begin
		set @isSuccesful=0;
	end
RETURN 0