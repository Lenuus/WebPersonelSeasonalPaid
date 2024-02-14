using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPersonelSeasonalPaid.Domain
{
   public class PersonelSeason
    {
        public Guid PersonelSeasonId { get; set; }

        public Guid PersonelId { get; set; }

        public Personel Personel { get; set; }

        public Guid SeasonId { get; set; }

        public Season Season { get; set; }

        public Decimal Salary { get; set; }

        public Decimal Prim { get; set; }
    }
}
