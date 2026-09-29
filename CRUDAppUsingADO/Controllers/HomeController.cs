using CRUDAppUsingADO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System.Diagnostics;

namespace CRUDAppUsingADO.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeDataAccessLayer;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeDataAccessLayer = employeeRepository;
        }
        public IActionResult Index()
        {
            List<Employee> employees = _employeeDataAccessLayer.GetAllEmployee();

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {

            try
            {
                _employeeDataAccessLayer.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Edit(int id)
        {

            Employee employee = _employeeDataAccessLayer.GetEmployeeById(id);
            return View(employee);
        }

        public IActionResult Details(int id)
        {

            Employee employee = _employeeDataAccessLayer.GetEmployeeById(id);
            return View(employee);
        }

        public IActionResult Delete(int id)
        {

            Employee employee = _employeeDataAccessLayer.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _employeeDataAccessLayer.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            try
            {
                _employeeDataAccessLayer.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
