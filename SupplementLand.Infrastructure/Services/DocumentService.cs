using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Infrastructure.Services;

public class DocumentService:IDocumentService
{
    private readonly SupplementLandDb _context;
    public DocumentService(SupplementLandDb context)
    {
        _context = context;
    }

    public async Task<OperationResult> AddDocumentAsync(DocumentDto dto)
    {
        var doc = new Document
        {
            FileName = dto.FileName,
            ContentType = dto.ContentType,
            Data = dto.Data,
            FactoryId = dto.FactoryId,
            ProductId = dto.ProductId,
            IsDefault=dto.IsDefault,
        };

        _context.documents.Add(doc);
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Document added successfully" };
    }

    public async Task<OperationResult> DeleteDocument(Guid id)
    {
        var document=await _context.documents.FirstOrDefaultAsync(d=>d.Id==id);
        if (document==null)
        {
            return new OperationResult { Success = false, Message = "document not found" };
        }
        try
        {
            _context.documents.Remove(document);
            await _context.SaveChangesAsync();
            return new OperationResult() { Success = true, Message = "document deleted successfully" };
        }
        catch { return new OperationResult() { Success = false, Message = "An error occured" }; }
    }

    public async Task<DocumentDto?> GetDocumentAsync(Guid id)
    {
        var doc = await _context.documents.FindAsync(id);
        if (doc == null) return null;

        return new DocumentDto
        {
            Id = doc.Id,
            FileName = doc.FileName,
            ContentType = doc.ContentType,
            Data = doc.Data,
            FactoryId = doc.FactoryId,
            ProductId = doc.ProductId
        };
    }

   
}
