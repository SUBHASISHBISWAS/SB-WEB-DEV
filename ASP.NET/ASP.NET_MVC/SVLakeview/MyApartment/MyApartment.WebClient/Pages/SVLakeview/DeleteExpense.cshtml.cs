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
    public class DeleteExpenseModel : PageModel
    {
        private readonly IMyApartmentExpenseDataProvider _myExpenseDataProvider;

        public MyApartmentExpense Expense { get; set; }

        public DeleteExpenseModel(IMyApartmentExpenseDataProvider apartmentExpenseDataProvider)
        {
            _myExpenseDataProvider = apartmentExpenseDataProvider;
        }

        public IActionResult OnGet(Guid expenseId)
        {
            Expense = (MyApartmentExpense) _myExpenseDataProvider.GetExpenseDetailsById(expenseId);
            if (Expense == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Guid expenseId)
        {
            Expense = (MyApartmentExpense) _myExpenseDataProvider.DeleteExpense(expenseId);
            if (Expense == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{Expense.ExpenseDescription} deleted";
            return RedirectToPage("./ExpenseList");
        }
    }
}
