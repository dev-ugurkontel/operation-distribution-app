using Microsoft.AspNetCore.Mvc;
using OperationDistributionApp.Application.Interfaces;
using OperationDistributionApp.Domain.Surrogate.Request;

namespace OperationDistributionApp.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _employeeService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(EmployeeRequest data)
        {
            _employeeService.Add(data);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, EmployeeRequest data)
        {
            _employeeService.Update(id, data);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return Ok();
        }
    }
}
