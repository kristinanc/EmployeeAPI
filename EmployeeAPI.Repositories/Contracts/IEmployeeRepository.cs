using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        void InsertEmployee(EmployeeCreate employee);
    }
}
