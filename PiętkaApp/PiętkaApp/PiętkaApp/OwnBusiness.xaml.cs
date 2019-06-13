using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PiętkaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnBusiness : TabbedPage
    {
        SQLiteConnection dataBase;

        public OwnBusiness (SQLiteConnection connection)
        {
            InitializeComponent();
            this.dataBase = connection;
            ReadAndViewDatabase();
        }

        public void ReadAndViewDatabase() {

            try {
                //OwnBusinessManager.ReadAndViewDatabase(dataBase, LabelTransactionList, false);
                //OwnBusinessManager.ReadAndViewDatabase(dataBase, LabelDepositList, true);
            } catch (Exception ex) {
                DisplayAlert("Exception!", ex.Message, "Ok");
            }
        }
    }
}