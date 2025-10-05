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
    public interface IPackageService
    {
        Task<OperationResult> AddPackage(PackageDto dto);
        Task<OperationResult> UpdatePackage(UPackageDto dto);
        Task<OperationResult> DeletePackage(int id);
        Task<Package> GetPackageById(int id);
        Task<DataResult<PackageListDto>> GetPackages(PackageFilter filter);
    }
}
