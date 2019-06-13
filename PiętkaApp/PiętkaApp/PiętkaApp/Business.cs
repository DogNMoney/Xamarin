using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PiętkaApp
{
    [Table("Business")]
    class Business
    {
        public DateTime Date { get; set; }
        public String Category { get; set; }
        public float Cash { get; set; }
        public bool IsDeposit { get; set; }

        public Business() {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="category"></param>
        /// <param name="cash"></param>
        /// <param name="isDeposit">True for deposit False for transaction</param>
        public Business(DateTime date, String category, float cash, bool isDeposit) {
            this.Date = date;
            this.Category = category;
            this.Cash = cash;
            this.IsDeposit = isDeposit;
        }

        override
        public String ToString() {
            String combinedString;

            combinedString = "Data: " + this.Date.ToShortDateString() + "\r\n" + "Tytuł: " + this.Category + "\r\n" + "Kwota: " + this.Cash + "\r\n";

            return combinedString;
        }
    }
}
