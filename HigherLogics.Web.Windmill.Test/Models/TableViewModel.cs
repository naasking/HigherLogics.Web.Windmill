using HigherLogics.Web.Chartjs;
using System.Data;

namespace HigherLogics.Web.Windmill.Test.Models
{
    public class TableViewModel : GlobalViewModel
    {
        public TableViewModel(IEnumerable<Client> users) : base("Tables")
        {
            Users = users;
        }
        public IEnumerable<Client> Users { get; set; }

        public string GetColour(ClientStatus status)
        {
            string colour;
            switch (status)
            {
                case ClientStatus.Approved:
                    colour = "green";
                    break;
                case ClientStatus.Denied:
                    colour = "red";
                    break;
                case ClientStatus.Pending:
                    colour = "orange";
                    break;
                case ClientStatus.Expired:
                    colour = "gray";
                    break;
                default:
                    throw new NotSupportedException($"Unrecognized user status: {status}");
            }
            return $"text-{colour}-700 bg-{colour}-100 dark:bg-{colour}-700 dark:text-{colour}-100";
        }
    }

    public enum ClientStatus
    {
        Denied,
        Approved,
        Pending,
        Expired,
    }

    public class Client
    {
        public Client(string name, string role, decimal amount, ClientStatus status, DateTime date, string avatarUrl)
        {
            Name = name;
            Role = role;
            Amount = amount;
            AvatarUrl = avatarUrl;
            Status = status;
            Date = date;
        }
        public string Name { get; set; }
        public string Role { get; set; }
        public decimal Amount { get; set; }
        public string AvatarUrl { get; set; }
        public ClientStatus Status { get; set; }
        public DateTime Date { get; set; }
    }
}
