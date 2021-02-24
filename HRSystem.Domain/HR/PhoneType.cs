using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.HR
{
    public class PhoneType
    {
        [Key]
        public int PhoneTypeID { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
