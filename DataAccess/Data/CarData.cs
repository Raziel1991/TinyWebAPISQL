using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class CarData : ICarData
{
    /*
    Dependency Injection: The interface ISqlDataAccess is passed into the CarData class through its constructor. This allows the class to work with different implementations of ISqlDataAccess, making it more flexible and testable.
    Asynchronous Programming: The methods in this class use asynchronous methods (Task<> and async/await) to ensure that database operations are performed without blocking the main thread.
    */

    /*
    _db is a private, readonly field of type ISqlDataAccess. This means that once it is set, it cannot be changed. The field stores a reference to an object that implements the ISqlDataAccess interface.
    This field will be used throughout the class to perform database operations.
    */
    private readonly ISqlDataAccess _db;

    /*
    The constructor takes an ISqlDataAccess object as a parameter and assigns it to the _db field.
    The constructor ensures that the CarData class is initialized with an implementation of ISqlDataAccess, which is essential for making database calls.
    */
    public CarData(ISqlDataAccess db)
    {
        _db = db;
    }

    // Get all data using dbo.spCar_getAll
    public Task<IEnumerable<CarModel>> GetCars() =>
        _db.LoadData<CarModel, dynamic>(storedProcedure: "dbo.spCar_getAll", new { });


    // Get data using dbo.spCar_Get 
    /* 
     * Method: GetCar(int id):
    Return Type: Task<CarModel?>

    This method returns a Task, and the result will be a CarModel object (or null if no car is found).
    The ? after CarModel means that the result can be null. In case no matching car is found in the database, the method will return null.
    Implementation:

    The method calls the same _db.LoadData<T1, T2>() method as before, but this time it passes the ID of the car as a parameter to the stored procedure.
    Stored Procedure: "dbo.spCar_Get"

    This stored procedure is responsible for retrieving a single car record based on the car ID.
    Parameter Object: new { Id = id }

    This object is passed to the stored procedure to specify the Id parameter that the stored procedure expects.
    await:

    The await keyword ensures that the method waits asynchronously for the LoadData task to complete without blocking the main thread. Once the data is loaded, the code continues execution.
    results.FirstOrDefault():

    After fetching the data, results.FirstOrDefault() is used to return the first CarModel in the list (if one exists). If no cars match the ID, FirstOrDefault() will return null.
     */
    public async Task<CarModel?> GetCar(int id)
    {
        var results = await _db.LoadData<CarModel, dynamic>(
            storedProcedure: "dbo.spCar_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    //TODO: Insert

    public Task InsertCar(CarModel car) =>
        _db.SaveData(storedProcedure: "dbo.spCar_Insert",
                     new { car.Model, car.Make, car.Year, car.Price });
    //TODO: Update
    public Task UpdateCar(CarModel car) =>
        _db.SaveData(storedProcedure: "dbo.spCar_Update", car);

    //TODO: Delete
    public Task DeleteCar(int id) =>
        _db.SaveData(storedProcedure: "dbo.spCar_Delete", id);
    //TODO: --Drop-- as a challenge, it will require to do a stored procedure.
    //TODO: create the store procedure. 

}
