using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

using Xamarin.Forms;

namespace PietkaGymApp{

    [Table("WorkoutWithIMG")]
    class WorkoutWithIMG : Workout{

        Image workoutImage;

    }
}
