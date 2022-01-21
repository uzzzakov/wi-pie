using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khinkali.Models
{
    public class Drink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "name")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "cost")]
        public decimal Cost { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [Display(Name = "volume")]
        public decimal Volume { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Image { get; set; }
        /*[Required(ErrorMessage = "Please choose image")]*/
        [Display(Name = "picture")]
        [NotMapped]
        public IFormFile Picture { get; set; }
    }
}
