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
        ISimpleAudioPlayer workWork = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        ISimpleAudioPlayer silentSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        ISimpleAudioPlayer laughSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

        public SoundPage() {
            InitializeComponent();
            helloDarknessPlayer.Load("HelloDarkness.mp3");
            allAroundMe.Load("AllAroundMe.mp3");
            workWork.Load("PracaPraca.mp3");
            silentSound.Load("CricketSound.wav");
            laughSound.Load("Laugh.wav");
        }

        private void PlayHelloDarkness(object sender, EventArgs e) {
            helloDarknessPlayer.Play();
        }

        private void PlayAllAroundMe(object sender, EventArgs e) {
            allAroundMe.Play();
        }

        private void PlayWork(object sender, EventArgs e) {
            workWork.Play();
        }

        private void PlaySilentSound(object sender, EventArgs e) {
            silentSound.Play();
        }

        private void PlayLaugh(object sender, EventArgs e) {
            laughSound.Play();
        }
    }
}