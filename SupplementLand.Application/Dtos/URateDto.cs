using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class URateDto
    {
        public int Id { get; set; }

        [Range(1, 5, ErrorMessage = "your score must be between 1,5")]
        public int Score { get; set; }
    }
}
