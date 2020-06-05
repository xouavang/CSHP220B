using System;
using System.Collections.Generic;

namespace LaptopLoanerDB
{
    public partial class Loaner
    {
        public int LoanerId { get; set; }
        public string LaptopBrand { get; set; }
        public string LaptopModel { get; set; }
        public string LaptopSerialNumber { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string GuardianName { get; set; }
        public string GuardianEmail { get; set; }
        public string GuardianPhoneNumber { get; set; }
        public string LoanerNotes { get; set; }
        public DateTime LoanerCreatedDate { get; set; }
    }
}
