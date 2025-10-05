using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Category
    {
        public Category(int id,string name,int? parentId)
        {
            Id = id;
            Name = name;
            ParentId=parentId;
        }
        public Category()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public int? ParentId { get; set; }
        [JsonIgnore]
        public Category? Parent { get; set; }
        public ICollection<Category>? Childern { get; set; }
    }
}
