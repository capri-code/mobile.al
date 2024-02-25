namespace mobile.al.ViewModels
{
    public class UserDetailViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
		public string? FullName { get; internal set; }
        public string ProfileImageUrl { get; set; }
    }
}
