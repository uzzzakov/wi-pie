using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Khinkali.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public decimal Sum { get; set; }
    }
}
