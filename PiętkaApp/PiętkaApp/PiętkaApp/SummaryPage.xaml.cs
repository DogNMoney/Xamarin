using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace PiętkaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryPage : TabbedPage
    {
        SQLiteConnection dataBase;

        public SummaryPage (SQLiteConnection connection)
        {
            InitializeComponent();
            this.dataBase = connection;
            ReadAndViewDatabase();
        }


        public void ReadAndViewDatabase() {

            try {
                ViewTransactionManager.ReadAndViewDatabase(dataBase, LabelTransactionList, false);
                ViewTransactionManager.ReadAndViewDatabase(dataBase, LabelDepositList, true);
            } catch (Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }
    }
}