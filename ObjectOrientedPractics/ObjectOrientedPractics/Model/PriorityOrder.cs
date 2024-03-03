using System;

namespace ObjectOrientedPractics.Model
{
    public class PriorityOrder : Order
    {
        public DateTime Date { get; set; }
        public OrderTime Time { get; set; }


        public PriorityOrder() 
        {
        
        }
    }
}
