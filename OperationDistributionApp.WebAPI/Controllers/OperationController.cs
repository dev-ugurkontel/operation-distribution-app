using Microsoft.AspNetCore.Mvc;
using OperationDistributionApp.Application.Interfaces;
using OperationDistributionApp.Domain.Surrogate.Request;

namespace OperationDistributionApp.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _operationService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _operationService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(OperationRequest data)
        {
            _operationService.Add(data);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, OperationRequest data)
        {
            _operationService.Update(id, data);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _operationService.Delete(id);
            return Ok();
        }
    }
}
