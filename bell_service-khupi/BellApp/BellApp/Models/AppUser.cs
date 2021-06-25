using System;
using System.Collections.Generic;
using System.Text;

namespace BellApp.Models
{
    public class AppUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string ApiKey { get; set; }

        public string Password { get; set; }
    }
}
