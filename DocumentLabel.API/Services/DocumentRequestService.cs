using DocumentLabel.API.Dtos;
using DocumentLabel.Domain;
using DocumentLabel.Domain.Interfaces;
using Inventory.API.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentLabel.API.Services
{
    public class DocumentRequestService
    {
        private IUnitOfWork _unitOfWork;

        public DocumentRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<bool>> AddDocumentRequest(AddDocumentRequestViewModel viewModel)
        {
            var repository = _unitOfWork.AsyncRepository<DocumentRequest>();
            var documentRequest = new DocumentRequest().WithDocumentName(viewModel.DocumentName)
                                                       .WithDocumentVersion(viewModel.DocumentVersion)
                                                       .WithDocumentNumber(viewModel.DocumentNumber)
                                                       .WithDocumentCreationDate(viewModel.DocumentCreationDate)
                                                       .WithDocumentDescription(viewModel.DocumentDescription)
                                                       .WithOrganizationUnitCode(viewModel.OrganizationUnitCode)
                                                       .WithTags(viewModel.Tags.Select(x => new DocumentRequestTag { TagId = x.TagId }).ToArray())
                                                       .WithFiles(viewModel.FileNames.Select(x => new DocumentRequestFile { FileName = x }).ToArray())
                                                       .WithDocumentType(viewModel.DocumentTypeId)
                                                       .WithStatus(viewModel.StatusId);

            await repository.AddAsync(documentRequest);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponseDto<bool>
            {
                Data = true
            };
        }
      


    }
}
