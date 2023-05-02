using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using videoPortal.Services;

namespace videoPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;
        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        
    }
}
