using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Day02.ViewModels
{
    public class DeptWithStudentsViewModel
    {
        public string DeptName { get; set; }
        public string State { get; set; }
        public List<string> StudentNames { get; set; }
    }
}
