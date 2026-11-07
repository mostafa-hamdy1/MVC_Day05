using Microsoft.AspNetCore.Mvc;
using MVC_Day02.Models;
using MVC_Day02.ViewModels;

namespace MVC_Day02.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();
        // 1. /Student/ShowAll
        public IActionResult ShowAll()
        {
            StudentBL studentBL = new StudentBL();
            var students = studentBL.GetAll(); 
            return View(students);
        }
        // 2. /Student/ShowDetails?id=3
        public IActionResult ShowDetails(int id)
        {
            
            Student student = studentBL.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View("ShowDetails", student);
        }
        // 1. Add - GET
        [HttpGet]
        public IActionResult Add()
        {
            StudentAddViewModel viewModel = new StudentAddViewModel();
            viewModel.Departments = studentBL.GetAllDepartments() ?? new List<Department>();
            return View(viewModel);
        }
        // 2. Add - POST
        [HttpPost]
        public IActionResult Add(StudentAddViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                Student student = new Student
                {
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    DepartmentId = viewModel.DepartmentId.Value
                };

                studentBL.Add(student);
                return RedirectToAction(nameof(ShowAll));
            }

            viewModel.Departments = studentBL.GetAllDepartments();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = studentBL.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            StudentEditViewModel viewModel = new StudentEditViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                DepartmentId = student.DepartmentId,
                Departments = studentBL.GetAllDepartments()
            };

            return View(viewModel);
        }
        // 2. Edit - POST 
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel viewModel)
        {
            StudentBL studentBL = new StudentBL();

            if (ModelState.IsValid)
            {
                Student student = new Student
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    DepartmentId = viewModel.DepartmentId.Value
                };

                studentBL.Update(student);
                return RedirectToAction(nameof(ShowAll));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            viewModel.Departments = studentBL.GetAllDepartments() ?? new List<Department>();
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            studentBL.Delete(id);

            return RedirectToAction(nameof(ShowAll));
        }
    }
}
