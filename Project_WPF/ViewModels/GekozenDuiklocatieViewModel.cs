using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class GekozenDuiklocatieViewModel : BasisViewModel, ICommand, IDisposable
    {
        private Customer customer;
        public string Land { get; set; }
        public string Straat { get; set; }
        public string Gemeente { get; set; }
        public string Huisnummer { get; set; }
        public string Naam { get; set; }
        public decimal? Prijs { get; set; }
        public string Diepte { get; set; }
        public string DescriptionBeschrijving { get; set; }
        public string PreviewBeschrijving { get; set; }
        public string Categorie { get; set; }

        public Location Location { get; set; }
        public GekozenDuiklocatieViewModel(int locationID, Customer customer)
        {
            this.customer = customer;
            Location = unitOfWork.LocationRepo.Ophalen(x => x.LocationID == locationID, x => x.Category, x => x.Preview, x => x.Description).SingleOrDefault();
            Naam = Location.Naam;
            Land = Location.Land;
            Prijs = Location.Prijs;
            Straat = Location.Straat;
            Gemeente = Location.Stad;
            Diepte = Location.Diepte;
            Huisnummer = Location.Huisnummer;
            Categorie =Location.Category.Naam;
            PreviewBeschrijving = Location.Preview.Beschrijving;
            DescriptionBeschrijving = Location.Description.Beschrijving;
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Gemeente" && string.IsNullOrEmpty(Gemeente))
                {
                    return "Email moet ingevuld worden!" + Environment.NewLine;
                }
                return "";
            }
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
                case "ToevoegenLocationCustomer": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
                case "ToevoegenLocationCustomer": OpenToevoegenLocationCustomer(); break;
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
        public void OpenToevoegenLocationCustomer()
        {
            if (Location != null)
            {
                LocationCustomer locationCustomer = new LocationCustomer()
                {
                    LocationID = Location.LocationID,
                    CustomerID = customer.CustomerID
                };

                if (locationCustomer.IsGeldig())
                {
                    unitOfWork.LocationCustomerRepo.Toevoegen(locationCustomer);
                    int ok = unitOfWork.Save();
                    if (ok > 0)
                    {
                        FavorietenViewModel vm = new FavorietenViewModel(customer);
                        FavorietenView view = new FavorietenView();
                        view.DataContext = vm;
                        view.Show();
                        Application.Current.Windows[0].Close();
                    }
                }
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
