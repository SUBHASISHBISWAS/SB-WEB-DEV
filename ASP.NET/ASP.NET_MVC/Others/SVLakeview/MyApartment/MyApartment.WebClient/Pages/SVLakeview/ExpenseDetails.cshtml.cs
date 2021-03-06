using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApartment.Core.Model;
using MyApartment.Data.Repository;

namespace MyApartment.WebClient.Pages.SVLakeview
{
    public class ExpenseDetailsModel : PageModel
    {
        private readonly IMyApartmentExpenseDataProvider _apartmentDataProvider;

        public ExpenseDetailsModel(IMyApartmentExpenseDataProvider apartmentDataProvider)
        {
            this._apartmentDataProvider = apartmentDataProvider;
        }
        public IMyApartmentExpense Expense { get; set; }

        [TempData]
        public string TransactionMessage { get; set; }
        public void OnGet(Guid expenseId)
        {
            Expense = _apartmentDataProvider.GetExpenseDetailsById(expenseId);
        }
    }
}