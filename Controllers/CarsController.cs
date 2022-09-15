using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gregslistFinale.Models;
using gregslistFinale.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslistFinale.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class CarsController : ControllerBase
  {

    private readonly CarsService _carsService;

    public CarsController(CarsService carsService)
    {
      _carsService = carsService;
    }

    [HttpGet]
    public ActionResult<List<Car>> GetAllCars()
    {
      try
      {
        List<Car> cars = _carsService.GetAllCars();
        return cars;
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById(int id)
    {
      try
      {
        return Ok(_carsService.GetCarById(id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        Car car = _carsService.Create(newCar);
        return Ok(car);
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Car> Update(int id, [FromBody] Car update)
    {
      try
      {
        update.Id = id;
        return Ok(_carsService.Update(update));
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_carsService.Delete(id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }
  }
}