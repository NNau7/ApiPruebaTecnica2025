using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using APIPruebaTecnicav1.Data;
using APIPruebaTecnicav1.Models;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ApiDbContext _context;
    private readonly IMapper _mapper;

    public CategoriaController(ApiDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

   
    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearCategoryDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var categoria = _mapper.Map<Category>(dto);
        _context.Categories.Add(categoria);
        await _context.SaveChangesAsync();

        var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = categoria.Id }, categoriaDto);
    }

   
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> ObtenerTodas()
    {
        var categorias = await _context.Categories.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(categorias));
    }

   
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaDto>> ObtenerPorId(int id)
    {
        var categoria = await _context.Categories.FindAsync(id);
        if (categoria == null) return NotFound();

        return Ok(_mapper.Map<CategoriaDto>(categoria));
    }

   
    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var categoria = await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (categoria == null) return NotFound();

        if (categoria.Products.Any())
            return BadRequest("No se puede eliminar una categoría que tiene productos asociados.");

        _context.Categories.Remove(categoria);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

