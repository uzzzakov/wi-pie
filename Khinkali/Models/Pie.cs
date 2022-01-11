using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khinkali.Models
{
    public class Pie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="id")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName= "nvarchar(100)")]
        [Display(Name = "name")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(300)")]
        [Display(Name = "compound")]
        public string Compound { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "cost")]
        public decimal Cost { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 1)")]
        [Display(Name = "diameter")]
        public decimal Diameter { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "filling")]
        public string Filling { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [Display(Name = "weight")]
        public int Weight { get; set; }
        /*[Required]*/
        [Column(TypeName = "nvarchar(100)")]
        /*[Display(Name = "image")]*/
        public string Image { get; set; }
        [Required(ErrorMessage = "Please choose image")]
        [Display(Name = "picture")]
        [NotMapped]
        public IFormFile Picture { get; set; }
    }
}
