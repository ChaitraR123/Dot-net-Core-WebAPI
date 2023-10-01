using System.ComponentModel.DataAnnotations;

namespace ASPCoreWebAPICRUD.Models
{
    public class Students
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Standard { get; set; }
    }
}
