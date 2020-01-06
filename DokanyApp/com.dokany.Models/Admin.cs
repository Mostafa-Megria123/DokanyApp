using System;
using System.Collections.Generic;

namespace DokanyApp.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
