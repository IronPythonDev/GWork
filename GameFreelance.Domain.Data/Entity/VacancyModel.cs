namespace GameFreelance.Domain.Core.Entity
{
    public class VacancyModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string VacancyName { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }
        public int Category { get; set; }
    }
}
