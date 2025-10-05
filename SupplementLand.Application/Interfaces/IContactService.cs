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
    public interface IContactService
    {
        Task<OperationResult> AddMessage(ContactDto contactDto);
        Task<OperationResult> DeleteMessage(int id);
        Task<Contact> GetMessageById(int id);
        Task<DataResult<ContactListDto>> GetAllMessages(ContactFilter filter);
        Task<OperationResult> ReplyMessage(ReplyDto replyDto);
    }
}
