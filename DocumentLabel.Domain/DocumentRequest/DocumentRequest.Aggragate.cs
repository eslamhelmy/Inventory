using DocumentLabel.Domain.Base;
using DocumentLabel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLabel.Domain
{
    public partial class DocumentRequest : AuditableEntity<int>
    {

        public DocumentRequest WithDocumentName(string name)
        {
            this.DocumentName = name;
            return this;
        }

        public DocumentRequest WithDocumentVersion(string version)
        {
            this.DocumentVesrion = version;
            return this;
        }

        public DocumentRequest WithDocumentDescription(string desc)
        {
            this.DocumentDescription = desc;
            return this;
        }

        public DocumentRequest WithDocumentNumber(string number)
        {
            this.DocumentNumber = number;
            return this;
        }

        public DocumentRequest WithDocumentCreationDate(string creationDate)
        {
            this.DocumentCreationDate = creationDate;
            return this;
        }

        public DocumentRequest WithOrganizationUnitCode(string code)
        {
            this.OrganizationUnitCode = code;
            return this;
        }

        public DocumentRequest WithDocumentType(int documentTypeId)
        {
            this.DocumentTypeId = documentTypeId;
            return this;
        }

        public DocumentRequest WithStatus(DocumentRequestStatusEnum status)
        {
            this.StatusId = status;
            return this;
        }

        public DocumentRequest WithTags(DocumentRequestTag[] tags)
        {
            this.DocumentRequestTags = tags;
            return this;
        }

        public DocumentRequest WithFiles(DocumentRequestFile[] files)
        {
            this.Files = files;
            return this;
        }

    }
}
