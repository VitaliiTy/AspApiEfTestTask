using System;
using System.Collections.Generic;

namespace AspApiEfProject.Models
{
    public partial class Account
    {
        public Account()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? IncidentId { get; set; }

        public virtual Incident? Incident { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
