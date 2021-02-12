using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        //public string Paswoord { get; set; }
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Email" && !(IsEenValideEmailAdres(Email)))
                {
                    return "Gelieve een valide e-mail adres in te geven." + Environment.NewLine;
                }
                else if (columnName == "Voornaam" && string.IsNullOrEmpty(Voornaam))
                {
                    return "Uw voornaam moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Achternaam" && string.IsNullOrEmpty(Achternaam))
                {
                    return "Uw Achternaam moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Gemeente" && string.IsNullOrEmpty(Gemeente))
                {
                    return "Uw Gemeente moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Land" && string.IsNullOrEmpty(Land))
                {
                    return "Uw Land moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Gemeente" && string.IsNullOrEmpty(Gemeente))
                {
                    return "Uw Stad moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Straat" && string.IsNullOrEmpty(Straat))
                {
                    return "Uw Straat moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Huisnummer" && string.IsNullOrEmpty(Huisnummer))
                {
                    return "Uw Huisnummer moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Postcode" && string.IsNullOrEmpty(Postcode))
                {
                    return "Uw Postcode moet ingevuld worden!" + Environment.NewLine;
                }
                //else if (columnName == "Paswoord" && string.IsNullOrEmpty(Paswoord))
                //{
                //    return "Uw Paswoord moet ingevuld worden!" + Environment.NewLine;
                //}
                return "";
            }
        }
        static bool IsEenValideEmailAdres(string emailadres)
        {
            return Regex.IsMatch(emailadres, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
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
               // case "TerugNaarLogin": return true;
                case "GegevensAanpassen":
                    if (IsGeldig())
                    {
                        return true;
                    }
                    return false;
              //case "Registreren":
                    //if (IsGeldig())
                    //{
                    //    return true;

                    //}
                    //return false;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
                case "GegevensAanpassen": GegevensAanpassen(); break;
                //case "Registreren": Registreren(); break;
                //case "TerugNaarLogin": OpenLogin(); break;
            }
        }
        public void OpenDashboard()
        {
            if (customer.IsAdmin == true)
            {
                DashboardViewModel vm = new DashboardViewModel(customer);
                DashboardAdminView view = new DashboardAdminView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                DashboardViewModel vm = new DashboardViewModel(customer);
                DashboardView view = new DashboardView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();
            }
        }
        public void GegevensAanpassen()
        {
            //customer.Achternaam = this.Achternaam ;
            //customer.Voornaam = this.Voornaam;
            //customer.Land = this.Land;
            //customer.Gemeente = this.Gemeente;
            //customer.Postcode = this.Postcode;
            //customer.Straat = this.Straat;
            //customer.Email = this.Email;
            //customer.Huisnummer = this.Huisnummer;
            //if (customer.IsGeldig())
            //{
            //    unitOfWork.CustomerRepo.Aanpassen(customer);
            //    int ok = unitOfWork.Save();
            //    if (ok > 0)
            //    {
            //        RefreshData();
            //    }
            //}
            customer.Achternaam = this.Achternaam;
            customer.Voornaam = this.Voornaam;
            customer.Land = this.Land;
            customer.Gemeente = this.Gemeente;
            customer.Postcode = this.Postcode;
            customer.Straat = this.Straat;
            customer.Email = this.Email;
            customer.Huisnummer = this.Huisnummer;
            unitOfWork.CustomerRepo.Aanpassen(customer);
            unitOfWork.Save();

            OpenDashboard();

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
        //public void OpenLogin()
        //{
        //    LoginViewModel vm = new LoginViewModel();
        //    LoginView view = new LoginView();
        //    view.DataContext = vm;
        //    view.Show();
        //    Application.Current.Windows[0].Close();
        //}
        //public void Registreren()
        //{
        //    byte[] data = System.Text.Encoding.ASCII.GetBytes(Paswoord);
        //    data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
        //    string hash = System.Text.Encoding.ASCII.GetString(data);

        //    Customer customer = new Customer() { Email = Email, Paswoord = hash, Voornaam = Voornaam, Achternaam = Achternaam, Gemeente = Gemeente, Land = Land, Huisnummer = Huisnummer, Postcode = Postcode, Straat = Straat };
        //    unitOfWork.CustomerRepo.Toevoegen(customer);
        //    unitOfWork.Save();

        //    LoginViewModel vm = new LoginViewModel();
        //    LoginView view = new LoginView();
        //    view.DataContext = vm;
        //    view.Show();
        //    Application.Current.Windows[0].Close();
        //}
    }
}
