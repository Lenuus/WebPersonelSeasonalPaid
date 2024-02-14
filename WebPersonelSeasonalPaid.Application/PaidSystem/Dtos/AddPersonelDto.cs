using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPersonelSeasonalPaid.Application.PaidSystem.Dtos
{
    public class AddPersonelDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime StartDate { get; set; }
        public String TC { get; set; }
        public decimal Salary { get; set; }
        public decimal Prim { get; set; }
    }
}
