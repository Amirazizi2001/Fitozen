using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Filters
{
    public class UserFilter:Filter
    {
        public string? FullName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        
    }
}
