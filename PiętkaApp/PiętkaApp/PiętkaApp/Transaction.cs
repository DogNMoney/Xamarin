using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PiętkaApp{

    [Table("Transaction")]
    class Transaction {

        [PrimaryKey, AutoIncrement]
        int Id { get; set; }
        DateTime Date { get; set; }
        String Title { get; set; }
        float Cash { get; set; }

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

            combinedString = this.Date.ToShortDateString() + "/r/n" + this.Title + "/r/n" + this.Cash;

            return combinedString;
        }
    }
}
