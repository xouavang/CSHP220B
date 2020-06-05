using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AutoMapper;
namespace LaptopLoanerApp.Models
{
    public class LoanerModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private static MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<LoanerModel, LaptopLoanerRepository.Models.LoanerModel>().ReverseMap());
        private static IMapper mapper = config.CreateMapper();

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

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "StudentId":
                        if (StudentId <= 0)
                        {
                            result = "Student ID cannot be empty";
                        }
                        break;
                    case "StudentName":
                        if (string.IsNullOrEmpty(StudentName))
                        {
                            result = "Student name cannot be empty";
                        }
                        break;
                    case "GuardianName":
                        if (string.IsNullOrEmpty(GuardianName))
                        {
                            result = "Parent/Guardian name cannot be empty";
                        }
                        break;
                    case "GuardianPhoneNumber":
                        if (string.IsNullOrEmpty(GuardianPhoneNumber))
                        {
                            result = "Please enter a phone number";
                        }
                        break;
                    case "Make":
                        if (string.IsNullOrEmpty(Make))
                        {
                            result = "Laptop Make/Brand cannot be empty";
                        }
                        break;
                    case "SerialNumber":
                        if (string.IsNullOrEmpty(SerialNumber))
                        {
                            result = "Laptop Serial Number cannot be empty";
                        }
                        break;
                }
                return result;
            }
        }

        public bool IsValid
        {
            get
            {
                return StudentId > 0 && !string.IsNullOrEmpty(StudentName) && !string.IsNullOrEmpty(GuardianName) && !string.IsNullOrEmpty(GuardianPhoneNumber) && !string.IsNullOrEmpty(Make) && !string.IsNullOrEmpty(Model);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoanerModel Clone()
        {
            return (LoanerModel)this.MemberwiseClone();
        }

        public LaptopLoanerRepository.Models.LoanerModel ToRepositoryModel()
        {
            return mapper.Map<LaptopLoanerRepository.Models.LoanerModel>(this);
        }

        public static LoanerModel ToModel(LaptopLoanerRepository.Models.LoanerModel respositoryModel)
        {
            return mapper.Map<LoanerModel>(respositoryModel);
        }
    }
}
