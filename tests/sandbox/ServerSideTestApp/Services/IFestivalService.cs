using System.Collections.Generic;
using System.Threading.Tasks;

using FestivalProject.BL.Models.FestivalDto;

namespace ServerSideTestApp.Services
{
    public interface IFestivalService
    {
        Task<IEnumerable<FestivalListDto>> GetFestivalList();

        Task<FestivalDetailDto> GetFestivalDetail();
    }
}
