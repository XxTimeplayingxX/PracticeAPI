using Microsoft.AspNetCore.Mvc;
using PracticeAPI.MODELS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private static List<Producto> _productos = new List<Producto>
        {
            new Producto
            {
                ID = 1,
                Nombre = "Leche Entera",
                Descripción = "Leche entera Parmalac, 900ml",
                Cantidad = 1,
                Precio = 0.95
            },
            new Producto
            {
                ID = 2,
                Nombre = "Chocolate",
                Descripción ="Chocolate Cocoa 500 gramos",
                Cantidad = 2,
                Precio = 0.50
            },
            new Producto
            {
                ID  =3,
                Nombre = "Agua",
                Descripción = "Agua purificada",
                Cantidad = 3,
                Precio = 0.50
            }
        };
        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _productos;
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public IActionResult GetProductoByID(int id)
        {
            if(id > _productos.Count || id < 0)
            {
                return BadRequest("ID incorrecto");
            }
            var pro =  _productos.Find(producto => producto.ID == id);
            if(pro == null)
            {
                return NotFound("No encontrado");
            }
            return Ok(pro);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public IActionResult SaveNewSong([FromBody] Producto newValue)
        {
            _productos.Add(newValue);
            return Ok();
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatedProduct(int id, [FromBody] Producto valueToUpdate)
        {
            var producto = _productos.Find(producto => producto.ID == id);

            producto.Nombre = valueToUpdate.Nombre;
            producto.Descripción = valueToUpdate.Descripción;
            producto.Cantidad = valueToUpdate.Cantidad;
            producto.Precio = valueToUpdate.Precio;

            return Ok();

        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productToRemove = _productos.Find(p => p.ID == id);
            _productos.Remove(productToRemove);

            return Ok();
        }
    }
}
