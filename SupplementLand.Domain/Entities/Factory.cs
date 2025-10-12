using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Factory
    {
        public Factory(int id,string name,string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
        public Factory()
        {
            
        }
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Country { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Document>? Documents { get; set; }


    }
}
