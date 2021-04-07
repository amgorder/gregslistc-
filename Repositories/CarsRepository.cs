using System.Data;
using gregslist.Models;
using System;
using System.Collections.Generic;
using Dapper;

namespace gregslist.Repositories
{
    public class CarsRepository
    {
        public readonly IDbConnection _db;

        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Car> Get()
        {
            string sql = "SELECT * FROM cars;";
            return _db.Query<Car>(sql);
        }

        internal Car Create(Car newCar)
        {
            string sql = @"
            INSERT INTO cars
      (make, model, year, color, description, price, url)
      VALUES
      (@Make, @Model, @Year, @Color, @Description, @Price, @Url);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCar);
            newCar.Id = id;
            return newCar;
        }


        internal Car Edit(Car carToEdit)
        {

            //After you go an update it make sure to go and select it again
            string sql = @"
      UPDATE cars
      SET
          make = @Make,
          model = @Model,
          year = @Year,
          color = @Color,
          description = @Description,
          price = @Price,
          url = @Url,
      WHERE id = @Id;
      SELECT * FROM cars WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Car>(sql, carToEdit);

        }
        internal void Delete(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}