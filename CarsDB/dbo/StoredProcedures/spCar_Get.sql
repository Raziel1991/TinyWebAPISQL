CREATE PROCEDURE [dbo].[sp_CarGet]

	@Id int
AS
begin
	select  Make,Model,Year,Price
	from dbo.[Cars]
	where Id = @Id
end
