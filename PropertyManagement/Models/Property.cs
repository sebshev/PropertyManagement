using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class Property
    {
        [Key]
        public string PropertyId { get; set; }
        public string Address { get; set; }

        public double Rooms { get; set; }

        public double Baths { get; set; }
    }
}
