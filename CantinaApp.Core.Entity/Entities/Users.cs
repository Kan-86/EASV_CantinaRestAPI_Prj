using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.Entity.Models
{
    public class Users
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string MyProperty { get; set; }
        public bool IsAdmin { get; set; }
    }
}
