﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PietkaGymApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage() {
            InitializeComponent();
        }

        private async void GoToTrainingSection(object sender, EventArgs e) {
            await Navigation.PushAsync(new TrainingSection());
        }

        private async void GoToProgressSection(object sender, EventArgs e) {
            await Navigation.PushAsync(); // TODO Nowy obiekt Strony sekcji progresu
        }
    }
}
