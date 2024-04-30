using Microsoft.AspNetCore.Mvc;
using web_api_csharp.Models;
using web_api_csharp.Models.Repos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {

        private readonly FieldRepository _FieldRepository;

        public FieldController()
        {
            _FieldRepository = new FieldRepository();
        }


        // GET: api/Field
        [HttpGet]
        public IEnumerable<Field> Get()
        {
            return _FieldRepository.Get();
        }

        // GET: api/Field/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            object result = _FieldRepository.GetById(id);
            if (result != null)
                return result;
            return NotFound();
        }

        // POST: api/Field
        [HttpPost]
        public void Post([FromBody] Field model)
        {
            _FieldRepository.Create(model);
        }

        // PUT: api/Field/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Field model)
        {
            model.Id = id;
            _FieldRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _FieldRepository.Delete(id);
        }
    }
}
