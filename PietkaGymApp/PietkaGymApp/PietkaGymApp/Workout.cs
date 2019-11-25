using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PietkaGymApp{

    [Table("Workout")]
    class Workout{

        public String WorkoutName { get; set; }
        public float RepeatsNumber { get; set; }
        public float Weight { get; set; }

    }
}
