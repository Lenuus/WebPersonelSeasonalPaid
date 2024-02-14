using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPersonelSeasonalPaid.Domain
{
    public class Personel
    {
        public Guid PersonelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string TC { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public ICollection<PersonelSeason> ExistingSeason { get; set; }

        public string SeasonName { get; set; }
    }

    //  public ICollection<SalaryPrim> SalaryPrim { get; set;}

}
