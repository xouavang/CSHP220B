using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LaptopLoanerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static LaptopLoanerRepository.LaptopLoanerRepository laptopLoanerRepository;

        static App()
        {
            laptopLoanerRepository = new LaptopLoanerRepository.LaptopLoanerRepository();
        }

        public static LaptopLoanerRepository.LaptopLoanerRepository LaptopLoanerRepository
        {
            get
            {
                return laptopLoanerRepository;
            }
        }
    }
}
