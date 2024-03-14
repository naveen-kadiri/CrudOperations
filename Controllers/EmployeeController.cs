

using System;
using System.Collections.Generic;
using CrudOperations.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployee _employee;

    public EmployeeController(IEmployee employee)
    {
        _employee = employee;
    }

    [HttpGet("GetAll")]
    public ActionResult<IEnumerable<Employees>> GetEmployees()
    {
        return Ok(_employee.GetEmployees());
    }

    [HttpGet("{id}")]
    public ActionResult<Employees> GetEmployee(int id)
    {
        var response = _employee.GetEmployee(id);
        if(response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPost]
    public ActionResult<IEnumerable<Employees>> AddEmployees(Employees employees)
    {
        return Ok(_employee.AddEmployees(employees));
    }

    [HttpPut]
    public ActionResult<Employees> UpdateEmployees(Employees employees)
    {
        var response = _employee.UpdateEmployee(employees);
        if(response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult<IEnumerable<Employees>> DeleteEmployees(int id)
    {
        var response = _employee.DeleteEmployees(id);
        if(response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}