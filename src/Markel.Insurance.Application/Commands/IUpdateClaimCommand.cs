using Markel.Insurance.Domain;

namespace Markel.Insurance.Application
{
	/// <summary>
	/// Defines a persistance command that updates a claim.
	/// </summary>
	public interface IUpdateClaimCommand
	{
		/// <summary>
		/// Runs the command
		/// </summary>
		/// <param name="claim">The claim to be updated</param>
		Task Run(Claim claim);
	}
}
