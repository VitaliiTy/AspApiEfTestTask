using System;
using System.Collections.Generic;

namespace AspApiEfProject.Models
{
    public partial class Incident
    {
        public Incident()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
