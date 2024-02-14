using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPersonelSeasonalPaid.Application.PaidSystem.Dtos
{
    public class GetPersonelBySeasonDto
    {
        public Guid SeasonId { get; set; }

        public List<PersonelBySeasonId> PersonelBySeasonId { get; set; }
    }
}
