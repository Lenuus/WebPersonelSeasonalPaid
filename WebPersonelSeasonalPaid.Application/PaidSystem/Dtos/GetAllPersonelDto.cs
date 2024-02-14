using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPersonelSeasonalPaid.Application.PaidSystem.Dtos
{
    public class GetAllPersonelDto
    {
        public Guid PId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string TC { get; set; }

        public DateTime StartDate { get; set; }

        public List<PaidDto> Paid { get; set; }

    }
}
