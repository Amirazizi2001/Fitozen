﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Dtos
{
    public class PackageListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> ProductNames { get; set; }
        public string? DiscountTitle { get; set; }
    }
}
