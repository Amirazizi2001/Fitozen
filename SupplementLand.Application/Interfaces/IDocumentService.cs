using SupplementLand.Application.Dtos;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Interfaces
{
    public interface IDocumentService
    {
        Task<OperationResult> AddDocumentAsync(DocumentDto dto);
        Task<DocumentDto?> GetDocumentAsync(Guid id);
       
    }
}
