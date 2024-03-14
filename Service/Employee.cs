using CrudOperations.Data;
using CrudOperations.Models;

namespace CrudOperations.Service
{
    public class Employee : IEmployee
    {
        private readonly DataContext _context;
        public Employee(DataContext context)
        {
            _context = context;
        }

        public ServiceResponse<IEnumerable<Employees>> AddEmployees(Employees employees)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Employees>>();
            _context.Employees.Add(employees);
            _context.SaveChanges();
            serviceResponse.Data = _context.Employees.ToList();
            return serviceResponse;
        }

        public ServiceResponse<IEnumerable<Employees>> DeleteEmployees(int id)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Employees>>();
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                _context.Employees.Remove(employee);
                _context.SaveChanges();

                serviceResponse.Data = _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

        public ServiceResponse<Employees> GetEmployee(int id)
        {
            var serviceResponse = new ServiceResponse<Employees>();
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if(employee is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Employee is Not Found";
                return serviceResponse;
            }
            else
            {
                serviceResponse.Data = employee;
            }
            return serviceResponse;
        }

        public ServiceResponse<IEnumerable<Employees>> GetEmployees()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Employees>>();
            var employees = _context.Employees.ToList();
            serviceResponse.Data = employees;
            return serviceResponse;

        }

        public ServiceResponse<Employees> UpdateEmployee(Employees employees)
        {
            var serviceResponse = new ServiceResponse<Employees>();
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == employees.Id);
                employee.Name = employees.Name;
                employee.Email = employees.Email;
                employee.PhoneNumber = employees.PhoneNumber;
                employee.Address = employees.Address;
                employee.ZipCode = employees.ZipCode;

                _context.SaveChanges();

                serviceResponse.Data = employee;
                
            }
            catch (Exception ex) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
