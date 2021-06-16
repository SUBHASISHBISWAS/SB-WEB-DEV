using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyApartment.Core.Model;
using MyApartment.Data.Services;

namespace MyApartment.Data.Repository
{
    public class SqlServerExpenseDataProvider : IMyApartmentExpenseDataProvider
    {
        private readonly MyApartmentDbContext _apartmentDbContext;

        public SqlServerExpenseDataProvider(MyApartmentDbContext apartmentDbContext)
        {
            _apartmentDbContext = apartmentDbContext;
        }
        public IEnumerable<IMyApartmentExpense> GetAllExpense()
        {
            return _apartmentDbContext.Expenses;
        }

        public IEnumerable<IMyApartmentExpense> GetExpenseByType(ExpenseType expenseType)
        {
            return from e in _apartmentDbContext.Expenses
                   orderby e.ExpenseAmount
                where e.ExpenseType == expenseType
                select e;
        }

        public IMyApartmentExpense GetExpenseDetailsById(Guid id)
        {
            return _apartmentDbContext.Expenses.FirstOrDefault(exp => exp.ExpenseId==id);
        }

        public IMyApartmentExpense UpdateExpense(IMyApartmentExpense updatedExpense)
        {
            var expense = _apartmentDbContext.Expenses.Attach((MyApartmentExpense)updatedExpense);
            expense.State = EntityState.Modified;
            return updatedExpense;
        }

        public IMyApartmentExpense AddNewExpense(IMyApartmentExpense newExpense)
        {
            _apartmentDbContext.Add(newExpense);
            return newExpense;
        }

        public int Commit()
        {
           return _apartmentDbContext.SaveChanges();
        }

        public IMyApartmentExpense DeleteExpense(Guid expenseId)
        {
            var expense = _apartmentDbContext.Expenses.FirstOrDefault(e => e.ExpenseId == expenseId);
            if (expense != null)
            {
                _apartmentDbContext.Expenses.Remove(expense);
            }

            return expense;
        }
    }
}
