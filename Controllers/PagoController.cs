using Microsoft.AspNetCore.Mvc;

namespace WebPagos.Controllers;

[ApiController]
[Route("[controller]")]
public class PagoController : ControllerBase
{
    public PagoController()
    {
        
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Pago exitoso");
    }

}
