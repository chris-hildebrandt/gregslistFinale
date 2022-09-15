using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using gregslistFinale.Models;

namespace gregslistFinale.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db) {
      _db = db;
    }

    internal List<Car> GetAllCars()
    {
      string sql = @"
      SELECT * FROM cars;
      ";
      List<Car> cars = _db.Query<Car>(sql).ToList();
      return cars;
    }

    internal Car GetCarById(int id)
    {
      string sql = @"
      SELECT * FROM cars
      WHERE id = @id;
      ";
      Car car = _db.Query<Car>(sql, new { id }).FirstOrDefault();
      return car;
    }

    internal Car Create(Car newCar)
    {
      string sql = @"
      INSERT INTO cars
      (make, model, year, color, price, description, imgUrl)
      Values
      (@make, @model, @year, @color, @price, @description, @imgUrl);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newCar);
      newCar.Id = id;
      return newCar;
    }

    internal Car Update(Car original)
    {
      string sql = @"
      UPDATE cars SET
        make = @make,
        model = @model,
        year = @year,
        price = @price,
        imgUrl = @imgUrl,
        description = @description,
        color = @color
      WHERE id = @id;
      ";
      int rowsAffected = _db.Execute(sql, original);
      if (rowsAffected == 0){
        throw new Exception("Error trying to edit car");
      }
      return original;
    }

    internal void Delete(int id)
    {
      string sql = @"
      DELETE FROM cars WHERE id = @id;
      ";
      _db.Execute(sql, new { id });
    }
  }
}