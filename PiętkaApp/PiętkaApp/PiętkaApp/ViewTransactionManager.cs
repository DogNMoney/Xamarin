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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataBase"></param>
        /// <param name="labelView"></param>
        /// <param name="transactionFlag">False for transaction view True for deposit View</param>
        public static void ReadAndViewDatabase(SQLiteConnection dataBase, Label labelView, bool transactionFlag) {

            String stringForLabel = String.Empty;

            var transactionViewString = dataBase.Table<Transaction>().ToList();
            foreach (Transaction singleTransaction in transactionViewString) {
                if(transactionFlag == singleTransaction.IsDeposit) {
                    stringForLabel += singleTransaction.ToString() + "\r\n";
                }
            }

            labelView.Text = stringForLabel;
        }

        public static void ClearInput(Editor editor, Entry entry) {
            editor.Text = String.Empty;
            entry.Text = String.Empty;
        }

        public static void CalculateBudget(SQLiteConnection dataBase, Label labelFirstPage) {
            float budget = 0f;
            
            var transactionViewString = dataBase.Table<Transaction>().ToList();
            foreach(var signleTransaction in transactionViewString) {
                budget += signleTransaction.Cash;
            }

            labelFirstPage.Text = Math.Round(budget, 2).ToString();
        }

        public static float CalculateBudget(SQLiteConnection dataBase) {
            float budget = 0f;

            var transactionViewString = dataBase.Table<Transaction>().ToList();
            foreach (var signleTransaction in transactionViewString) {
                budget += signleTransaction.Cash;
            }

            return (float)Math.Round(budget, 2);
        }

        public static void CalculateMoneySpent(SQLiteConnection dataBase, Label label) {
            float moneySpent = 0f;

            var transactionViewString = dataBase.Table<Transaction>().ToList();
            foreach (var signleTransaction in transactionViewString) {
                if(signleTransaction.IsDeposit == false) {
                    moneySpent += signleTransaction.Cash;
                }
            }

            moneySpent = moneySpent * (-1);
            label.Text = Math.Round(moneySpent, 2).ToString();
        }

        public static void HowMuchAddedMoneyByPerson(SQLiteConnection dataBase, Label labelYou, Label labelAnotherPerson) {
            float moneyAddedYou = 0f;
            float moneyAddedAnotherPerson = 0f;

            var transactionViewString = dataBase.Table<Transaction>().ToList();
            foreach (var signleTransaction in transactionViewString) {
                if (signleTransaction.IsDeposit == true) {
                    if(signleTransaction.Title == "Kasia") {
                        moneyAddedAnotherPerson += signleTransaction.Cash;
                    } else {
                        moneyAddedYou += signleTransaction.Cash;
                    }
                }
            }

            labelYou.Text = Math.Round(moneyAddedYou, 2).ToString();
            labelAnotherPerson.Text = Math.Round(moneyAddedAnotherPerson, 2).ToString();
        }

        public static void SetLastDepositor(SQLiteConnection dataBase, Label labelLastPerson, Picker picker) {
            String personString = String.Empty;
            var people = picker.Items;

            try {
                var transactionViewString = dataBase.Table<Transaction>().ToList();
                foreach (var singleTransaction in transactionViewString) {
                    foreach (var person in people) {
                        if (singleTransaction.Title.Contains(person)) {
                            personString = person;
                        }
                    }
                }
            }catch(Exception ex) {
                throw ex;
            }

            labelLastPerson.Text = personString;
        }
    }
}