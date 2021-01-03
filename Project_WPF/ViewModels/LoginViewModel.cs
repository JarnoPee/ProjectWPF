using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Project_DAL.Data.UnitOfWork;
using Project_DAL.DomainModels;
using Project_WPF.Views;

namespace Project_WPF.ViewModels
{
    public class LoginViewModel : BasisViewModel, ICommand
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Email" && string.IsNullOrEmpty(Email))
                {
                    return "Email moet ingevuld worden!" + Environment.NewLine;
                }
                return "";
            }
        }

        public string Paswoord { get; set; }
        public string Email { get; set; }
        public string Foutmelding { get; private set; }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {

                case "Registreren": return true;
                case "Aanmelden": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {

                case "Registreren": OpenRegistreren(); break;
                case "Aanmelden": Login(); break;
            }
        }
        public void OpenRegistreren()
        {
            RegistrerenViewModel vm = new RegistrerenViewModel();
            RegistrerenView view = new RegistrerenView();
            view.DataContext = vm;
            view.Show();
            Application.Current.Windows[0].Close();
        }
        public void Login()
        {
            Email = "Test@hotmail.com";
            Paswoord = "Test123!";
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Paswoord);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = System.Text.Encoding.ASCII.GetString(data);
            Customer customer = unitOfWork.CustomerRepo.Ophalen().Where(x => x.Email == Email && x.Paswoord == hash)
            .FirstOrDefault();
            if (customer != null)
            {
                DashboardViewModel vm = new DashboardViewModel(customer);
                DashboardView view = new DashboardView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                Foutmelding = "Email en/of Paswoord is fout!";
                NotifyPropertyChanged("Foutmelding");
            }
        }
    }
}
