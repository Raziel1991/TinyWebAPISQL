CREATE PROCEDURE [dbo].[spCar_getAll]

AS
begin
	select  Make,Model,Year,Price
	from dbo.[Cars];
end
