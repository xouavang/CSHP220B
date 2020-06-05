using System;
using System.Collections.Generic;
using System.Text;

namespace LaptopLoanerRepository.Models
{
    public class LoanerModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string GuardianName { get; set; }
        public string GuardianEmail { get; set; }
        public string GuardianPhoneNumber { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
