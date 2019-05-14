using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PiętkaApp{

    static class ViewTransactionManager{

        public static void ReadAndViewDatabase(SQLiteConnection dataBase, Label labelView) {

            String stringForLabel = String.Empty;

            var transactionViewString = dataBase.Table<Transaction>().ToList();
            foreach (var singleTransaction in transactionViewString) {
                stringForLabel += singleTransaction.ToString() + "\r\n";
            }

            labelView.Text = stringForLabel;
        }

        public static void ClearInput(Editor editor, Entry entry) {
            editor.Text = String.Empty;
            entry.Text = String.Empty;
        }

        public static float CalculateBudget(SQLiteConnection dataBase, Label labelFirstPage) {
            float budget = 0f;
            
            var transactionViewString = dataBase.Table<Transaction>().ToList();
            foreach(var signleTransaction in transactionViewString) {
                budget += signleTransaction.Cash;
            }

            labelFirstPage.Text = Math.Round(budget, 2).ToString();

            return 0f;
        }
    }
}