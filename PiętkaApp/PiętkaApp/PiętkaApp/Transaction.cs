using System;
using System.Collections.Generic;
using System.Text;

namespace PiętkaApp{

    class Transaction {
        DateTime date;
        String title;
        float cash;

        public DateTime Date {
            get { return this.date; }
            set { this.date = value; }
        }

        public String Title {
            get { return this.title; }
            set { this.title = value; }
        }

        public float Cash {
            get { return this.cash; }
            set { this.cash = value; }
        }

        override
        public String ToString() {
            String combinedString;

            combinedString = this.date.ToShortDateString() + "/r/n" + title + "/r/n" + cash;

            return combinedString;
        }
    }
}
