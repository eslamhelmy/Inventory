using DocumentLabel.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocumentLabel.API.Dtos
{
    public class AddDocumentRequestViewModel
    {
        //I made product id as nullable so i can enforce the frontend to pass, otherwise the formatter will add it with default value zero
        [Required]
        public string DocumentName { get; set; }
        public string DocumentVersion { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentCreationDate { get; set; }
        public string DocumentDescription { get; set; }
        public string OrganizationUnitCode { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentRequestStatusEnum StatusId { get; set; }
        public List<DocumentRequestTagViewModel> Tags { get; set; }
        public List<string> FileNames { get; set; }
    }

    public class DocumentRequestTagViewModel
    {
        public int Id { get; set; }
        public int TagId { get; set; }
    }
}
