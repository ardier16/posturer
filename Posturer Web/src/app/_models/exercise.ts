export class Exercise {
  ExerciseId: number;
  Description: string;
  DifficultyLevel: number;
  Steps: ExerciseStep[];

}

export class ExerciseStep {
  ExerciseStepId: number;
  StepNumber: number;
  Text: string;
  ImageUrl: string;
}
