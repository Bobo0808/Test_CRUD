using Microsoft.AspNetCore.Mvc;
using TEST.Models;
using TEST.Models.Domain;

namespace TEST.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //一種請求方式用於更新或刪除操作
        [HttpPost]

        //我需要這邊的解釋
        public IActionResult add(AddEmployeeViewModel addEmployeeViewModel) 
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeViewModel.Name,
                Email = addEmployeeViewModel.Email,
                Salary = addEmployeeViewModel.Salary,
                Department = addEmployeeViewModel.Department,
                DateOfBirth = addEmployeeViewModel.DateOfBirth,
                
            
            
            };

        }
    }
}
