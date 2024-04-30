namespace web_api_csharp.Models.Repos
{
    interface ICompanyRepository
    {
        List<Company> Get();
        object GetById(int id);
        void Create(Company model);
        void Update(Company model);
        void Delete(int id);
    }
}
