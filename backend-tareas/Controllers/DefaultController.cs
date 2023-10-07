using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET: api/<DefaultController>
        [HttpGet]
        public string Get()
        {
            return "aplicacion corriendo...";
        }
      
    }
}
