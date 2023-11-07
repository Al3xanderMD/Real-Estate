using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Agent
    {
        public string AgentName { get; private set; }
        public string? Logolink { get; private set; }
        public string Phone { get; private set; }
        public Address IdAddress { get; private set; }
        public string? Url { get; private set; }
        public RegAuth RegAuth { get; private set; }

        private Agent(string email, string password, string urlAddress, string addressName, string agentName, string phone)
        {
            RegAuth = new RegAuth
            {
                Email = email,
                Password = password,
                Role = "Agent"
            };
            IdAddress = new Address
            {
                Url = urlAddress,
                AddressName = addressName
            };
            AgentName = agentName;
            Phone = phone;
        }

        static public Result<Agent> Create(string email, string password, string urlAdress, string adressName, string agentName, string phone)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result<Agent>.Failure("Email is required");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                return Result<Agent>.Failure("Password is required");
            }
            if (string.IsNullOrWhiteSpace(urlAdress))
            {
                return Result<Agent>.Failure("Url adress is required");
            }
            if (string.IsNullOrWhiteSpace(adressName))
            {
                return Result<Agent>.Failure("Adress name is required");
            }
            if (string.IsNullOrWhiteSpace(agentName))
            {
                return Result<Agent>.Failure("Agent name is required");
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                return Result<Agent>.Failure("Phone is required");
            }

            var agent = new Agent(email, password, urlAdress, adressName, agentName, phone);

            return Result<Agent>.Success(agent);
        }

        public void AttachLogo(string logolink)
        {
            if (!string.IsNullOrWhiteSpace(logolink)) { 
                Logolink = logolink;
            }
        }
        public void AttachPhone(string phone)
        {
            if(phone.Length == 10)
            {
                Phone = phone;
            }
        }

    }
}
