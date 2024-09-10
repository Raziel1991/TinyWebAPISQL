CREATE PROCEDURE [dbo].[spCar_Insert]
	@Make NVARCHAR (20),
	@Model NVARCHAR (20),
	@Year INT,
	@Price DECIMAL (10,2)
AS
begin
	insert into dbo.[Cars] (Make, Model, Year, Price)
	values (@Make, @Model, @Year, @Price);
	
end
