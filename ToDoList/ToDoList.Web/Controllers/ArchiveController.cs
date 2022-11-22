using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Logic;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveController : ControllerBase
    {
        private readonly IListProblemService _service;
        private readonly IMapper _mapper;

        public ArchiveController(IListProblemService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetArchive()
        {
            var archiveProblem = _service.GetArchive();

            if (!archiveProblem.Any())
            {
                return NoContent();
            }

            var mapperArchiveProblem = _mapper.Map<IEnumerable<ProblemModel>>(archiveProblem);

            return Ok(mapperArchiveProblem);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromArchive(int id)
        {
            await _service.RemoveFromArchive(id);

            return NoContent();
        }
    }
}
