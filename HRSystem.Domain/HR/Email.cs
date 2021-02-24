using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.HR
{
    public class Email
    {

        [Key]
        public int EmailID { get; set; }

        [Required]
        public int EmployeeID { get; set; }


        [Required]
        public int EmailTypeID { get; set; }

        [Required]
        [MaxLength(128)]
        public string EmailAddress { get; set; }

    }
}
