using TinyWebAPISQL;
using DataAccess.DbAccess;
//using 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//----needed in the injection dependency system -- needs to be injected with Iconfiguration system 
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ICarData, CarData>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// quarter ball method 
app.UseHttpsRedirection();
app.ConfigureApi();
app.Run();
