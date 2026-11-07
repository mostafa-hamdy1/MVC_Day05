using MVC_Day02.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_Day02.ViewModels
{
    public class StudentAddViewModel
    {
        [Required(ErrorMessage = "Student name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; }

        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        public int? DepartmentId { get; set; }

        public List<Department>? Departments { get; set; }
    }
}