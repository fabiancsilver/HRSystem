using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.HR
{
    public class Shift
    {
        [Key]
        public int ShiftID { get; set; }


        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

    }
}
