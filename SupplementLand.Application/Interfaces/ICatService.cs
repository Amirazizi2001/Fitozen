using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Interfaces
{
    public interface ICatService
    {
        Task<IEnumerable<CategoryListDto>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<DataResult<PListDto>> GetCatProducts(CategoryFilter filter);
        Task<OperationResult> AddCategory(CatDto catDto);
        Task<OperationResult> UpdateCategory(CUpdateDto cUpdateDto);
        Task<OperationResult> DeleteCategory(int id);
        Task<DataResult<CatListDto>> GetChildrenCategories(CategoryFilter filter);
    }
}
