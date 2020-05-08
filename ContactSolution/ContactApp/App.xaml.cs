using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ContactRepository.ContactRepository contactRepository;

        static App()
        {
            // If multiple repository then you will have multiple instantiation of respositories.
            contactRepository = new ContactRepository.ContactRepository();
        }

        public static ContactRepository.ContactRepository ContactRepository
        {
            get
            {
                return contactRepository;
            }
        }

    }
}
