
using System.ComponentModel.DataAnnotations.Schema;

namespace DokanyApp.BLL
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public int Month{ get; set; } 
        public int Year { get; set; }

    }
}
