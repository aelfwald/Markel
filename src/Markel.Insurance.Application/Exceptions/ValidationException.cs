namespace Markel.Insurance.Application
{
	public class ValidationException : Exception
	{
		public ValidationException(string message) : base(message)
		{
		}
	}
}
