using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.UserDto;

namespace ServerSideTestApp.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

        }
        public async Task<IEnumerable<UserListDto>> GetUserList()
        {
            return await httpClient.GetFromJsonAsync<UserListDto[]>("api/User");
        }

        public async Task<UserDetailDto> GetUserDetail()
        {
            return await httpClient.GetFromJsonAsync<UserDetailDto>("api/User/e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1");
        }
    }
}
