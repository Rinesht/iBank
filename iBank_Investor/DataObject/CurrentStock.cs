using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iBank_Investor.DataObject
{
    public class CurrentStock
    {
        private String symbol = "";
        private String name = "";
        private float price = 0;
        private float prevClose = 0;
        private float availQty = 0;

        public String Symbol
        {
            get
            {
                return this.symbol;
            }
            set
            {
                this.symbol = value;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public float Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public float PrevClose
        {
            get
            {
                return this.prevClose;
            }
            set
            {
                this.prevClose = value;
            }
        }

        public float AvailableQty
        {
            get
            {
                return this.availQty;
            }
            set
            {
                this.availQty = value;
            }
        }
    }
}