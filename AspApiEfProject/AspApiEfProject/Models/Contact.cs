using System;
using System.Collections.Generic;

namespace AspApiEfProject.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
    }
}
