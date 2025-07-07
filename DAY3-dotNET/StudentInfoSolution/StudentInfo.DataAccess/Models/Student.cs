
using System.ComponentModel.DataAnnotations;


namespace StudentInfo.DataAccess.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string StudentName { get; set; }

        [Required]
        public string Enrollment{ get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }
    }
}
