using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Khinkali.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "image")]
        public string Image { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "name")]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "cost")]
        public decimal Cost { get; set; }
        [Column(TypeName = "int")]
        [Display(Name = "amount")]
        public int Amount { get; set; }
    }
}
