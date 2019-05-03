using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PiętkaApp
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingPage : TabbedPage{

        SQLiteConnection dataBase;

        public void WczytajHistorie() {
            String dataBasePath = "HistoriaDoladowan.txt";

            try {
                dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"Transactions.db3");
                dataBase = new SQLiteConnection(dataBasePath);
                dataBase.CreateTable<Transaction>();
            } catch (Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }

        public ShoppingPage() {
            InitializeComponent();
        }

        private void ClearInput() {
            EditorTransactionTitle.Text = String.Empty;
            EntryTransactionValue.Text = String.Empty;
        }

        private void TransactionSubstract(object sender, EventArgs e) {
            Transaction transaction;
            try {
                transaction = new Transaction(DateTime.Now, EditorTransactionTitle.Text, -float.Parse(EntryTransactionValue.Text));
                dataBase.Insert(transaction);
                ClearInput();
                DisplayAlert("Information", "Transaction Added", "Ok");
            }catch(Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }

        private void TransactionAdd(object sender, EventArgs e) {
            Transaction transaction;
            try {
                transaction = new Transaction(DateTime.Now, EditorTransactionTitle.Text, float.Parse(EntryTransactionValue.Text));
                dataBase.Insert(transaction);
                ClearInput();
                DisplayAlert("Information", "Transaction Added", "Ok");
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