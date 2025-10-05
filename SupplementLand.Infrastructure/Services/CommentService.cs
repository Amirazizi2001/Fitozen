using SupplementLand.Application.Dtos;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Infrastructure.Services;

public class CommentService : ICommentService
{
    private readonly SupplementLandDb _context;
    public CommentService(SupplementLandDb context)
    {
        _context = context;
    }


    public async Task<OperationResult> AddComment(CommentDto dto)
    {
        try
        {
            var comment = new Comment()
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                Content = dto.Content,
                CreateDate = DateTime.UtcNow,
                Rate = dto.Rate
                
            };

            await _context.comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Comment added successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult{Success=false,Message="Error adding comment"};
        }
    }

    public async Task<OperationResult> DeleteComment(int id)
    {
        var comment = await GetCommentById(id);
        if (comment == null)
            return new OperationResult { Success = false, Message = "Comment not found" };

        _context.comments.Remove(comment);
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Comment deleted successfully" };
    }

    public async Task<OperationResult> EditComment(ComUpdateDto dto)
    {
        var existingComment = await GetCommentById(dto.Id);
        if (existingComment == null)
            return new OperationResult { Success = false, Message = "Comment not found" };

        existingComment.Content = dto.Content;
        existingComment.Rate= dto.Rate;
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "comment updated successfully" };
    }

    public async Task<Comment> GetCommentById(int id)
    {
        return await _context.comments.FindAsync(id);
    }
}
