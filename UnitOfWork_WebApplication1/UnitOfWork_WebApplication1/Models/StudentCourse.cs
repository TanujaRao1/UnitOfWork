using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWork_WebApplication1.Models
{
    public class StudentCourse
    {
        [Key]
        [Column(Order = 1)] //Key along with Column is used to define Composite relationship
        public int StudentId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CourseId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
