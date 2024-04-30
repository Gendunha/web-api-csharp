namespace web_api_csharp.Models.Repos
{
    interface IFieldRepository
    {
        List<Field> Get();
        object GetById(int id);
        void Create(Field model);
        void Update(Field model);
        void Delete(int id);
    }
}
