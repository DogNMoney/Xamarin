using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PiętkaApp
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingPage : TabbedPage{

        public void WczytajHistorie() {
            String path = "HistoriaDoladowan.txt";

            try {
                if (File.Exists(path)) {
                    String[] lines = File.ReadAllLines(path);
                    foreach (String line in lines) {
                        //this.ScrollViewHistory += line + "\r\n";
                    }
                } else {
                    //this.HistoriaZPlikuBox.Text = "";
                }
            } catch (Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }

        public ShoppingPage() {
            InitializeComponent();
            this.LabelText.Text = "Lorem Ipsum";
        }

        private void TransactionSubstract(object sender, EventArgs e) {
            try {

            }catch(Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }

        private void TransactionAdd(object sender, EventArgs e) {
            try {

            } catch (Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }

        private void EntryTransactionInputChecker(object sender, TextChangedEventArgs e) {
            try {
                var entry = sender as Entry;

                Regex regex = new Regex(@"^[0-9]*[,]?[0-9]{0,2}$");

                if (regex.IsMatch(entry.Text.ToString())) {
                } else {
                    DisplayAlert("Exception!", "Wprowadzasz zły ciąg liczbowy", "Ok");
                    entry.Text = entry.Text.Remove(entry.Text.Length-1, 1);
                }

                //DisplayAlert("Exception!", entry.Text.ToString(), "Ok");
            } catch(Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }
    }
}