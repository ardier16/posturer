namespace PosturerAPI.Models.Entities
{
    public class TrainingProgram
    {
        public int TrainingProgramId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
