using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TEST.Data;
using TEST.Models;
using TEST.Models.Domain;

namespace TEST.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //一種請求方式用於更新或刪除操作

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mvcDemoDbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpPost]
        //方法名稱Add,其返回型別是IActionResult 這個方法接收一個AddEmployeeViewModel對象作為參數,這對象包含以下資訊
        //async Task<IActionResult> 異步方法
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewModel)
        {
            //創建一個新的Employee為其賦值，可以使用這個Employee進行後續處理，如將資料保存到資料庫。
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeViewModel.Name,
                Email = addEmployeeViewModel.Email,
                Salary = addEmployeeViewModel.Salary,
                Department = addEmployeeViewModel.Department,
                DateOfBirth = addEmployeeViewModel.DateOfBirth,
            };
            //用於將新增的Employee對象保存到資料庫中
            //第一行 將新建的Employee對象 加入mvcDemoDbContext
            //為什麼要使用await呢?因為上面已經用了異步方法 使用await就可以等待異步完成後再執行
            await mvcDemoDbContext.Employees.AddAsync(employee);
            //將更動保存到資料庫中
            await mvcDemoDbContext.SaveChangesAsync();
            //返回介面
            //RedirectToAction 方法會返回一個重定向的結果，讓瀏覽器重新導向到指定的 Action 方法。
            return RedirectToAction("Add");
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                var ViewModel = new UpdateEmployeeViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    DateOfBirth = employee.DateOfBirth,

                };
                //將整個返回操作包在Task對象裡面
                return await Task.Run(() => View("View", ViewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await mvcDemoDbContext.Employees.FindAsync(model.Id);
            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;

                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");


            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await mvcDemoDbContext.Employees.FindAsync(model.Id);
            if (employee != null) 
            {
            mvcDemoDbContext.Employees.Remove(employee);
                await mvcDemoDbContext.SaveChangesAsync();


                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }
    }
}
