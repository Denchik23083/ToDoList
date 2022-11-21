using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Logic;

namespace ToDoList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListProblemController : ControllerBase
    {
        private readonly IListProblemService _service;

        public ListProblemController(IListProblemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listProblem = await _service.GetAll();

            return Ok(listProblem);
        }
    }
}
