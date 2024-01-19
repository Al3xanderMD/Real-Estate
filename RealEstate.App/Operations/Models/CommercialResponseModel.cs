﻿using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Operations.Common
{
	public class CommercialResponseModel
	{
		public CommercialFetchViewModel commercial { get; set; }
		public bool Success { get; set; }
		public string Message { get; set; }
		public List<string> ValidationErrors { get; set; }
	}
}