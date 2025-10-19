using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public int? FactoryId { get; set; }
        public int? ProductId { get; set; }
        public bool IsDefault { get; set; }=false;
    }
}
