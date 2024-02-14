using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebPersonelSeasonalPaid.Application.PaidSystem.Dtos;
using WebPersonelSeasonalPaid.Domain;
using WebPersonelSeasonalPaid.Persistence;

namespace WebPersonelSeasonalPaid.Application.PaidSystem
{
    public class PaidSystemService : IPaidSystemService
    {
        private readonly MainDbContext _dbContext;

        public PaidSystemService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddSeason(AddSeasonDto request)
        {
            if (request != null)
            {
                _dbContext.Seasons.Add(new Domain.Season
                {
                    SeasonName = request.SeasonName,
                    SeasonStartDate = request.SeasonStartDate,
                    SeasonEndDate = request.SeasonEndDate,
                }
                );
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }
            return false;

        }
        public async Task<bool> AddPersonel(AddPersonelDto request)
        {
            if (request != null)
            {
                var newPersonel = new Domain.Personel
                {
                    TC = request.TC,
                    StartDate = request.StartDate,
                    Name = request.Name,
                    Surname = request.Surname,
                    SeasonName = string.Empty,
                    ExistingSeason = new List<PersonelSeason>()
                };

                var existingSeason = _dbContext.Seasons.FirstOrDefault(f => f.SeasonStartDate < request.StartDate && f.SeasonEndDate > request.StartDate);

                if (existingSeason != null)
                {
                    var newPersonelSeason = new PersonelSeason
                    {
                        SeasonId = existingSeason.SeasonId,
                        Salary = request.Salary,
                        Prim = request.Prim
                    };

                    newPersonel.ExistingSeason.Add(newPersonelSeason);
                }

                _dbContext.Personels.Add(newPersonel);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> DeletePersonelById(Guid Id)
        {
            var Personel = _dbContext.Personels.FirstOrDefault(f => f.PersonelId == Id);
            if (Personel == null)
            {
                return false;
            }
            _dbContext.Personels.Remove(Personel);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
        public async Task<bool> DeleteSeasonById(Guid Id)
        {
            var Season = _dbContext.Seasons.FirstOrDefault(f => f.SeasonId == Id);
            if (Season == null)
            {
                return false;
            }
            _dbContext.Seasons.Remove(Season);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<List<GetAllPersonelDto>> GetPersonList()
        {
            var personelList = await _dbContext.Personels
                .Include(f => f.ExistingSeason)
                .ThenInclude(f => f.Season)
                .Select(f => new GetAllPersonelDto
                {
                    PId = f.PersonelId,
                    Name = f.Name,
                    Surname = f.Surname,
                    TC = f.TC,
                    StartDate = f.StartDate,
                    Paid = f.ExistingSeason.Select(x => new PaidDto
                    {
                        Salary = x.Salary,
                        Prim = x.Prim,
                    }).ToList(),
                })
                .ToListAsync()
                .ConfigureAwait(false);

            return personelList;
        }

        public async Task<List<GetAllSeasonDto>> GetSeasonList()
        {
            var seasons = await _dbContext.Seasons.ToListAsync();

            List<GetAllSeasonDto> seasonDtos = seasons.Select(f => new GetAllSeasonDto
            {
                Name = f.SeasonName,
                StartDate = f.SeasonStartDate,
                EndDate = f.SeasonEndDate,
                SId = f.SeasonId,
            }).ToList();

            return seasonDtos;
        }
        /* public async Task<List<GetPersonelBySeasonDto>> GetSeasonById(GetPersonelBySeasonDto request)
        {

            var PersonelBySeason = await _dbContext.Seasons
                .Include(f => f.SeasonPersonel)
                    .ThenInclude(f => f.Personel)
                .Where(f => f.SeasonId == request.SeasonId).Select(f => new GetPersonelBySeasonDto
                {
                    SeasonId = f.SeasonId,
                    SeasonName = f.SeasonName,
                    PersonelBySeasonId = f.Paid.Select(x => new PersonelBySeasonId
                    {
                        StartDate = f.SeasonStartDate,
                        PersonelId = x.PersonelId,
                        Salary = x.Salary,
                        Prim = x.PrimAmount,

                    }).ToList(),
                }).ToArrayAsync().ConfigureAwait(false);

            return PersonelBySeason.ToList();
        }*/

        public async Task<List<GetPersonelBySeasonDto>> GetSeasonById(GetPersonelBySeasonDto request)
        {
            var personelBySeason = await _dbContext.Personels
                .Include(f => f.ExistingSeason)
                    .ThenInclude(f => f.Season)
                .Where(f => f.ExistingSeason.Any(s => s.Season.SeasonId == request.SeasonId))
                .Select(f => new GetPersonelBySeasonDto
                {
                    SeasonId = request.SeasonId,
                    PersonelBySeasonId = f.ExistingSeason.Select(x => new PersonelBySeasonId
                    {
                        PersonelId = x.PersonelId,
                        StartDate = f.StartDate,
                        FullName = $"{x.Personel.Name} {x.Personel.Surname}",
                        Paid = f.ExistingSeason.Select(y => new PaidDto
                        {
                            Salary = y.Salary,
                            Prim = y.Prim,
                        }).ToList()
                    }).ToList(),
                }).ToListAsync().ConfigureAwait(false);
            return personelBySeason;
        }
    }
}
