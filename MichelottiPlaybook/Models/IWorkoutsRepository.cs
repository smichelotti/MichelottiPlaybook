using System;
namespace MichelottiPlaybook.Models
{
    public interface IWorkoutsRepository
    {
        System.Collections.Generic.List<System.Collections.Generic.List<WorkoutItem>> GetBigManWorkouts();
        System.Collections.Generic.List<System.Collections.Generic.List<WorkoutItem>> GetGuardWorkouts();
    }
}
