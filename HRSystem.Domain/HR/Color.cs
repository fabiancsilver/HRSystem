using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.HR
{
    public class Color
    {

        [Key]
        public int ColorID { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

    }
}
