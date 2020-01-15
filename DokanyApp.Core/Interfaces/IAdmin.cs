using System;

namespace DokanyApp.Core.Interfaces
{
    public interface IAdmin
    {
        int AdminId { get; set; }
        string AdminName { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}
