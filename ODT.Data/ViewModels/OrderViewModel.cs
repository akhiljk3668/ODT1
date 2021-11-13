using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ODT.Data.ViewModels
{
    public class OrderViewModel
    {
        [DisplayName("Order Number")]
        public long OrderId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }

        public string Customer { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        [DisplayName("Current Place")]
        public string Place { get; set; }
        public string Status { get; set; }
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; }

    }
}
