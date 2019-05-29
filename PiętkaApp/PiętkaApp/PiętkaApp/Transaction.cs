using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PiętkaApp{

    [Table("Transaction")]
    class Transaction {
        
        public DateTime Date { get; set; }
        public String Title { get; set; }
        public float Cash { get; set; }
        public bool IsDeposit { get; set; }

        public Transaction() {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="title"></param>
        /// <param name="cash"></param>
        /// <param name="isDeposit">True for deposit False for transaction</param>
        public Transaction(DateTime date, String title, float cash, bool isDeposit) {
            this.Date = date;
            this.Title = title;
            this.Cash = cash;
            this.IsDeposit = isDeposit;
        }

        override
        public String ToString() {
            String combinedString;

            combinedString = "Data: " + this.Date.ToShortDateString() + "\r\n" + "Tytuł: " + this.Title + "\r\n" + "Kwota: " + this.Cash + "\r\n";

            return combinedString;
        }
    }
}
