using Microsoft.AspNetCore.Mvc;
using web_api_csharp.Helpers;
using web_api_csharp.Models;
using web_api_csharp.Models.Repos;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WellController : ControllerBase
    {
        private readonly WellRepository _WellRepository;

        public WellController()
        {
            _WellRepository = new WellRepository();
        }

        // GET: api/Well
        [HttpGet]
        public IEnumerable<Well> Get()
        {
            return _WellRepository.Get();
        }

        // GET: api/Well/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return _WellRepository.GetById(id);
        }

        // POST: api/Well
        [HttpPost]
        public void Post(WellRequest well)
        {
            _WellRepository.Create(well);
        }

        // PUT: api/Well/5
        [HttpPut("{id}")]
        public void Put(int id, WellRequest model)
        {
            model.id = id;
            _WellRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _WellRepository.Delete(id);
        }
    }
}
