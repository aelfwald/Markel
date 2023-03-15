namespace Markel.Insurance.Application
{
	public class UpdateClaimDispatcher
	{

		/// <summary>
		/// The claim updated.
		/// Called when the claim is successfully updated
		/// </summary>
		public event EventHandler? Updated;


		/// <summary>
		/// The claim not found event.
		/// Called when the claim attemting to update was not found.
		/// </summary>
		public event EventHandler? ClaimNotFound;

		/// <summary>
		/// The validation failed event
		/// Called when the validation failed when attempting to update a claim.
		/// </summary>
		public event EventHandler<string>? ValidationFailed;

		/// <summary>
		/// Raises the updated event.
		/// </summary>
		public void OnUpdated()
		{
			this.Updated?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the claim not found event.
		/// </summary>
		public void OnClaimNotFound()
		{
			this.ClaimNotFound?.Invoke(this, EventArgs.Empty);
		}


		/// <summary>
		/// Raises the validation failed event.
		/// </summary>
		public void OnValidationFailed(string validationMessage)
		{
			this.ValidationFailed?.Invoke(this, validationMessage);
		}

	}
}
