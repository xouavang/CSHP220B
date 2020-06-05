using System;
using System.Collections.Generic;
using System.Linq;
using LaptopLoanerRepository.Models;
using LaptopLoanerDB;

namespace LaptopLoanerRepository
{
    public class LaptopLoanerRepository
    {
        public LoanerModel Add(LoanerModel loanerModel)
        {
            var loanerDb = ToDbModel(loanerModel);

            DatabaseManager.Instance.Loaner.Add(loanerDb);
            DatabaseManager.Instance.SaveChanges();

            loanerModel = new LoanerModel
            {
                Id = loanerDb.LoanerId,
                Make = loanerDb.LaptopBrand,
                Model = loanerDb.LaptopModel,
                SerialNumber = loanerDb.LaptopSerialNumber,
                StudentId = loanerDb.StudentId,
                StudentName = loanerDb.StudentName,
                GuardianName = loanerDb.GuardianName,
                GuardianEmail = loanerDb.GuardianEmail,
                GuardianPhoneNumber = loanerDb.GuardianPhoneNumber,
                Notes = loanerDb.LoanerNotes,
                CreatedDate = loanerDb.LoanerCreatedDate
            };
            return loanerModel;
        }

        public List<LoanerModel> GetAll()
        {
            // DatabaseManager.Instance.Contact gets all the contacts from the database as database models.
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Loaner.Select(t => new LoanerModel
              {
                  Id = t.LoanerId,
                  Make = t.LaptopBrand,
                  Model = t.LaptopModel,
                  SerialNumber = t.LaptopSerialNumber,
                  StudentId = t.StudentId,
                  StudentName = t.StudentName,
                  GuardianName = t.GuardianName,
                  GuardianEmail = t.GuardianEmail,
                  GuardianPhoneNumber = t.GuardianPhoneNumber,
                  Notes = t.LoanerNotes,
                  CreatedDate = t.LoanerCreatedDate
              }).ToList();

            return items;
        }

        public bool Update(LoanerModel loanerModel)
        {
            var original = DatabaseManager.Instance.Loaner.Find(loanerModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(loanerModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int loanerId)
        {
            var items = DatabaseManager.Instance.Loaner
                                .Where(t => t.LoanerId == loanerId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Loaner.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Loaner ToDbModel(LoanerModel loanerModel)
        {
            var loanerDb = new Loaner
            {
                LoanerId = loanerModel.Id,
                LaptopBrand = loanerModel.Make,
                LaptopModel = loanerModel.Model,
                LaptopSerialNumber = loanerModel.SerialNumber,
                StudentId = loanerModel.StudentId,
                StudentName = loanerModel.StudentName,
                GuardianName = loanerModel.GuardianName,
                GuardianPhoneNumber = loanerModel.GuardianPhoneNumber,
                GuardianEmail = loanerModel.GuardianEmail,
                LoanerNotes = loanerModel.Notes,
                LoanerCreatedDate = loanerModel.CreatedDate
            };

            return loanerDb;
        }
    }
}

