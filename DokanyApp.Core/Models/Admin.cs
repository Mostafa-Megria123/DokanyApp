using DokanyApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DokanyApp.Core.Models
{
    public partial class Admin : IAdmin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
