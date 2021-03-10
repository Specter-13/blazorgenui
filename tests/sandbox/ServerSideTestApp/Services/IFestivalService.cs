using System;
using System.Collections.Generic;
using System.Linq;
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
