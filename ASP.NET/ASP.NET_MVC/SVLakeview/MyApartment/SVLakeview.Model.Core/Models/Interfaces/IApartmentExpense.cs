using System;
using System.Collections.Generic;
using System.Text;

namespace MyApartment.Core.Model
{
    public interface IMyApartmentExpense
    {
         Guid ExpenseId { get; set; }
         string ExpenseDescription { get; set; }
         double ExpenseAmount { get; set; }
         ExpenseType ExpenseType { get; set; }
         DateTime TransactionDate { get; set; }
         string Payee { get; set; }
         string Payer { get; set; }
    }
}
