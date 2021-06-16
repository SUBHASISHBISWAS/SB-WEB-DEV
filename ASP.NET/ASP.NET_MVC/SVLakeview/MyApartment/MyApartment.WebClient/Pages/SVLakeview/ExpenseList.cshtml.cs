using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyApartment.Core.Model;
using MyApartment.Data.Repository;
using MyApartment.WebClient.Utils;

namespace MyApartment.WebClient.Pages.SVLakeview
{
    public class ExpenseListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IMyApartmentExpenseDataProvider _apartmentExpenseDataProvider;

        public ExpenseListModel(IConfiguration configuration, IMyApartmentExpenseDataProvider apartmentExpenseData)
        {
            _configuration = configuration;
            _apartmentExpenseDataProvider = apartmentExpenseData;
        }
        public string Message { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

         
        public IEnumerable<IMyApartmentExpense> Expenses { get; set; }
        public void OnGet(string searchTerm)
        {
            
            if (searchTerm==null)
            {
                Expenses = _apartmentExpenseDataProvider.GetAllExpense();
            }
            else
            {
                var expenseType = searchTerm.ToEnum<ExpenseType>();
                Expenses = _apartmentExpenseDataProvider.GetExpenseByType(expenseType);
            }

            //Message = _configuration["ConfigurationMessage"];
            Message = "My Message";
        }
    }
}