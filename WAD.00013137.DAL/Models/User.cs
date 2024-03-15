namespace WAD._00013137.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		// Navigation property for the related issues
		public ICollection<Issue> Issues { get; set; }
	}
}
