using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Project_DAL.Data.UnitOfWork;
using Project_DAL.DomainModels;
using Project_WPF.Views;

namespace Project_WPF.ViewModels
{
    public class RegistrerenViewModel : BasisViewModel, ICommand
    {
        public string Foutmelding { get; set; }
        public string Paswoord { get; set; }
        public string Email { get; set; }
        public string Land { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Gemeente { get; set; }
        public string Postcode { get; set; }
        public string Achternaam { get; set; }
        public string Voornaam { get; set; }
        public RegistrerenViewModel()
        {
            Email = "";
        }
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
                else if (columnName == "Paswoord" && string.IsNullOrEmpty(Paswoord))
                {
                    return "Uw Paswoord moet ingevuld worden!" + Environment.NewLine;
                }
                return "";
            }
        }
        static bool IsEenValideEmailAdres(string emailadres)
        {
            return Regex.IsMatch(emailadres, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarLogin": return true;
                case "Registreren":
                    if (IsGeldig())
                    {
                        return true;

                    }
                    return false;
            }
            return true;
        }


        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarLogin": OpenLogin(); break;
                case "Registreren": Registreren(); break;
            }
        }

        public void OpenLogin()
        {
            LoginViewModel vm = new LoginViewModel();
            LoginView view = new LoginView();
            view.DataContext = vm;
            view.Show();
            Application.Current.Windows[0].Close();
        }
        public void Registreren()
        {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(Paswoord);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                string hash = System.Text.Encoding.ASCII.GetString(data);
                Foutmelding = "";
                Customer customer = new Customer() { Email = Email, Paswoord = hash, Voornaam = Voornaam, Achternaam = Achternaam, Gemeente = Gemeente, Land = Land, Huisnummer = Huisnummer, Postcode = Postcode, Straat = Straat };
                if (customer.IsGeldig())
                {
                    if (unitOfWork.CustomerRepo.Ophalen(x => x.Email == Email).Any() == false)
                    {
                        unitOfWork.CustomerRepo.Toevoegen(customer);
                        int ok = unitOfWork.Save();
                        if (ok > 0)
                        {
                        OpenLogin();
                        }
                    }
                    else
                    {
                    Foutmelding = "Email is in gebruik";
                    }

                }



        }
    }
}
