using System;
using System.Collections.Generic;
using System.Text;

namespace BCKyivApp.Core.Models
{
    public class Centre
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public Contact Contact { get; set; }
    }
}
