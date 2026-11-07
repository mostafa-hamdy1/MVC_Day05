using Microsoft.EntityFrameworkCore;
using MVC_Day02.Data.DbContexts;
using MVC_Day02.Models;

namespace MVC_Day02.Models
{
    public class DepartmentBL
    {
        DigitalDbContext context = new DigitalDbContext();

        public List<Department> GetAll()
        {
            return context.Departments.Include(d => d.Students).ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments
                .Include(d => d.Students)
                .FirstOrDefault(d => d.Id == id);
        }

        public void Add(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
        }
    }
}