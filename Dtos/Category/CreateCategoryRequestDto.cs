using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Category
{
    public class CreateCategoryRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public bool Active { get; set; } = false;
        public bool Promoted { get; set; } = false;
    }
}