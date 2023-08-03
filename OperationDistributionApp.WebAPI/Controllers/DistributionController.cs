using Microsoft.AspNetCore.Mvc;
using OperationDistributionApp.Application.Interfaces;
using OperationDistributionApp.Domain.Entities;

namespace OperationDistributionApp.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        private readonly IDistributionService _distributionService;

        public DistributionController(IDistributionService distributionService)
        {
            _distributionService = distributionService;
        }

        [HttpGet]
        [Route("histories")]
        public IActionResult GetAll()
        {
            var result = _distributionService.GetAll();
            return Ok(result);
        }

        [HttpPut]
        [Route("renqueue-deploy")]
        public IActionResult RenqueueDeploy()
        {
            _distributionService.RenqueueDeploy();
            return Ok();
        }
    }
}
