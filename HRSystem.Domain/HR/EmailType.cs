using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.HR
{
    public class EmailType
    {
        [Key]
        public int EmailTypeID { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
