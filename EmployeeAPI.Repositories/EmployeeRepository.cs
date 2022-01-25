using EmployeeAPI.Models;
using EmployeeAPI.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private Dictionary<int, Employee> EmployeeList { get; set; }
        public EmployeeRepository()
        {
            //Modified seed data to remove quotes using search/replace in Visual Studio

            var seedData = @" Id = 1, LastName = Jackson, FirstName = Alberta, Department = Finance, HireDate = 6/5/2007
                              Id = 2, LastName = Bennett, FirstName = Alicia, Department = Human Resources, HireDate = 4 / 15 / 2001
                              Id = 3, LastName = Avent, FirstName = Donna, Department = Revenue, HireDate = 4 / 20 / 2009
                              Id = 4, LastName = Holder, FirstName = Duane, Department = Human Services, HireDate = 8 / 15 / 2020";

            
            EmployeeList = ProcessEmployeeSeedDataIntoList(seedData);
        }
        public List<Employee> GetEmployees()
        {
            return EmployeeList.Values.ToList();

        }
        public Employee GetEmployeeById(int id)
        {

            try
            {
                if (!EmployeeList.ContainsKey(id)) throw new Exception("Employee Id does not exist");

                return EmployeeList[id];


            }
            catch (Exception)
            {

                throw;
            }


        }
        public void InsertEmployee(EmployeeCreate employee)
        {
            try
            {
                Employee newEmployee = new Employee()
                {
                    Id = GenerateNewEmployeeId(),
                    LastName = employee.LastName,
                    FirstName = employee.FirstName,
                    Department = employee.Department,
                    HireDate = employee.HireDate,
                };

                if (!EmployeeList.ContainsKey(newEmployee.Id))
                {
                    EmployeeList.Add(newEmployee.Id, newEmployee);
                }
                else
                {
                    throw new Exception("Employee Id is not unique");
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        private Dictionary<int, Employee> ProcessEmployeeSeedDataIntoList(string seedData)
        {
       

            var employeeList = new Dictionary<int, Employee>();

            if (!string.IsNullOrEmpty(seedData.Trim()))
            {
                var seedArray = seedData.Split("\r\n");
                for (int i = 0; i < seedArray.Length; i++)
                {

                    var employee = new Employee();

                    var employeeData = seedArray[i].Split(",");

                    employee.Id = int.Parse(employeeData[0].Split("=")[1]);
                    employee.LastName = employeeData[1].Split("=")[1].Trim();
                    employee.FirstName = employeeData[2].Split("=")[1].Trim();
                    employee.Department = employeeData[3].Split("=")[1].Trim();
                    employee.HireDate = DateTime.Parse(employeeData[4].Split("=")[1].Trim());


                    employeeList.Add(employee.Id, employee);

                }
            }
            return employeeList;


        }
        private int GenerateNewEmployeeId()
        {
            var newId = 1;

            var employees = EmployeeList.Values.ToList();

            if (employees != null && employees.Count > 0)
            {
                newId = employees.Max(x => x.Id) + 1;
            }

            return newId;

        }

    }
}
