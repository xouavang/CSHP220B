using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ContactApp.Models
{
    public class ContactModel
    {
        private static MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<ContactModel, ContactRepository.ContactModel>().ReverseMap());
        private static IMapper mapper = config.CreateMapper();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }

        public ContactModel Clone()
        {
            return (ContactModel)this.MemberwiseClone();
        }

        public ContactRepository.ContactModel ToRepositoryModel()
        {
            return mapper.Map<ContactRepository.ContactModel>(this);
        }

        public static ContactModel ToModel(ContactRepository.ContactModel respositoryModel)
        {
            return mapper.Map<ContactModel>(respositoryModel);
        }
    }
}
