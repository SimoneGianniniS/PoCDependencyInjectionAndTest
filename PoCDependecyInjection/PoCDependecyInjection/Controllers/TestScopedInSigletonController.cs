using Microsoft.AspNetCore.Mvc;
using PoCDependecyInjection.BLL.Interface;

namespace PoCDependecyInjection.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestScopedInSigletonController : ControllerBase
    {
        private readonly ILogger<TestScopedInSigletonController> _logger;
        private readonly IPrintService _printService;
        public TestScopedInSigletonController(ILogger<TestScopedInSigletonController> logger, [FromKeyedServices("PrintSingl")] IPrintService printService)
        {
            _logger = logger;
            _printService = printService; //essendo registrato per primo prende comunque quello corretto corrispondente alla chiave, senza andare nell'ultimo registrato
        }

        [HttpGet]
        public string Get()
        {
            return _printService.PrintNames(null);
        }
    }
}
