using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPersonelSeasonalPaid.Application.PaidSystem.Dtos
{
    public class GetAllSeasonDto
    {
        public Guid SId { get; set; }

        public string Name { get; set; }    
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
