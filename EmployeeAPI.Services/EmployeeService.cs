using EmployeeAPI.Models;
using EmployeeAPI.Repositories.Contracts;
using EmployeeAPI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }
        public List<EmployeeProj> GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees();

            if (employees == null) return new List<EmployeeProj>();

            else
            {
                var filtered = employees.Select(x => new EmployeeProj { LastName = x.LastName, FirstName = x.FirstName, Department = x.Department }).ToList();

                return filtered.OrderBy(y => y.LastName).ThenBy(z => z.FirstName).ToList();

            }

        }
        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }
        public void InsertEmployee(EmployeeCreate employee)
        {
            //Would add some validation for Department here, check against a database list

            _employeeRepository.InsertEmployee(employee);

        }

    }
}
