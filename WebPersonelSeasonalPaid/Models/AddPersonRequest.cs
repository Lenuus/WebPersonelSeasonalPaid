namespace WebPersonelSeasonalPaid.Models
{
    public class AddPersonRequest
    {
        public string Name { get; set; }

        public Guid SeasonId { get; set; }
        public string Surname { get; set; }
        public DateTime StartDate { get; set; }
        public String TC { get; set; }
        public decimal Salary { get; set; }
        public decimal Prim { get; set; }


    }
}
