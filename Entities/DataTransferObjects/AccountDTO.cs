using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AccountDTO
    {
        public string Username { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Initials { get; set;  }
        public string PhoneNumber { get; set; }

    }
}
