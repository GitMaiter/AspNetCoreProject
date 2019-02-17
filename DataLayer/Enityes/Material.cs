namespace DataLayer.Enityes
{
    public class Material : Page
    {
        public int Id { get; set; }
        public int DirectoryId { get; set; }
        public Directory Directory { get; set; }

    }
}
