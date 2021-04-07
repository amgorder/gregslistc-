using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist.Models;
using gregslist.db;

namespace gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        //actionResult is a wrapper that handles the request status.
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(FakeDB.Cars);
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        //FROMBODY uses a parameterless class constructor to map data over from the request to the model.
        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                FakeDB.Cars.Add(newCar);
                return Ok(newCar);
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        // .get("/:carId", this.GetCar)
        [HttpGet("{carId}")]
        public ActionResult<Car> GetCar(string carId)
        {
            try
            {
                Car carFound = FakeDB.Cars.Find(c => c.Id == carId);
                if (carFound == null)
                {
                    throw new System.Exception("That's a NO GO ghostrider.");
                }
                return Ok(carFound);
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCar(string id)
        {
            try
            {
                Car carToRemove = FakeDB.Cars.Find(c => c.Id == id);
                if (FakeDB.Cars.Remove(carToRemove))
                {
                    return Ok("Car Demolished");
                }
                else
                {
                    throw new System.Exception("That's a NO GO ghostrider.");
                }
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);

            }
        }
        [HttpPut("{carId}")]
        public ActionResult<Car> EditCar(string carId)
        {
            try
            {
                Car carFound = FakeDB.Cars.Find(c => c.Id == carId);
                if (carFound == null)
                {
                    throw new System.Exception("That's a NO GO ghostrider.");
                }
                //return upate info without a new id?
                //
                return Ok(carFound);
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }
    }
}