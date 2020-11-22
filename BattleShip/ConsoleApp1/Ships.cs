using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Ships
    {
        public string name { get; set; }
        public int slength { get; set; }
        public int quantity { get; set; }
        public string symbol { get; set; }

        public Ships(string name,int newlength,int quantity,string symbol)
        {
            this.name = name;
            slength = newlength;
            this.quantity = quantity;
            this.symbol = symbol;
        }

    }
}
