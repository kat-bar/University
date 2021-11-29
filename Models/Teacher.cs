using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        
    }
}
