using System;
using System.Collections.Generic;

namespace ObjectOrientedPractics.Model
{
    public class PriorityOrder : Order
    {
        public DateTime Date { get; set; }
        public OrderTime Time { get; set; }


        public PriorityOrder(
            OrderStatus status, 
            Address address, 
            List<Item> items) : base(status, address, items)
        {

        }
    }
}
