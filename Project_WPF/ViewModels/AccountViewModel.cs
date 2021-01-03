using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Project_DAL;
using Project_DAL.Data.UnitOfWork;
using Project_DAL.DomainModels;
using Project_WPF.Views;

namespace Project_WPF.ViewModels
{
    public class AccountViewModel : BasisViewModel, ICommand
    {
        public Customer customer { get; set; }
        public string Foutmelding { get; set; }
        public string AccountID { get; set; }
        public string Achternaam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public string Land { get; set; }
        public string Straat { get; set; }
        public string Gemeente { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Email" && string.IsNullOrEmpty(Email))
                {
                    return "Email moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Voornaam" && string.IsNullOrEmpty(Email))
                {
                    return "Uw voornaam moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Achternaam" && string.IsNullOrEmpty(Email))
                {
                    return "Uw Achternaam moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Gemeente" && string.IsNullOrEmpty(Email))
                {
                    return "Uw Gemeente moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Land" && string.IsNullOrEmpty(Email))
                {
                    return "Uw Land moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Stad" && string.IsNullOrEmpty(Email))
                {
                    return "Uw Stad moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Straat" && string.IsNullOrEmpty(Email))
                {
                    return "Uw Straat moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Huisnummer" && string.IsNullOrEmpty(Email))
                {
                    return "Uw Huisnummer moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Postcode" && string.IsNullOrEmpty(Email))
                {
                    return "Uw Postcode moet ingevuld worden!" + Environment.NewLine;
                }
                return "";
            }
        }

        public AccountViewModel(Customer customer)
        {
            this.customer = customer;
            this.Achternaam = customer.Achternaam;
            this.Voornaam = customer.Voornaam;
            this.Land = customer.Land;
            this.Straat = customer.Straat;
            this.Gemeente = customer.Gemeente;
            this.Huisnummer = customer.Huisnummer;
            this.Postcode = customer.Postcode;
            this.Email = customer.Email;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
                case "GegevensAanpassen": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
                case "GegevensAanpassen": GegevensAanpassen(); break;
            }
        }
        public void OpenDashboard()
        {
            DashboardViewModel vm = new DashboardViewModel(customer);
            DashboardView view = new DashboardView();
            view.DataContext = vm;
            view.Show();
            Application.Current.Windows[0].Close();

        }
        public void GegevensAanpassen()
        {
            customer.Achternaam = this.Achternaam ;
            customer.Voornaam = this.Voornaam;
            customer.Land = this.Land;
            customer.Gemeente = this.Gemeente;
            customer.Postcode = this.Postcode;
            customer.Straat = this.Straat;
            customer.Email = this.Email;
            customer.Huisnummer = this.Huisnummer;
            if (customer.IsGeldig())
            {
                unitOfWork.CustomerRepo.Aanpassen(customer);
                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    RefreshData();
                }
            }
        }
        private void RefreshData()
        {
            this.Achternaam = customer.Achternaam;
            this.Voornaam = customer.Voornaam;
            this.Land = customer.Land;
            this.Straat = customer.Straat;
            this.Gemeente = customer.Gemeente;
            this.Huisnummer = customer.Huisnummer;
            this.Postcode = customer.Postcode;
            this.Email = customer.Email;
        }
    }
        //private void FoutmeldingInstellenNaSave(int ok, string melding)
        //{
        //    if (ok > 0)
        //    {
        //        RefreshAccountGegevens();
        //        Resetten();
        //    }
        //    else
        //    {
        //        Foutmelding = melding;
        //    }
        //}
        //private void RefreshAccountGegevens()
        //{
        //    int i = int.Parse(AccountID);
        //    List<Customer> listCustomers = unitOfWork.CustomerRepo.Ophalen(x => x.CustomerID == i).ToList();

        //    Klanten = new ObservableCollection<Customer>(listCustomers);
        //}
        //public void Resetten()
        //{
        //    if (this.IsGeldig())
        //    {
        //        Foutmelding = "";
        //    }
        //    else
        //    {
        //        Foutmelding = this.Error;
        //    }
        //}
}
