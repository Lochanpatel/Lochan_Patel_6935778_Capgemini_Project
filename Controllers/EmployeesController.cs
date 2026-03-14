using Microsoft.AspNetCore.Mvc;
using EmployeeProjectManagement.Models;
using System.Linq;

namespace EmployeeProjectManagement.Controllers
{
	public class EmployeesController : Controller
	{
		private readonly AppDbContext _context;

		public EmployeesController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var employees = _context.Employees.ToList();
			return View(employees);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Employee employee)
		{
			_context.Employees.Add(employee);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}