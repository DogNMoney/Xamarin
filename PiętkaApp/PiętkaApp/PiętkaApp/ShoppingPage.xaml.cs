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

        public void ReadDatabase() {
            String dataBasePath = String.Empty;

            try {

                String pathSufix = DateTime.Today.Month.ToString() + ".db3";
                dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), pathSufix);
                if (!File.Exists(dataBasePath))
                    DisplayAlert("Information", "New Database for new month created", "Ok");

                dataBase = new SQLiteConnection(dataBasePath);
                dataBase.CreateTable<Transaction>();
                ViewTransactionManager.CalculateBudget(dataBase, LabelShoppingBudgetValue);
                ViewTransactionManager.SetLastDepositor(dataBase, LabelLastDepositValue, PickerPerson);

            } catch (Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }

        public ShoppingPage() {
            InitializeComponent();
            ReadDatabase();
        }

        private void TransactionSubstract(object sender, EventArgs e) {
            Transaction transaction;
            try {
                transaction = new Transaction(DateTime.Now, EditorTransactionTitle.Text, -float.Parse(EntryTransactionValueTransaction.Text), false);
                dataBase.Insert(transaction);
                ViewTransactionManager.ClearInput(EditorTransactionTitle, EntryTransactionValueTransaction);
                ViewTransactionManager.CalculateBudget(dataBase, LabelShoppingBudgetValue);
                DisplayAlert("Information", "Transaction Added", "Ok");
            }catch(Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }

        private void TransactionAdd(object sender, EventArgs e) {
            Transaction transaction;
            String transactionTitle = String.Empty;
            try {
                String pickerValue = PickerPerson.SelectedItem as String;
                if (pickerValue != String.Empty || pickerValue != null){
                    transactionTitle = "Wpłata od: " + pickerValue;
                    transaction = new Transaction(DateTime.Now, transactionTitle, float.Parse(EntryTransactionValueDeposit.Text), true);
                    dataBase.Insert(transaction);
                    ViewTransactionManager.ClearInput(EditorTransactionTitle, EntryTransactionValueDeposit);
                    ViewTransactionManager.CalculateBudget(dataBase, LabelShoppingBudgetValue);
                    LabelLastDepositValue.Text = pickerValue;
                    DisplayAlert("Information", "Transaction Added", "Ok");
                } else {
                    throw new Exception("Empty value of picker, please pick person");
                }
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

            } catch(Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }

        private async void GoToSummary(object sender, EventArgs e) {
            await Navigation.PushAsync(new SummaryPage(dataBase));
        }

        private void ResetDB(object sender, EventArgs e) {
            dataBase.DropTable<Transaction>();
            DisplayAlert("Info", "DB Deleted", "Ok");
        }
    }
}