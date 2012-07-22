using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MichelottiPlaybook.Models
{
    /// <summary>
    /// //TODO: move this hard-coded data to tables
    /// </summary>
    public class WorkoutsRepository : MichelottiPlaybook.Models.IWorkoutsRepository 
    {
        public List<List<WorkoutItem>> GetGuardWorkouts()
        {
            var list = new List<List<WorkoutItem>>
            {
                new List<WorkoutItem> {
                new WorkoutItem { Name = "Ball Slaps", Href = "/Workouts/ball-handling#ball-slaps", Description = "25x each hand" },
                new WorkoutItem { Name = "Pound Cross", Href = "/Workouts/ball-handling#stationary-pound-cross", Description = "25x each hand" },
                new WorkoutItem { Name = "Side to Side", Href = "/Workouts/ball-handling#side-to-side", Description = "20x each hand" },
                new WorkoutItem { Name = "Scissors", Href = "/Workouts/ball-handling#scissors", Description = "50x total" },
                new WorkoutItem { Name = "Form Shooting", Href = "/Workouts/shooting#form-shooting", Description = "50 shots total, gradually moving back. Do not push with guide hand!" },
                new WorkoutItem { Name = "Elbow Shooting", Href = "/Workouts/shooting#elbows", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Cross Through Back", Href = "/Workouts/ball-handling#ctb", Description = "Half-court and back 3x" },
                new WorkoutItem { Name = "Pump 1", Href = "/Workouts/shooting#pump-1", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Jab 1-2", Href = "/Workouts/shooting#jab-1-2", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Reverse Pivot, Jab, Step back", Href = "/Workouts/post#reverse-pivot-jab-step-back", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "2-Ball Stationary Cross", Href = "/Workouts/ball-handling-advanced#stationary-2-ball-cross", Description = "30x total" },
                new WorkoutItem { Name = "2-Ball Crossover Series", Href = "/Workouts/ball-handling-advanced#crossover-2-ball-series", Description = "Half-court and back for each variation shown in video" },
                new WorkoutItem { Name = "Behind Back Continuous", Href = "/Workouts/ball-handling-advanced#behind-back-continuous", Description = "Half-court and back 3x" },
                new WorkoutItem { Name = "X-Drill", Href = "/Workouts/ball-handling#x-drill", Description = "10x total lay-ups" }
            },
            {
                new List<WorkoutItem> {
                new WorkoutItem { Name = "Figure 8", Href = "/Workouts/ball-handling#figure-8", Description = "Follow progression on video" },
                new WorkoutItem { Name = "Stationary Between Legs / Behind Back", Href = "/Workouts/ball-handling#stationary-between-legs-behind-back", Description = "20x each hand" },
                new WorkoutItem { Name = "Front Cross", Href = "/Workouts/ball-handling#front-cross", Description = "10x each hand" },
                new WorkoutItem { Name = "Inside Out", Href = "/Workouts/ball-handling#inside-out", Description = "10x each hand" },
                new WorkoutItem { Name = "Form Shooting", Href = "/Workouts/shooting#form-shooting", Description = "50 shots total, gradually moving back. Do not push with guide hand!" },
                new WorkoutItem { Name = "Wings", Href = "/Workouts/shooting#wings", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Machine Gun", Href = "/Workouts/ball-handling-advanced#machine-gun", Description = "15 secs each hand, 15 secs both hands" },
                new WorkoutItem { Name = "Baseline", Href = "/Workouts/shooting#baseline", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Spider", Href = "/Workouts/ball-handling-advanced#spider", Description = "30 seconds" },
                new WorkoutItem { Name = "Bank Shots", Href = "/Workouts/shooting#bank-shots", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Spin", Href = "/Workouts/ball-handling-advanced#spin", Description = "10x each hand" },
                new WorkoutItem { Name = "Basic 2-Ball Series", Href = "/Workouts/ball-handling-advanced#basic-2-ball-series", Description = "Half-court and back for each variation shown in video" }
            }}
            };

            return list;
        }

        public List<List<WorkoutItem>> GetBigManWorkouts()
        {
            var list = new List<List<WorkoutItem>>
            {
                new List<WorkoutItem> {
                new WorkoutItem { Name = "Ball Slaps", Href = "/Workouts/ball-handling#ball-slaps", Description = "25x each hand" },
                new WorkoutItem { Name = "Ball Circles", Href = "/Workouts/ball-handling#ball-circles", Description = "10x around head, 10x around waist, 10x are feet, then switch direction" },
                new WorkoutItem { Name = "Side to Side", Href = "/Workouts/ball-handling#side-to-side", Description = "20x each hand" },
                new WorkoutItem { Name = "X-Drill", Href = "/Workouts/ball-handling#x-drill", Description = "10x total lay-ups" },
                new WorkoutItem { Name = "Mikan", Href = "/Workouts/post#mikan-drill", Description = "Drill ends when you *make* 10 with each hand" },
                new WorkoutItem { Name = "Drop Step", Href = "/Workouts/post#drop-step", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Jab 1-2", Href = "/Workouts/shooting#jab-1-2", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Front Cross", Href = "/Workouts/ball-handling#front-cross", Description = "10x each hand" },
                new WorkoutItem { Name = "Form Shooting", Href = "/Workouts/shooting#form-shooting", Description = "50 shots total, gradually moving back. Do not push with guide hand!" },
                new WorkoutItem { Name = "Turnaround Jumper", Href = "/Workouts/post#turnaround-jumper", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Turnaround Pump Step-through", Href = "/Workouts/post#turnaround-pump-step-through", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Tap Drill", Href = "/Workouts/post#tap-drill", Description = "10x each side - then repeat" },
                new WorkoutItem { Name = "Bank Shots", Href = "/Workouts/shooting#bank-shots", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "X-Drill", Href = "/Workouts/ball-handling#x-drill", Description = "10x total lay-ups (this is an intentional repeat)" }
            },
            {
                new List<WorkoutItem> {
                new WorkoutItem { Name = "Side to Side", Href = "/Workouts/ball-handling#side-to-side", Description = "20x each hand" },
                new WorkoutItem { Name = "X-Drill", Href = "/Workouts/ball-handling#x-drill", Description = "10x total lay-ups" },
                new WorkoutItem { Name = "Pump 1", Href = "/Workouts/shooting#pump-1", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Mikan", Href = "/Workouts/post#mikan-drill", Description = "Drill ends when you *make* 10 with each hand" },
                new WorkoutItem { Name = "Front Cross", Href = "/Workouts/ball-handling#front-cross", Description = "10x each hand" },
                new WorkoutItem { Name = "Inside Out Zig Zag (Off Hand)", Href = "/Workouts/ball-handling#inside-out-zig-zag", Description = "3x full-court" },
                new WorkoutItem { Name = "Turnaround Jumper 1 Dribble", Href = "/Workouts/post#turnaround-jumper-1-dribble", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Reverse Pivot", Href = "/Workouts/post#reverse-pivot", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Drop Step", Href = "/Workouts/post#drop-step", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Baseline", Href = "/Workouts/shooting#baseline", Description = "10x shots, 5 free throws, 10x shots" },
                new WorkoutItem { Name = "Stutter Step", Href = "/Workouts/ball-handling#stutter-step", Description = "10x each hand" },
                new WorkoutItem { Name = "Mikan", Href = "/Workouts/post#mikan-drill", Description = "Drill ends when you *make* 10 with each hand (this is an intentional repeat)" }
            }}
            };

            return list;
        }

    }
}