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
    public interface IFactoryService
    {
        
            Task<DataResult<Factory>> GetAllFactories(Filter filter);
            Task<DataResult<PListDto>> GetFactoryProducts(FactoryFilter filter);
            Task<Factory> GetFactoryById(int id);
            Task<OperationResult> AddFactory(FacDto facDto);
            Task<OperationResult> UpdateFactory(FUpdateDto fUpdateDto);
            Task<OperationResult> DeleteFactory(int id);
            Task<DataResult<FacListDto>> GetFactoriesList(Filter filter);   
            Task<DataResult<ProductListDto>> GetFactoryProductsList(FactoryFilter filter);
        Task<OperationResult> AddFactoryImage(FacImageDto dto);
        

    }
}
