using DocumentLabel.API.Dtos;
using DocumentLabel.Domain;
using DocumentLabel.Domain.Interfaces;
using DocumentLabel.Domain.Shared;
using Inventory.API.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentLabel.API.Services
{
    public class LookupService
    {
        private IUnitOfWork _unitOfWork;

        public LookupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<List<LookupViewModel>>> Get(LookupTypeEnum type, LanguageEnum language)
        {
            var repository = _unitOfWork.AsyncRepository<Lookup>();
            var tags = await repository.Querable(x => x.Type == type).Select(x => new LookupViewModel
            {
                Id = x.Id,
                Text = x.Locales.FirstOrDefault(l => l.Language == language).Text
            }).ToListAsync();
           
            return new SuccessResponseDto<List<LookupViewModel>>
            {
                Data = tags
            };
        }
      


    }
}
