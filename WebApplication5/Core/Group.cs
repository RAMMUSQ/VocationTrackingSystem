namespace Core.Entities
{
    public class UserGroups 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }
    }
}