using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<CategoryListDto>? Childern { get; set; }
    }
}
