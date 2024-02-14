using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPersonelSeasonalPaid.Domain
{
    public class Season
    {
        public Guid SeasonId { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }
        public string SeasonName { get; set; }
        public ICollection<PersonelSeason> SeasonPersonel { get; set; }
    
    }

    // public ICollection<SalaryPrim> Paid { get; set; }

}
