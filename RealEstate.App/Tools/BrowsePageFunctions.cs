﻿using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using RealEstate.App.Operations.Create.Models;

namespace RealEstate.App.Tools
{

    public class BrowsePageFunctions
    {
        public async Task deleteBrowseData(ISessionStorageService session) {
            List<string> keys = ["noLoad", "start_count", "end_count", "posts"];
            await session.RemoveItemsAsync(keys);
        }
    }
}