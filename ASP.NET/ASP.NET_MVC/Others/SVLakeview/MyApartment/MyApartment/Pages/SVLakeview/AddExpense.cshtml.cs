using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApartment.Data.Services;
using MyApartment.Model.Core.Models;

namespace MyApartment
{
    public class AddExpenseModel : PageModel
    {
        private readonly IMyApartmentExpenseDataProvider _myExpenseDataProvider;
        private readonly IHtmlHelper _htmlHelper;

        public IEnumerable<SelectListItem> ExpenseTypes { get; set; }
        public AddExpenseModel(IMyApartmentExpenseDataProvider myExpenseDataProvider,
        IHtmlHelper htmlHelper)
        {
            _myExpenseDataProvider = myExpenseDataProvider;
            _htmlHelper = htmlHelper;
            Expense=new MyApartmentExpense();
        }

        [BindProperty]
        public MyApartmentExpense Expense { get; set; }
        
        public IActionResult OnGet()
        {
            ExpenseTypes = _htmlHelper.GetEnumSelectList<ExpenseType>();

            Expense = new MyApartmentExpense
            {
                ExpenseId = Guid.NewGuid()
            };
            
            _myExpenseDataProvider.AddNewExpense(Expense);
            _myExpenseDataProvider.Commit();
            
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
                TempData["TransactionMessage"] = "New Expense Created Successfully!";
                return RedirectToPage("./ExpenseDetails", new { expenseId = Expense.ExpenseId});
            }
            ExpenseTypes = _htmlHelper.GetEnumSelectList<ExpenseType>();
            return Page();
        }
    }
}