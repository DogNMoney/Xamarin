﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PiętkaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage() {
            InitializeComponent();
        }

        private async void SwitchToSoundsPage(object sender, EventArgs e) {
            Navigation.PushAsync(new SoundsPage());
        }
    }
}
