using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnicav2.Dtos
{
    public class ActualizarProductDto
    {
        [Required]
        public string Name { get; set; }

        [Range(0.01, 999999)]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
