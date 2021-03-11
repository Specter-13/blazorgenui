using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.StageDto;

namespace ServerSideTestApp.Services
{
    public interface IStageService
    {
        Task<IEnumerable<StageDetailDto>> GetStageList();

        Task<StageDetailDto> GetStageDetail();
    }
}