
using CrudOperations.Models;
using CrudOperations.Service;
using System.Collections.Generic;

public interface IEmployee
{
    ServiceResponse<IEnumerable<Employees>> GetEmployees();
    ServiceResponse<Employees> GetEmployee(int id);
    ServiceResponse<IEnumerable<Employees>> AddEmployees(Employees employees);
    ServiceResponse<Employees> UpdateEmployee(Employees employees);
    ServiceResponse<IEnumerable<Employees>> DeleteEmployees(int id);


}