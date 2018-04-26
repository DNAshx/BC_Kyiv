using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BCKyivApp.Data.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string PhoneNo { get; set; }
        public int CentreId { get; set; }

        [ForeignKey(nameof(CentreId))]
        public Centre Centre { get; set; }
    }
}
