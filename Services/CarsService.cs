using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gregslistFinale.Models;
using gregslistFinale.Repositories;

namespace gregslistFinale.Services
{
  public class CarsService
  {
    private readonly CarsRepository _carRepo;

    public CarsService(CarsRepository carRepo) {
        _carRepo = carRepo;
    }
    internal List<Car> GetAllCars()
    {
      return _carRepo.GetAllCars();
    }

    internal Car GetCarById(int id)
    {
      Car car = _carRepo.GetCarById(id);
      if (car == null){
      throw new Exception("Bad Car Id");
      }
      return car;
    }

    internal Car Create(Car newCar)
    {
      return _carRepo.Create(newCar);
    }

    internal Car Update(Car update)
    {
      Car original = GetCarById(update.Id);
      original.Make = update.Make ?? original.Make;
      original.Model = update.Model ?? original.Model;
      original.Year = update.Year ?? original.Year;
      original.Price = update.Price ?? original.Price;
      original.ImgUrl = update.ImgUrl ?? original.ImgUrl;
      original.Description = update.Description ?? original.Description;
      original.Color = update.Color ?? original.Color;
      return _carRepo.Update(original);
    }

    internal string Delete(int id)
    {
      Car car = GetCarById(id);
      // if car.creatorId != ???
      _carRepo.Delete(id);
      return $"{car.Make}{car.Model} has been deleted";
    }
  }
}