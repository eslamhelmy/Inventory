using DocumentLabel.Domain.Base;
using DocumentLabel.Domain.Shared;

namespace DocumentLabel.Domain
{
    public class DocumentRequestTag: Entity<int>
    {
        public int DocumentRequestId { get; set; }
        public virtual DocumentRequest DocumentRequest { get; set; }

        public int TagId { get; set; }
        public virtual Lookup Tag { get; set; }
    }
}