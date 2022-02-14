using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khinkali.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "name")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Введите номер телефона")]
        [Display(Name = "phone")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите адрес")]
        [Display(Name = "address")]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        [Display(Name = "date")]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Display(Name = "sum")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sum { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "details")]
        public string Details { get; set; }

    }
}
