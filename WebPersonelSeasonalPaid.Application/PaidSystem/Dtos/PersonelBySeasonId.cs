using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPersonelSeasonalPaid.Application.PaidSystem.Dtos
{
    public class PersonelBySeasonId
    {
        public Guid PersonelId { get; set; }

        public DateTime StartDate { get; set; }

        public string FullName { get; set; }

        public List<PaidDto> Paid { get; set; }
    }
}
