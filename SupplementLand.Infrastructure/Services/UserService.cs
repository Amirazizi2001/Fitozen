using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;

using System.Linq;
using System.Threading.Tasks;

namespace SupplementLand.Infrastructure.Services;

public class UserService :IUserService
{
    private readonly SupplementLandDb _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(SupplementLandDb context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    
    public async Task<OperationResult> AddUser(UserDto userDto)
    {
        if (await _context.users.AnyAsync(u => u.Mobile == userDto.Mobile))
            return new OperationResult { Success = false, Message = "Mobile already exists" };

        var user = new User
        {
            FullName = userDto.FullName,
            Mobile = userDto.Mobile,
            Email = userDto.Email
        };

        user.Password = _passwordHasher.HashPassword(user, userDto.Password);

        await _context.users.AddAsync(user);
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "User registered successfully" };
    }

    public async Task<User> GetUserById(int id)
        => await _context.users.FindAsync(id);

    public async Task<User> GetUserByMobile(string mobile)
        => await _context.users.FirstOrDefaultAsync(u => u.Mobile == mobile);

    public async Task<User> GetUserByRefreshToken(string refreshToken)
        => await _context.users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

    public async Task<OperationResult> UpdateUser(UpdateDto updateDto)
    {
        var user = await GetUserById(updateDto.Id);
        if (user == null)
            return new OperationResult { Success = false, Message = "User not found" };

        user.FullName = updateDto.FullName;
        user.Mobile = updateDto.Mobile;
        user.Email = updateDto.Email;
        user.Password =updateDto.Password;
        

        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "User updated successfully" };
    }

    public async Task<OperationResult> DeleteUser(int id)
    {
        var user = await GetUserById(id);
        if (user == null)
            return new OperationResult { Success = false, Message = "User not found" };

        _context.users.Remove(user);
        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "User deleted successfully" };
    }
    

    
    public async Task<UserProfileDto> GetUserProfile(int userId)
    {
        var user = await _context.users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return null;

        return new UserProfileDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Phone = user.Mobile,
            BirthDate = user.BirthDate
        };
    }

    public async Task<OperationResult> UpdateUserProfile(UserProfileDto dto)
    {
        var user = await _context.users.FindAsync(dto.Id);
        if (user == null)
            return new OperationResult { Success = false, Message = "User not found" };

        user.FullName = dto.FullName;
        user.Email = dto.Email;
        user.Mobile = dto.Phone;
        user.BirthDate = dto.BirthDate;
        

        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Profile updated successfully" };
    }
   

    
    public async Task<DataResult<UserListDto>> GetAllUsers(UserFilter filter)
    {
        IQueryable<User> query = _context.users.AsQueryable();
        if (!string.IsNullOrEmpty(filter.FullName))
            query = query.Where(u => u.FullName.Contains(filter.FullName));

        if (!string.IsNullOrEmpty(filter.Mobile))
            query = query.Where(u => u.Mobile == filter.Mobile);

        if (!string.IsNullOrEmpty(filter.Email))
            query = query.Where(u => u.Email == filter.Email);

        var totalCount = await query.CountAsync();
        var items = await query
            .OrderByDescending(u => u.Id)
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(u => new UserListDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Mobile = u.Mobile,
                Email = u.Email
            })
            .ToListAsync();

        return new DataResult<UserListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<DataResult<PoListDto>> UserPortfolios(PortfolioFilter filter)
    {
        IQueryable<Portfolio> query = _context.portfolios.AsQueryable();

        if (!string.IsNullOrEmpty(filter.FullName))
            query = query.Where(p => p.User.FullName.Contains(filter.FullName));

        if (!string.IsNullOrEmpty(filter.Status))
            query = query.Where(p => p.status.ToString() == filter.Status);

        var totalCount = await query.CountAsync();
        var items = await query
            .OrderByDescending(p => p.Id)
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(p => new PoListDto
            {
                Id = p.Id,
                CreateDate = p.CreateDate,
                DeleteDate = p.DeleteDate,
                FullName = p.User.FullName,
                Mobile = p.User.Mobile,
                status = p.status.ToString(),
                UserId = p.UserId
            })
            .ToListAsync();

        return new DataResult<PoListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<DataResult<ComListDto>> GetUserComments(UserCommentFilter filter)
    {
        IQueryable<Comment> query = _context.comments.AsQueryable();

        if (!string.IsNullOrEmpty(filter.FullName))
            query = query.Where(c => c.User.FullName.Contains(filter.FullName));

        var totalCount = await query.CountAsync();
        var items = await query
            .OrderByDescending(c => c.Id)
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(c => new ComListDto
            {
                FullName = c.User.FullName,
                Content = c.Content,
               
                CreateDate = c.CreateDate
            })
            .ToListAsync();

        return new DataResult<ComListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
    
}
