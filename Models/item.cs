using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateManagmentLab.Models
{
    public class item
    {
        public string ItemName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }


       

        public item (string itemName,string description, double price)
        {
            ItemName = itemName;
            Price = price;
            Description = description;
        }

        public item() { }

        

        
    }
}