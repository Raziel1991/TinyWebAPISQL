if not exists (select 1 from dbo.[Cars])
begin 
	insert into dbo.[Cars] (Make, Model, Year, Price)
	values 
	('Toyota', 'Camry', 2020, 24000.00),
    ('Honda', 'Civic', 2019, 22000.00),
    ('Ford', 'Mustang', 2021, 35000.00),
    ('Chevrolet', 'Malibu', 2018, 20000.00),
    ('Tesla', 'Model 3', 2022, 40000.00),
    ('BMW', '3 Series', 2021, 41000.00), 
    ('Audi', 'A4', 2020, 38000.00),
    ('Mercedes', 'C-Class', 2019, 42000.00),
    ('Hyundai', 'Elantra', 2021, 19000.00),
    ('Kia', 'Optima', 2020, 21000.00);
end
