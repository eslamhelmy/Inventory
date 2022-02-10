
using DocumentLabel.Domain.Base;

namespace DocumentLabel.Domain
{
    public class User: Entity<int>
    {
        public string Username { get; set; }
    }
}
