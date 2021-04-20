using FestivalProject.BL.Models.UserDto;

namespace FestivalProject.BL.Services
{
    public interface IUserAuthenticationService
    {
        UserDetailAuthenticateDto Authenticate(UserAuthenticateDto model);
    }
}
