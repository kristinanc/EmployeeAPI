using EmployeeAPI.Models;
using EmployeeAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }


        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<EmployeeProj> Get()
        {
            return _employeeService.GetEmployees();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);


                return Ok(employee);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }



        }


        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeCreate employee)
        {
           try
            {               
                              
                _employeeService.InsertEmployee(employee);

                return Ok();


            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }


        }

       
    }
}
