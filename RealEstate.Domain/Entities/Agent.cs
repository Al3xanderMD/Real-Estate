using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Agent : AuditableEntity
    {
        public Guid AgentId { get; private set; }
        public string AgentName { get; private set; }
        public string? Logolink { get; private set; }
        public string Phone { get; private set; }
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; } = null!;
        public string? Url { get; private set; }

        private Agent(Guid addressId, string agentName, string phone)
        {
            AgentId = Guid.NewGuid();
            AddressId = addressId;
            AgentName = agentName;
            Phone = phone;
        }


        private Agent(Guid addressId, Address address, string agentName, string phone) : this(addressId, agentName, phone)
        {
            Address = address;
        }



        static public Result<Agent> Create(Guid addressId, string agentName, string phone)
        {
            if (string.IsNullOrWhiteSpace(agentName))
            {
                return Result<Agent>.Failure("Agent name is required");
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                return Result<Agent>.Failure("Phone is required");
            }

            var agent = new Agent(addressId, agentName, phone);

            return Result<Agent>.Success(agent);
        }

        public void AttachLogo(string logolink)
        {
            if (!string.IsNullOrWhiteSpace(logolink)) { 
                Logolink = logolink;
            }
        }
        public void AttachUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                Url = url;
            }
        }
    }
}
