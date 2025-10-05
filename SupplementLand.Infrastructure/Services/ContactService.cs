using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private readonly SupplementLandDb _context;

        public ContactService(SupplementLandDb context)
        {
            _context = context;
        }

        public async Task<OperationResult> AddMessage(ContactDto contactDto)
        {
            var contact = new Contact
            {
                Name = contactDto.Name,
                Email = contactDto.Email,
                Subject = contactDto.Subject,
                Message = contactDto.Message,
                CreateDate = DateTime.UtcNow
            };

            try
            {
                await _context.contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
                return new OperationResult { Success = true, Message = "added successfully" };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = "an error occurd" };
            }
        }

        public async Task<OperationResult> DeleteMessage(int id)
        {
            var contact = await _context.contacts.FindAsync(id);
            if (contact == null)
                return new OperationResult { Success = false, Message = "doesn't exist" };


            _context.contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "Message deleted successfully" };
        }

        public async Task<DataResult<ContactListDto>> GetAllMessages(ContactFilter filter)
        {
            IQueryable<Contact> query = _context.contacts.AsQueryable();

            if (filter.Name != null)
                query = query.Where(c => c.Name==filter.Name);

            if (filter.Email != null)
                query = query.Where(c => c.Email == filter.Email);

            if (filter.Subject != null)
                query = query.Where(c => c.Subject.Contains(filter.Subject));

            var totalCount = await query.CountAsync();
            var items = await query.Select(c => new ContactListDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Subject = c.Subject,
                Message = c.Message,
                CreateDate = c.CreateDate,
                Reply=c.Reply
            }).Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize).ToListAsync();




            return new DataResult<ContactListDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }

        public async Task<Contact> GetMessageById(int id)
        {
            return await _context.contacts.FindAsync(id);
        }
        public async Task<OperationResult> ReplyMessage(ReplyDto replyDto)
        {
            var contact = await _context.contacts.FindAsync(replyDto.MessageId);
            if (contact == null)
                return new OperationResult { Success=false,Message = "Message not found" };

            if (contact.Reply != null)
                return new OperationResult { Success = false, Message = "this message is already replied" };

            contact.Reply = replyDto.Reply;
            contact.ReplyDate = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return new OperationResult { Success=true,Message="Reply sent successfully"};
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = "Error while sending reply" };
            }
        }
    }
}
