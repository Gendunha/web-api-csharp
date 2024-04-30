namespace web_api_csharp.Models
{
    public class Well
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Company Company { get; set; }
        public Workshop Workshop { get; set; }
        public Field Field { get; set; }
    }
}
