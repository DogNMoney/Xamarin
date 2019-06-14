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
        SQLiteConnection dataBaseBusiness;
        bool calculateBudgetFromPrevMonth = false;

        public void ReadDatabase() {
            String dataBasePath = String.Empty;
            String dataBaseBusinessPath = String.Empty;

            try {

                String pathSufix = DateTime.Today.Month.ToString() + "R" + DateTime.Today.Year.ToString() + ".db3";
                String pathSufixBS = DateTime.Today.Month.ToString() + "BS" + ".db3";
                dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), pathSufix);
                dataBaseBusinessPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), pathSufixBS);

                if (!File.Exists(dataBasePath)) {
                    calculateBudgetFromPrevMonth = true;
                }

                dataBase = new SQLiteConnection(dataBasePath);
                dataBase.CreateTable<Transaction>();
                dataBaseBusiness = new SQLiteConnection(dataBaseBusinessPath);
                dataBaseBusiness.CreateTable<Business>();

                ViewTransactionManager.CalculateBudget(dataBase, LabelShoppingBudgetValue);
                ViewTransactionManager.SetLastDepositor(dataBase, LabelLastDepositValue, PickerPerson);

                if(calculateBudgetFromPrevMonth == true) {
                    TransactionAdd();
                }

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

        private void TransactionAdd() {
            Transaction transaction;
            int prevMonthDB = DateTime.Today.Month - 1;
            String pathSufix = prevMonthDB.ToString() + "R" + DateTime.Today.Year.ToString() + ".db3";
            String oldDBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), pathSufix);
            SQLiteConnection oldDB;

            if(File.Exists(oldDBPath) == true) {
                try {
                    oldDB = new SQLiteConnection(oldDBPath);
                    oldDB.CreateTable<Transaction>();

                    transaction = new Transaction(DateTime.Now, "Budget from prev month", ViewTransactionManager.CalculateBudget(oldDB), true);
                } catch (Exception ex) {
                    DisplayAlert("Exception!", ex.Message, "Ok");
                }
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
            int j = 0;

            var filesList = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Personal));

            if(filesList.Length > 0) {
                for(int i = 0; i < filesList.Length; i++) {
                    if (filesList[i].ToString().Contains(".db3") == true) {
                        File.Delete(filesList[i]);
                        j++;
                    }
                }
            }

            DisplayAlert("Info", "DB Deleted " + j, "Ok");
        }

        private async void GoToBusinessPanel(object sender, EventArgs e) {
            await Navigation.PushAsync(new OwnBusiness(dataBaseBusiness));
        }

        private void ShowDB(object sender, EventArgs e) {
            String toDisplay = String.Empty;
            var filesList = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Personal));

            foreach(var file in filesList) {
                if (file.ToString().Contains(".db3") == true) {
                    toDisplay += file.ToString() + "\r\n";
                }
            }

            DisplayAlert("Tst", toDisplay, "Ok");
        }
    }
}