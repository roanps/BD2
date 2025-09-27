using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_teste.Models
{
    [PrimaryKey(nameof(StudentId),nameof(CourseId))]
    public class StudentCourses
    {
        public int StudentId { get; set; }

        //Property navigations
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime? CancelDate { get; set; }
    }
}
