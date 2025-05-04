using APIPruebaTecnicav2.Data;
using APIPruebaTecnicav2.Models;
using ApiPruebaTecnicav2.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnicav2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ProductoController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var categoria = await _context.Categories.FindAsync(dto.CategoryId);
            if (categoria == null) return BadRequest("La categoría no existe.");

            var producto = _mapper.Map<Product>(dto);
            _context.Products.Add(producto);
            await _context.SaveChangesAsync();

            
            await _context.Entry(producto).Reference(p => p.Category).LoadAsync();
            return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, _mapper.Map<ProductDto>(producto));
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> ObtenerTodos()
        {
            var productos = await _context.Products.Include(p => p.Category).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(productos));
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> ObtenerPorId(int id)
        {
            var producto = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null) return NotFound();

            return Ok(_mapper.Map<ProductDto>(producto));
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] ActualizarProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var producto = await _context.Products.FindAsync(id);
            if (producto == null) return NotFound();

            var categoria = await _context.Categories.FindAsync(dto.CategoryId);
            if (categoria == null) return BadRequest("La categoría no existe.");

            _mapper.Map(dto, producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Products.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
