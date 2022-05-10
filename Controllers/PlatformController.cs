using Microsoft.AspNetCore.Mvc;
using RedisAPI.Data;

namespace RedisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;

        public PlatformController(IPlatformRepo repo)
        {
            _repo = repo; 
        }
    }


    
}