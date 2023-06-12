using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MyApartment.Data.Services;
using MyApartment.Model.Core;
using MyApartment.Model.Core.Models;

namespace MyApartment.Pages.SVLakeview
{
    public class SVLExpenseListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IMyApartmentExpenseDataProvider _apartmentExpenseDataProvider;



        public SVLExpenseListModel(IConfiguration configuration, IMyApartmentExpenseDataProvider apartmentExpenseData)
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
                if (searchTerm.Equals("Generator"))
                {
                    Expenses = _apartmentExpenseDataProvider.GetExpenseByType(ExpenseType.Generator);
                }

                if (searchTerm.Equals("None"))
                {
                    
                }
                Expenses = _apartmentExpenseDataProvider.GetExpenseByType(ExpenseType.None);
            }
            
            Message = _configuration["ConfigurationMessage"];
        }
    }
}