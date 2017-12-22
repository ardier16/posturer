namespace PosturerAPI.Models.Entities
{
    public class ProgramExercise
    {
        public int ProgramExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public TrainingProgram TrainingProgram { get; set; }

        public int ExerciseId { get; set; }
        public int TrainingProgramId { get; set; }
    }
}
