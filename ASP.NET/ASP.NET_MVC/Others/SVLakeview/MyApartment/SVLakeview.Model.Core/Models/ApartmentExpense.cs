using System;
using System.ComponentModel.DataAnnotations;

namespace MyApartment.Core.Model
{
   
    public class MyApartmentExpense : IMyApartmentExpense
    {
        private DateTime _transactionDate;

        [Key]
        public Guid ExpenseId { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Name length can't be more than 1000.")]
        [Display(Name = "Expense Description")]
        public string ExpenseDescription { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Expense Amount")]
        public double ExpenseAmount { get; set; }
        [Required]
        [Display(Name = "Expense Type")]
        public ExpenseType ExpenseType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate 
        {
            get
            {
                return _transactionDate;
            }
            set
            {
                _transactionDate = DateTime.Now;
            }
        }

        [Required]
        public string Payee { get; set; }
        public string Payer { get; set; }
    }
}
