using CarTransfer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CarTransfer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IRepasitory<Transfers, int> _transferRepasitory;

        public TransferController(IRepasitory<Transfers, int> transferRepasitory)
        {
            _transferRepasitory = transferRepasitory;
        }

        [HttpPost]
        public ActionResult AddTransfer(Transfers transfer)
        {
            _transferRepasitory.Add(transfer);
            return Ok(transfer);
        }

        [HttpDelete]
        public ActionResult DeleteTransfer(int id)
        {
            _transferRepasitory.Delete(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateTransfer(Transfers transfer)
        {
            _transferRepasitory.Update(transfer);
            return Ok(transfer);
        }

        [HttpGet("Get")]
        public ActionResult GetTransferByID(int id)
        {
            _transferRepasitory.GetById(id);
            return Ok(id);
        }

        [HttpGet("GetAll")]
        public ActionResult GetAllTransfers()
        {
            return Ok(_transferRepasitory);
        }

    }
}
