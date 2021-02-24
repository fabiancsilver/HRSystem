using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Domain.HR
{
    public class Phone
    {
        [Key]
        public int PhoneID { get; set; }

        public int EmployeeID { get; set; }

        [ForeignKey("PhoneType")]
        public int PhoneTypeID { get; set; }

        [Required]
        [MaxLength(128)]
        public string PhoneNumber { get; set; }


        public PhoneType PhoneType { get; set; }
    }
}
