using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace AspApiEfProject.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
