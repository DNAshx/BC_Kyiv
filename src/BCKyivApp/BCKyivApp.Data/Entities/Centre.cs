using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BCKyivApp.Data.Entities
{
    [Table("Centres")]
    public class Centre
    {
        [Key]
        public int Id { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Location { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
