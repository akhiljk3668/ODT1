using System;
using System.Collections.Generic;
using System.Text;

namespace ODT.Data.Models
{
    public class UserDetails
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public long RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
