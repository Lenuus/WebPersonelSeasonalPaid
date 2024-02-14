using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPersonelSeasonalPaid.Application.PaidSystem.Dtos
{
    public class AddSeasonDto
    {
        public string SeasonName { get; set; }

        public DateTime SeasonStartDate { get; set; }

        public DateTime SeasonEndDate { get; set; }
    }
}
