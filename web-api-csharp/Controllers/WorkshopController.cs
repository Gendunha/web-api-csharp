using Microsoft.AspNetCore.Mvc;
using web_api_csharp.Models;
using web_api_csharp.Models.Repos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {

        private readonly WorkshopRepository _WorkshopRepository;

        public WorkshopController()
        {
            _WorkshopRepository = new WorkshopRepository();
        }

        // GET: api/Workshop
        [HttpGet]
        public IEnumerable<Workshop> Get()
        {
            return _WorkshopRepository.Get();
        }

        // GET: api/Workshop/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            object result = _WorkshopRepository.GetById(id);
            if (result != null)
                return result;
            return NotFound();
        }

        // POST: api/Workshop
        [HttpPost]
        public void Post([FromBody] Workshop model)
        {
            _WorkshopRepository.Create(model);
        }

        // PUT: api/Workshop/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Workshop model)
        {
            model.Id = id;
            _WorkshopRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _WorkshopRepository.Delete(id);
        }
    }
}
