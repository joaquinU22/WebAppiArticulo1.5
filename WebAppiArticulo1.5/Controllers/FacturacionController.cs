using Facturacion1._5.Domain;
using FacturacionBackk.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAppiArticulo1._5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        private IFacturaService service;
        
        public FacturacionController() 
        {
            service = new FacturaService();
        }

        // GET: api/<FormaPagos>
        [HttpGet("FormaPagos")]
        public IActionResult Get()
        {
            return Ok(service.ObtenerFormaPagos());
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = service.BorrarFactura(id);
            return Ok(result);
        }
        [HttpPost("Factura")]
        public IActionResult Post([FromBody]Factura factura)
        {
            try
            {
                if (factura == null)
                {
                    return BadRequest("Se esperaba una factura completa");
                }
                if (service.AgregarFactura(factura))
                    return Ok("Factura registrada con exito!");
                else
                    return StatusCode(500, "No se pudo registrar la factura!");
            }
            catch (Exception)
            {

                return StatusCode(500,"Error interno, ontente nuevamente");
            }
        }
        // GET: api/<ObtenerFactura>
        [HttpGet("Factura")]
        public IActionResult GetObtener()
        {
            return Ok(service.ObtenerFactura());
        }

    }
}
