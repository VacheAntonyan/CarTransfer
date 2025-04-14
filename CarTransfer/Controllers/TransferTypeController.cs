using CarTransfer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarTransfer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferTypeController : ControllerBase
    {
        private readonly TransferType _transferType;

        public TransferTypeController(TransferType transferType)
        {
            _transferType = transferType;
        }


    }
}
