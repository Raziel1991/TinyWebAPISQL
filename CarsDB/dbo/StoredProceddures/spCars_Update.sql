CREATE PROCEDURE [dbo].[spCars_Update]
	@Id INT,
	@Make NVARCHAR (20),
	@Model NVARCHAR (20),
	@Year INT,
	@Price DECIMAL (10,2)
AS
begin
	update dbo.[Cars]
	set Make = @Make, Model = @Model, Year = @Year, Price = @Price
	where Id = @Id
end 
