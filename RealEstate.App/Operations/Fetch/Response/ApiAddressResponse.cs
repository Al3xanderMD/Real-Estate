namespace RealEstate.App.Operations.Fetch.Response
{
	public class ApiAddressResponse
	{
		public AddressResponseViewModel address { get; set; }
		public bool success { get; set; }
		public string message { get; set; }
		public object validationErrors { get; set; }
	}
}
