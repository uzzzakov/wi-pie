using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khinkali.Models
{
    public class Khinkalis
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
        [Column(TypeName = "nvarchar(300)")]
        [Display(Name = "compound")]
        public string Compound { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "cost")]
        public decimal Cost { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "filling")]
        public string Filling { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [Display(Name = "amount")]
        public int Amount { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Image { get; set; }
        /*[Required(ErrorMessage = "Please choose image")]*/
        [Display(Name = "picture")]
        [NotMapped]
        public IFormFile Picture { get; set; }
    }
}
