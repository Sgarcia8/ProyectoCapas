namespace Models.Entities
{
    public class Theater
    {

        public int TheaterId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public List<Film>? Films { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
