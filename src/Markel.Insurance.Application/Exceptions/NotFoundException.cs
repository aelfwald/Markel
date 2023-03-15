namespace Markel.Insurance.Application
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string message) : base(message)
		{
		}
	}
}
