using CarTransfer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarTransfer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepasitory<Car, int> _carRepasitory;
        private readonly IRepasitory<Transfers, int> _transferRepasitory;

        public AdminController(IRepasitory<Transfers, int> transferRepasitory, IRepasitory<Car, int> carRepasitory)
        {
            _transferRepasitory = transferRepasitory;
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

        [HttpPost("AddTransfer")]
        public ActionResult AddTransfer(Transfers transfer)
        {
            _transferRepasitory.Add(transfer);
            return Ok(transfer);
        }

        [HttpDelete("DeleteTransfer")]
        public ActionResult DeleteTransfer(int id)
        {
            _transferRepasitory.Delete(id);
            return Ok();
        }

        [HttpPut("UpdateTransfer")]
        public ActionResult UpdateTransfer(Transfers transfer)
        {
            _transferRepasitory.Update(transfer);
            return Ok(transfer);
        }

        [HttpGet("GetTransferByID")]
        public ActionResult GetTransferByID(int id)
        {
            _transferRepasitory.GetById(id);
            return Ok(id);
        }

        [HttpGet("GetAllTransfers")]
        public ActionResult GetAllTransfers()
        {
            return Ok(_transferRepasitory);
        }
    }
}
