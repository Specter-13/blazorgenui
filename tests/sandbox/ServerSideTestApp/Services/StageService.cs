using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.StageDto;

namespace ServerSideTestApp.Services
{
    public class StageService : IStageService

    {

        private readonly HttpClient httpClient;
        public StageService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<StageDetailDto>> GetStageList()
        {
            return await httpClient.GetFromJsonAsync<StageDetailDto[]>("api/Stage");
        }

        public async Task<StageDetailDto> GetStageDetail()
        {
            return await httpClient.GetFromJsonAsync<StageDetailDto>("api/Stage/f9adad79-fd79-469d-8dda-53400fc572bd");
        }
    }
}