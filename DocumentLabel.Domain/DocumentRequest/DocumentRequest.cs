using DocumentLabel.Domain.Base;
using DocumentLabel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLabel.Domain
{
    public partial class DocumentRequest: AuditableEntity<int>
    {
        public string DocumentName { get; set; }
        public string DocumentVesrion { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentCreationDate { get; set; }
        public string DocumentDescription { get; set; }
        public string OrganizationUnitCode { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual Lookup DocumentType { get; set; }
        public DocumentRequestStatusEnum StatusId { get; set; }
        public ICollection<DocumentRequestTag> DocumentRequestTags { get; set; }
        public ICollection<DocumentRequestFile> Files { get; set; }


    }
}
