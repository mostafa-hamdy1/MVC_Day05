
using Microsoft.EntityFrameworkCore;
using MVC_Day02.Data.DbContexts;

namespace MVC_Day02.Models
{
    public class StudentBL
    {
        DigitalDbContext context = new DigitalDbContext();

        public List<Student> GetAll()
        {
            return context.Students
                .Include(s => s.Department)
                .Include(s => s.StuCrsReses)
                .ThenInclude(scr => scr.Course)
                .ToList();
        }

        public Student GetById(int id)
        {
            return context.Students
                .Include(s => s.Department)
                .Include(s => s.StuCrsReses)
                .ThenInclude(scr => scr.Course)
                .FirstOrDefault(s => s.Id == id);
        }

        public List<Department> GetAllDepartments()
        {
            return context.Departments.ToList();
        }

        // 4. إضافة طالب جديد
        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
        // 5. تعديل بيانات طالب
        public void Update(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }
        // 6. حذف طالب
        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

    }
}
