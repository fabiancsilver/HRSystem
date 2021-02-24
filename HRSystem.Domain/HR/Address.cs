using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.HR
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int AddressTypeID { get; set; }

        [Required]
        [MaxLength(128)]
        public string Line1 { get; set; }

        [Required]
        [MaxLength(32)]
        public string City { get; set; }

        [Required]
        [MaxLength(32)]
        public string State { get; set; }

        [Required]
        [MaxLength(32)]
        public string Country { get; set; }

        [Required]
        [MaxLength(32)]
        public string ZipCode { get; set; }

        public AddressType AddressType { get; set; }
    }
}
