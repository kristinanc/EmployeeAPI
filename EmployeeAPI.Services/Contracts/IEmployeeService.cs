using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.Contracts
{
    public interface IEmployeeService
    {
        List<EmployeeProj> GetEmployees();
        Employee GetEmployeeById(int id);
        void InsertEmployee(EmployeeCreate employee);
    }
}
