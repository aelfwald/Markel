using Markel.Insurance.Application;
using Markel.Insurance.Domain;

namespace Markel.Insurance.Infrastructure
{
	/// <summary>
	/// Defines a  command that persists an updated.
	/// </summary>
	public class UpdateClaimCommand : IUpdateClaimCommand
	{
		/// <summary>
		/// Runs the command
		/// </summary>
		/// <param name="claim">The claim to be updated</param>
		public async Task Run(Claim claim)
		{
			//Nothing to do
			await Task.FromResult(0);
		}
	}
}
