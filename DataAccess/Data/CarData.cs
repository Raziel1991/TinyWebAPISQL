using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class CarData
{
    private readonly ISqlDataAccess _db;

    public CarData(ISqlDataAccess db)
    {
        _db = db;
    }

    // Get all data using dbo.spCar_getAll
    public Task<IEnumerable<CarModel>> GetCars() =>
        _db.LoadData<CarModel, dynamic>(storedProcedure: "dbo.spCar_getAll", new { });

    // Get data using dbo.spCar_Get 
    public async Task<CarModel?> GetCar(int id)
    {
        var results = await _db.LoadData<CarModel, dynamic>(
            storedProcedure: "dbo.spCar_Get",
            new { Id = id });
        return results.FirstOrDefault();    
    }

    //TODO: Insert


    //TODO: Update
    //TODO: Delete
    //TODO: --Drop-- as a challenge, it will require to do a stored procedure.
        //TODO: create the store procedure. 

}
