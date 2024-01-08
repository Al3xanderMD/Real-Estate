namespace RealEstate.App.Operations.Common
{
	public class ResponseModel
	{
		public object Commercial { get; set; }
		public bool Success { get; set; }
		public string Message { get; set; }
		public List<string> ValidationErrors { get; set; }
	}
}
