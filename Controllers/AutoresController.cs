using Microsoft.AspNetCore.Mvc;

namespace WebPagos;

[ApiController]
[Route("api/autores")]
public class AutoresController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public AutoresController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public ActionResult<List<Autor>> Get()
    {
        return new List<Autor>()
        {
            new Autor() { Id = 1 , Nombre = "Bryan"},
            new Autor() { Id = 2 , Nombre = "Gabriel"},
        };
    }

    [HttpGet("secret")]
    public ActionResult GetSecret()
    {
        var moviesApiKey = _configuration["Movies:ServiceApiKey"];
        return Ok(moviesApiKey);
    }

}
