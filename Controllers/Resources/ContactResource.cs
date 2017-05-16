using System.ComponentModel.DataAnnotations;

namespace VEGA.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLengthAttribute(255)]
        public string Name { get; set; }
        [StringLengthAttribute(255)]
        public string Email { get; set; }
        [Required]
        [StringLengthAttribute(255)]
        public string Phone { get; set; }
    }
}