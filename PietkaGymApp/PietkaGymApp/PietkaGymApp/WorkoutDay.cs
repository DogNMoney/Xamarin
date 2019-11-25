using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PietkaGymApp{

    [Table("WorkoutDay")]
    class WorkoutDay{

        public DateTime Date { get; set; }
        public Stack<Workout> Workouts { get; set; }

    }
}
