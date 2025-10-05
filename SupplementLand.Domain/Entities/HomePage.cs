using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class HomePage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string SupportEmail { get; set; }
        public string InstagramId { get; set; }
        public string TelegramId { get; set; }
        public string ENamdMeta { get; set; }
        public string ENamdTag { get; set; }
    }
}
