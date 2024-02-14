using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPersonelSeasonalPaid.Application.PaidSystem.Dtos;

namespace WebPersonelSeasonalPaid.Application.PaidSystem
{
    public interface IPaidSystemService
    {
        Task<List<GetAllPersonelDto>> GetPersonList();
        Task<List<GetAllSeasonDto>> GetSeasonList();
        Task<List<GetPersonelBySeasonDto>> GetSeasonById(GetPersonelBySeasonDto request);
        Task<bool> AddPersonel(AddPersonelDto request);
        Task<bool> AddSeason(AddSeasonDto request);
        Task<bool> DeletePersonelById(Guid Id);
        Task<bool> DeleteSeasonById(Guid Id);

    }
}
