using SupplementLand.Application.Dtos;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Interfaces
{
    public interface ICommentService
    {
        Task<OperationResult> AddComment(CommentDto dto);
        Task<OperationResult> EditComment(ComUpdateDto dto);
        Task<OperationResult> DeleteComment(int id);
        Task<Comment> GetCommentById(int id);
    }
}
