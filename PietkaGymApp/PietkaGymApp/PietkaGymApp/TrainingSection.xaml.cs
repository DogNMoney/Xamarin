using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PietkaGymApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainingSection : ContentPage{

        public TrainingSection() {
            InitializeComponent();
        }

        private async void GoToTrainingDays(object sender, EventArgs e) {
            await Navigation.PushAsync(); // TODO Nowy obiekt Strony przegladania dni na silce
        }

        private async void GoToWorkouts(object sender, EventArgs e) {
            await Navigation.PushAsync(); // TODO Nowy obiekt Strony przegladania cwiczen
        }

        private async void GoToPersonalStats(object sender, EventArgs e) {
            await Navigation.PushAsync(); // TODO Nowy obiekt Strony przegladania swoich statystyk
        }
    }
}