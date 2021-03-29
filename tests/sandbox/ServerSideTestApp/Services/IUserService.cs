using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.UserDto;

namespace ServerSideTestApp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserListDto>> GetUserList();

        Task<UserDetailDto> GetUserDetail();
    }
}