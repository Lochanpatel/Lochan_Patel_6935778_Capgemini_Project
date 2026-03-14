using Microsoft.AspNetCore.Mvc;
using EmployeeProjectManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeProjectManagement.Controllers
{
	public class ProjectsController : Controller
	{
		private readonly AppDbContext _context;

		public ProjectsController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View(_context.Projects.ToList());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Project project)
		{
			_context.Projects.Add(project);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Dashboard()
		{
			var projects = _context.Projects
				.Include(p => p.EmployeeProjects)
				.ThenInclude(ep => ep.Employee)
				.ThenInclude(e => e.Department)
				.ToList();

			return View(projects);
		}
	}
}