using Inventory.API.Dtos;
using Inventory.Domain;
using Inventory.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Services
{
    public class ProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> SellProduct(SellProductDto productDto)
        {
            var repository = _unitOfWork.AsyncRepository<Product>();
            var product = await repository.GetAsync(x => x.Id == productDto.ProductId);
            var isSold = product.Sell();
            if (!isSold)
            {
                return new FailureResponse<bool>
                {
                    Message = "the product is not in stock",
                    Data = false
                };
            }
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<bool>
            {
                Data = true
            };
        }

        public async Task<Response<bool>> ChangeStatus(ChangeProductStatusDto changeStatusDto)
        {
            var repository = _unitOfWork.AsyncRepository<Product>();
            var product = await repository.GetAsync(x => x.Id == changeStatusDto.ProductId);
            product.ChangeStatus(changeStatusDto.Status);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse<bool>
            {
                Data = true
            };
        }

        public ICollection<StockInfoDto> GetSalesInfo()
        {
            var repository = _unitOfWork.AsyncRepository<Product>();
            // I used querable to not load all products into memory
            var stockdto = repository.QuerableAsync().GroupBy(x => x.Status)
                .Select(x => new StockInfoDto
                {
                    Status = x.Key,
                    Count = x.Count()
                }).ToList();

            return stockdto;
        }


    }
}
