using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string FileName { get; set; }

        [Required, MaxLength(100)]
        public string ContentType { get; set; }  // مثلاً "image/jpeg"

        [Required]
        public byte[] Data { get; set; }

        // ارتباط با Factory (اختیاری)
        public int? FactoryId { get; set; }
        public Factory? Factory { get; set; }

        // ارتباط با Product (اختیاری)
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
