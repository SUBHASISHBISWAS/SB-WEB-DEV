using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApartment.Core.Model;
using MyApartment.Data.Repository;

namespace MyApartment.WebClient.Pages.SVLakeview
{
    public class EditExpenseModel : PageModel
    {
        private readonly IMyApartmentExpenseDataProvider _myExpenseDataProvider;
        private readonly IHtmlHelper _htmlHelper;

        public IEnumerable<SelectListItem> ExpenseTypes { get; set; }
        public EditExpenseModel(IMyApartmentExpenseDataProvider myExpenseDataProvider,
        IHtmlHelper htmlHelper)
        {
            _myExpenseDataProvider = myExpenseDataProvider;
            _htmlHelper = htmlHelper;
            Expense=new MyApartmentExpense();
        }

        [BindProperty]
        public MyApartmentExpense Expense { get; set; }
        
        public IActionResult OnGet(Guid expenseId)
        {
            ExpenseTypes = _htmlHelper.GetEnumSelectList<ExpenseType>();

            Expense = (MyApartmentExpense)_myExpenseDataProvider.GetExpenseDetailsById(expenseId);
            if (Expense == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        [HttpPost]
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Expense = (MyApartmentExpense)_myExpenseDataProvider.UpdateExpense(Expense);
                _myExpenseDataProvider.Commit();
                TempData["TransactionMessage"] = "Expense Saved Successfully";
                return RedirectToPage("./ExpenseDetails", new { expenseId = Expense.ExpenseId});
            }
            ExpenseTypes = _htmlHelper.GetEnumSelectList<ExpenseType>();
            return Page();
        }
    }
}