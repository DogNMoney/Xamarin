using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.SimpleAudioPlayer;

namespace PiętkaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SoundPage : ContentPage
    {
        ISimpleAudioPlayer helloDarknessPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        ISimpleAudioPlayer allAroundMe = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

        public SoundPage() {
            InitializeComponent();
            helloDarknessPlayer.Load("HelloDarkness.mp3");
            allAroundMe.Load("AllAroundMe.mp3");
        }

        private void PlayHelloDarkness(object sender, EventArgs e) {
            helloDarknessPlayer.Play();
        }

        private void PlayAllAroundMe(object sender, EventArgs e) {
            allAroundMe.Play();
        }
    }
}