using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Domain.Entities;
using SupplementLand.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Interfaces
{
    public interface IProductService
    {
        
        
        
        Task<DataResult<ProductListsDto>> GetProducts(ProductFilter productFilter);

        Task<OperationResult> AddProduct(ProductDto productDto);
        Task<OperationResult> UpdateProduct(PUpdateDto pUpdateDto);
        Task<OperationResult> DeleteProduct(int id);

        Task<DataResult<ComListDto>> GetProductComments(CommentFilter filter);
        

        // 🔹 ثبت نظر روی پیشنهاد ویژه
        
        Task<ProductDetailDto> GetProductDetail(int productId);
        
        Task<Product> GetProductById(int id);
        Task<OperationResult> AddProductVariant(ProductsVariantDto dto);
        Task<OperationResult> DeleteVariant(int id);
        Task<OperationResult> DeleteSupplementFacts(int id);
        Task<OperationResult> AddSupplementFact(SupplementFactsDto dto);
        Task<IEnumerable<NewProductListDto>> GetNewProductList();
        Task<IEnumerable<NewProductListDto>> GetBestSellers();


    }
}
