using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Day02.Models;

namespace MVC_Day02.Data.Configurations
{
    public class StuCrsResConfigurations : IEntityTypeConfiguration<StuCrsRes>
    {
        public void Configure(EntityTypeBuilder<StuCrsRes> builder)
        {
            builder.ToTable("StudentCourseResults");

            // Composite Primary Key
            builder.HasKey(scr => new { scr.StudentId, scr.CourseId });

            builder.HasOne(scr => scr.Student)
                   .WithMany(s => s.StuCrsReses)
                   .HasForeignKey(scr => scr.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(scr => scr.Course)
                   .WithMany(c => c.StuCrsReses)
                   .HasForeignKey(scr => scr.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
