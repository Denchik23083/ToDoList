using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Db.Entities;
using ToDoList.Logic;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListProblemController : ControllerBase
    {
        private readonly IListProblemService _service;
        private readonly IMapper _mapper;

        public ListProblemController(IListProblemService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listProblem = await _service.GetAll();

            if (!listProblem.Any())
            {
                return NoContent();
            }

            var mapperListProblem = _mapper.Map<IEnumerable<ProblemModel>>(listProblem);

            return Ok(mapperListProblem);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProblemModel model)
        {
            var problem = _mapper.Map<Problem>(model);

            await _service.Add(problem);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Complete(ProblemModel model, int id)
        {
            var problem = _mapper.Map<Problem>(model);

            await _service.Update(problem, id);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveToArchive(int id)
        {
            await _service.RemoveToArchive(id);

            return NoContent();
        }
    }
}
