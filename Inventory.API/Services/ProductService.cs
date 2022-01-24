using Inventory.API.Dtos;
using Inventory.Domain;
using Inventory.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ResponseDto<bool>> SellProduct(SellProductDto productDto)
        {
            var repository = _unitOfWork.AsyncRepository<Product>();
            var product = await repository.GetAsync(x => x.Id == productDto.ProductId.Value);
            var isSold = product?.Sell();
            if (!isSold.HasValue || isSold.Value == false)
            {
                return new FailureResponseDto<bool>
                {
                    Message = "the product is not in stock",
                    Data = false
                };
            }
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponseDto<bool>
            {
                Data = true
            };
        }

        public async Task<ResponseDto<bool>> ChangeStatus(ChangeProductStatusDto changeStatusDto)
        {
            var repository = _unitOfWork.AsyncRepository<Product>();
            var product = await repository.GetAsync(x => x.Id == changeStatusDto.ProductId.Value);
            product.ChangeStatus(changeStatusDto.Status.Value);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponseDto<bool>
            {
                Data = true
            };
        }

        public async Task<ResponseDto<ICollection<InventoryDto>>> GetInventory()
        {
            var repository = _unitOfWork.AsyncRepository<Product>();
            
            // I used querable to not load all products into memory
            var inventoryDto =await repository.Querable().GroupBy(x => x.Status)
                .Select(x => new InventoryDto
                {
                    Status = x.Key,
                    StatusName = x.Key == ProductStatus.Sold? "Sold": x.Key == ProductStatus.InStock? "In Stock": "Damaged",
                    Count = x.Count()
                }).ToListAsync();

            return new SuccessResponseDto<ICollection<InventoryDto>>
            {
                Data = inventoryDto
            };
        }


    }
}
