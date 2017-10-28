using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PosturerAPI.Models
{
    public class PosturerContext : DbContext
    {
        public PosturerContext()
            : base("DbConnection")
        {}

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseStep> ExerciseSteps { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMessage> PatientMessages { get; set; }
        public DbSet<DoctorMessage> DoctorMessages { get; set; }
        public DbSet<PostureLevel> PostureLevels { get; set; }
        public DbSet<ProgramExercise> ProgramExercises { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }       
    }

}
