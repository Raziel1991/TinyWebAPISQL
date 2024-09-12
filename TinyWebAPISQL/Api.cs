using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace TinyWebAPISQL;

public static class Api
{
    /*
    An endpoint is a specific URL or URI within a web service
    or API where resources can be accessed or actions can be performed 
    by making HTTP requests (e.g., GET, POST, PUT, DELETE). In other words, 
    an endpoint represents a single point of contact where a client 
    (such as a browser or mobile app) communicates with a server to retrieve, 
    send, update, or delete data.
     */
    public static void ConfigureApi(this WebApplication application)
    {
        //mapping section
        application.MapGet("/Cars", GetCars);
        application.MapGet("/Cars/{id}", GetCar);
        application.MapPost("/Cars", InsertCar);
        application.MapPut("/Cars", UpdateCar);
        application.MapDelete("/Cars", DeleteCar);
    }

    private static async Task<IResult> GetCars(ICarData data)
    {
        try
        {
            return Results.Ok(await data.GetCars());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetCar(int id, ICarData data)
    {
        try
        {
            var results = await data.GetCar(id);
            if (results == null)
                return Results.NotFound();

            return Results.Ok(results);

        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertCar(CarModel car, ICarData data)
    {
        try
        {
            await data.InsertCar(car);
            return Results.Ok();
        }
        catch (Exception ex) { 
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateCar(CarModel car, ICarData data)
    {
        try
        {
            await data.UpdateCar(car);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteCar(int id, ICarData data)
    {
        try
        {
            await data.DeleteCar(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
