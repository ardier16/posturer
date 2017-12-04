import { Exercise } from '../_models/exercise';

export class TrainingProgram {
    TrainingProgramId: number;
    UserId: string;
    Exercises: Exercise[]
}