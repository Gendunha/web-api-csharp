using Microsoft.AspNetCore.Mvc;
using web_api_csharp.Models;
using web_api_csharp.Models.Repos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly CompanyRepository _CompanyRepository;

        //public CompanyController()
        public CompanyController()
        {
            _CompanyRepository = new CompanyRepository();
        }

        // GET: api/Company
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _CompanyRepository.Get();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            object result = _CompanyRepository.GetById(id);
            if (result != null)
                return result;
            return NotFound();
        }

        // POST: api/Company
        [HttpPost]
        public void Post([FromBody] Company model)
        {
            _CompanyRepository.Create(model);

        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Company model)
        {
            model.Id = id;
            _CompanyRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _CompanyRepository.Delete(id);
        }
    }
}
