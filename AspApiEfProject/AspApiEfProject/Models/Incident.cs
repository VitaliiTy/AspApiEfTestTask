using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspApiEfProject.Models
{
    public class Incident
    {
        public int Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
