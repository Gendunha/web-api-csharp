using web_api_csharp.Helpers;

namespace web_api_csharp.Models.Repos
{
    interface IWellRepository
    {
        List<Well> Get();
        object GetById(int id);
        void Create(WellRequest model);
        void Update(WellRequest model);
        void Delete(int id);
    }
}
