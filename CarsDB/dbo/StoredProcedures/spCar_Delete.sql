CREATE PROCEDURE [dbo].[spCar_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Cars]
	where Id = @Id
end
