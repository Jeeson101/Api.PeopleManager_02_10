namespace Vives.Services.model
{
	public class ServiceResult
	{
		public IList<ServiceMessage> Messages { get; set; } = new List<ServiceMessage>();

		public bool IsSucces => Messages.All(m => m.Type != MessageType.Error);
	}
}
