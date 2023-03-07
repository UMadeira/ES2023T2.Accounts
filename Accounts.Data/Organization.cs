namespace Accounts.Data
{
    public class Organization
    {
        public string Name { get; set; } = String.Empty;
        public List<User> Users { get; set; } = new List<User>();

    }
}