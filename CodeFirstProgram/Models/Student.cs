using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstProgram.Models
{
    public class Student
    {

        [Key]
        public int Id { get; set; }

        [Column("StudentName",TypeName ="varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column("StudentGender",TypeName ="varchar(50)")]
        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public string standard { get; set; }




    }
    public enum Gender
    {
        Male,Female,Other
    }
}
