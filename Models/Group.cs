using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int Yers { get; set; }
        public string Speciality { get; set; }
        public int? TeacherId { get; set; }  
        public int? CursId { get; set; }
    }
}
