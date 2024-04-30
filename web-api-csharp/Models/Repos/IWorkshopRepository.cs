namespace web_api_csharp.Models.Repos
{
    interface IWorkshopRepository
    {
        List<Workshop> Get();
        object GetById(int id);
        void Create(Workshop model);
        void Update(Workshop model);
        void Delete(int id);
    }
}
