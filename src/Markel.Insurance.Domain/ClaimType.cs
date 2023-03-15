namespace Markel.Insurance.Domain
{
	/// <summary>
	/// Claim type domain object
	/// </summary>
	public class ClaimType
	{
		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="id">The claim type id</param>
		/// <param name="name">The claim type name</param>
		public ClaimType(int id, string name)
		{
			Id = id;
			Name = name;
		}

		/// <summary>
		/// The Claim Type Identifier
		/// </summary>
		public int Id 
		{
			get; 
			private set; 
		}

		/// <summary>
		/// The Claim Type Name
		/// </summary>
		public string Name 
		{
			get; 
			private set; }
	}
}
