using CarTransfer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarTransfer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IRepasitory<Car, int> _carRepasitory;
        public CarController(IRepasitory<Car,int> carRepasitory)
        {
           _carRepasitory = carRepasitory;
        }

        [HttpPost("AddCar")]
        public ActionResult AddCar(Car car)
        {
            _carRepasitory.Add(car);
            return Ok(car);
        }

        [HttpDelete("DeleteCar")]
        public ActionResult DeleteCar(int id)
        {
            _carRepasitory.Delete(id);
            return Ok();
        }

        [HttpPut("UpdateCar")]
        public ActionResult UpdateCar(Car car)
        {
            _carRepasitory.Update(car);
            return Ok(car);
        }

        [HttpGet("GetCarByID")]
        public ActionResult GetCarByID(int id)
        {
            return Ok(_carRepasitory.GetById(id));
        }

        [HttpGet("GetAllCars")]
        public ActionResult GetAllCars()
        {
            return Ok(_carRepasitory.GetAll());
        }

    }
}
