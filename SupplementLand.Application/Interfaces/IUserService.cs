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
    public interface IUserService
    {
        Task<OperationResult> AddUser(UserDto userDto);
        Task<OperationResult> UpdateUser(UpdateDto updateDto);
        Task<OperationResult> DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<User> GetUserByMobile(string mobile);
        Task<User> GetUserByRefreshToken(string refreshToken);


        
        Task<UserProfileDto> GetUserProfile(int userId);
        Task<OperationResult> UpdateUserProfile(UserProfileDto dto);
       

        
        Task<DataResult<UserListDto>> GetAllUsers(UserFilter filter);
        Task<DataResult<PoListDto>> UserPortfolios(PortfolioFilter filter);
        Task<DataResult<ComListDto>> GetUserComments(UserCommentFilter filter);

    }
}
