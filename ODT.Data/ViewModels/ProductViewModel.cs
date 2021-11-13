using System;
using System.Collections.Generic;
using System.Text;

namespace ODT.Data.ViewModels
{
    public class ProductViewModel
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public double Amount    { get; set; }
    }
}
