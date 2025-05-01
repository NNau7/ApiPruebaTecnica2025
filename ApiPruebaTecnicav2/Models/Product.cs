using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPruebaTecnicav1.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "el nombe es obligaorio")]
        [Display(Name = "nombre del producto")]
        public string Name { get; set; }

        [Required(ErrorMessage = "el precio es obligatorio.")]
        [Range(0.1, 100000, ErrorMessage = "el precio debe estar entre 0.1 y 100000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
