using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly_Demo.Services;

namespace Polly_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private ITodoService _todoService;

        public RequestController(ITodoService todoService)

        {
            _todoService = todoService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _todoService.GetTodos();
            if(!response.IsSuccessStatusCode)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(response.Content.ReadAsStringAsync().Result);
        }
    }
}
