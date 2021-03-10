using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FestivalProject.BL.Models.FestivalDto;

namespace ServerSideTestApp.Services
{
    public class FestivalService: IFestivalService
    {
        private readonly HttpClient httpClient;
        public FestivalService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<FestivalListDto>> GetFestivalList()
        {
            return await httpClient.GetFromJsonAsync<FestivalListDto[]>("api/Festival");
        }

        public async Task<FestivalDetailDto> GetFestivalDetail()
        {
            return await httpClient.GetFromJsonAsync<FestivalDetailDto>("api/Festival/30d09c0f-f6aa-442c-9d87-2869faf175f4");
        }
    }
}
