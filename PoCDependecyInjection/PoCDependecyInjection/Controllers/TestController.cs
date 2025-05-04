using Microsoft.AspNetCore.Mvc;
using PoCDependecyInjection.BLL.Interface;
using System.Text;

namespace PoCDependecyInjection.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {    

        private readonly ILogger<TestController> _logger;
        private readonly IPrintService _printService;
        private IBookService _bookService;

        public TestController(ILogger<TestController> logger, IPrintService printService, IBookService bookService)
        {
            _logger = logger;
            _printService = printService;
            _bookService = bookService;
        }

        [HttpGet]
        [Route("SayHallo/{yourName}")]
        public string SayHallo(string yourName)
        {
            return _printService.PrintNames(yourName);
        }

        [HttpGet]
        [Route("GetYourBooks/{yourName}")]
        public string GetYourBooks(string yourName)
        {
            var inputs = new List<string>
            {
                _printService.PrintNames(yourName)
            };
            inputs.AddRange(_bookService.GetBook());
            return _printService.ComposeStringWithStringBuilder(inputs);
        }
    }
}
