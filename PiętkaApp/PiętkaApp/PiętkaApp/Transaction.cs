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

        public Transaction() {

        }

        public Transaction(DateTime date, String title, float cash) {
            this.Date = date;
            this.Title = title;
            this.Cash = cash;
        }

        override
        public String ToString() {
            String combinedString;

            combinedString = "Data: " + this.Date.ToShortDateString() + "\r\n" + "Tytuł: " + this.Title + "\r\n" + "Kwota: " + this.Cash + "\r\n";

            return combinedString;
        }
    }
}
