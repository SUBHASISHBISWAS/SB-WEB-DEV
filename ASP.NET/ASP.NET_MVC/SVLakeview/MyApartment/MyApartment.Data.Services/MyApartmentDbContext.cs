using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyApartment.Core.Model;


namespace MyApartment.Data.Services
{
    public class MyApartmentDbContext :DbContext
    {
        public MyApartmentDbContext(DbContextOptions<MyApartmentDbContext> options):
            base(options)
        {
                
        }
        public  DbSet<MyApartmentExpense> Expenses { get; set; }
    }
}
