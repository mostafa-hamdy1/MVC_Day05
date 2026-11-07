using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Day02.Data.DbContexts;
using MVC_Day02.Models;
using MVC_Day02.ViewModels;

namespace MVC_Day02.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBL departmentBL = new DepartmentBL();

        // /Department/ShowAll
        public IActionResult ShowAll()
        {

            List<Department> DeptList = departmentBL.GetAll();
            return View("ShowAll", DeptList); // Model : List<Department>
        }

        // /Department/ShowDetails?id=2
        public IActionResult ShowDetails(int id)
        {
            // 1- Resources
            Department dept = departmentBL.GetById(id);
            if (dept == null) return NotFound();

            // 2- Destination (Manual Mapping : resource -> Destination)
            DeptWithStudentsViewModel DVM = new DeptWithStudentsViewModel();
            DVM.DeptName = dept.Name;
            DVM.State = dept.Students.Count > 50 ? "Main" : "Branch";
            DVM.StudentNames = dept.Students
                .Where(S => S.Age > 25)
                .Select(S => S.Name)
                .ToList();

            // 3- Send to FE (View) > ViewModel
            return View("ShowDetails", DVM); // ViewModel : DeptWithStudentsViewModel
        }

        // /Department/Add  (GET: show form)
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        // /Department/Add  (POST: save)
        [HttpPost]
        public IActionResult Add(Department dept)
        {
            if (ModelState.IsValid)
            {
                departmentBL.Add(dept);
                return RedirectToAction("ShowAll");
            }
            return View("Add", dept);
        }
    }
}