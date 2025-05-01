using System.ComponentModel.DataAnnotations;

public class CrearCategoryDto
{
    [Required(ErrorMessage = "El nombre de la categoría es requerido.")]
    [StringLength(100)]
    public string Name { get; set; }
}
