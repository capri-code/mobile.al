namespace mobile.al.Models
{
    public class ApplicationUser
    {
        public string FullName { get; set; }
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
