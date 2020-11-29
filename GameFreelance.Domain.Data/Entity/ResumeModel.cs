namespace GameFreelance.Domain.Core.Entity
{
    public class ResumeModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }
        public int Category { get; set; }
        public string Position { get; set; }
        public string ExperienceText { get; set; }
        public string Attainment { get; set; }
    }
}
