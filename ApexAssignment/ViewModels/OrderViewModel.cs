using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexAssignment.ViewModels
{
    public class OrderViewModel : IEnumerable
    {
        public int Id  { get; set; }
        public string Store { get; set; }
        public string Customer { get; set; }
        public string AccountNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerPO { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal InvoiceTotal { get; set; }
        public string ProductNumber { get; set; }
        public short Quantity { get; set; }
        public decimal UnitNet { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}