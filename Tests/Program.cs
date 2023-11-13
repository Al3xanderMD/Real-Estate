// See https://aka.ms/new-console-template for more information
using Infrastructure;
using Infrastructure.Repositories;
using RealEstate.Domain.Entities;

Console.WriteLine("Hello, World!");

Guid randomUserGuid = Guid.NewGuid();
Guid randomAddressGuid = Guid.NewGuid();

/*Agent agent = Agent.Create(randomAddressGuid, randomUserGuid, "New Agent", "837982742").Value;
RealEstateContext context = new();
AgentRepository repository = new(context);
await repository.AddAsync(agent);
var result = await repository.FindByIdAsync(agent.AddressId);
Console.WriteLine(result.Value.AddressId);*/