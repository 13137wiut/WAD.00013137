namespace WAD._00013137.Models
{
	public class Issue
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsResolved { get; set; }

		// Foreign key and navigation property
		public int UserId { get; set; }
		public User User { get; set; }
	}
}
