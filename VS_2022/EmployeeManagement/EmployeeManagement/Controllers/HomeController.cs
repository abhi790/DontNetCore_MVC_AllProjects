using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Employee> listOfEmployee = _employeeRepository.GetAllEmployee();
            ViewBag.Title = "Employee List";
            return View(listOfEmployee);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EditEmployeeViewModel model = new EditEmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department
                };
                _employeeRepository.EditEmployee(emp);
                return RedirectToAction("index", "home");
            }

            return View();
        }

		[HttpDelete]
        public IActionResult Delete(int id)
		{
            Employee employee = _employeeRepository.GetEmployee(id);
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("index","home");
		}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department
                };
                _employeeRepository.AddEmployee(emp);
                return RedirectToAction("index", "home");
            }
            return View();

        }

    }
}
