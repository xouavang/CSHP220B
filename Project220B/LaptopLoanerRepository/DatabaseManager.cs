using System;
using System.Collections.Generic;
using System.Text;
using LaptopLoanerDB;

namespace LaptopLoanerRepository
{
    public class DatabaseManager
    {
        private static readonly LoanersContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new LoanersContext();
        }

        // Provide an accessor to the database
        public static LoanersContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
