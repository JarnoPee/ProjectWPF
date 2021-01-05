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
        public string Geschiktheid { get; set; }
        public decimal? Prijs { get; set; }
        public string Diepte { get; set; }
        public string DescriptionBeschrijving { get; set; }
        public string PreviewBeschrijving { get; set; }
        public string Categorie { get; set; }

        public Location Location { get; set; }
        public int locationID;
        public GekozenDuiklocatieViewModel(int locationID, Customer customer)
        {
            this.locationID = locationID;
            this.customer = customer;
            Location = unitOfWork.LocationRepo.Ophalen(x => x.LocationID == locationID, x => x.Category, x => x.Preview, x => x.Description).SingleOrDefault();
            Naam = Location.Naam;
            Land = Location.Land;
            Prijs = Location.Prijs;
            Geschiktheid = Location.Geschiktheid;
            Straat = Location.Straat;
            Gemeente = Location.Stad;
            Diepte = Location.Diepte;
            Huisnummer = Location.Huisnummer;
            Categorie =Location.Category.Naam;
            PreviewBeschrijving = Location.Preview.PreviewBeschrijving;
            DescriptionBeschrijving = Location.Description.DescriptionBeschrijving;
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
                case "LocatieWijzigen": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
                case "ToevoegenLocationCustomer": OpenToevoegenLocationCustomer(); break;
                case "LocatieWijzigen": LocatieWijzigen(); break;
            }
        }
        public void OpenDashboard()
        {
            if (customer.IsAdmin == true)
            {
                DashboardAdminViewModel vm = new DashboardAdminViewModel(customer);
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
        public void LocatieWijzigen()
        {
            Location.Naam = this.Naam;
            Location.Prijs = this.Prijs;
            Location.Land = this.Land;
            Location.Stad = this.Gemeente;
            Location.Diepte = this.Diepte;
            Location.Geschiktheid = this.Geschiktheid;
            Location.Straat = this.Straat;
            Location.Preview.PreviewBeschrijving = this.PreviewBeschrijving;
            Location.Description.DescriptionBeschrijving = this.DescriptionBeschrijving;
            Location.Huisnummer = this.Huisnummer;
            if (customer.IsGeldig())
            {
                unitOfWork.CustomerRepo.Aanpassen(customer);
                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    RefreshData(locationID);
                }
            }
        }
        private void RefreshData(int locationID)
        {
            Location = unitOfWork.LocationRepo.Ophalen(x => x.LocationID == locationID, x => x.Category, x => x.Preview, x => x.Description).SingleOrDefault();
            Naam = Location.Naam;
            Land = Location.Land;
            Prijs = Location.Prijs;
            Geschiktheid = Location.Geschiktheid;
            Straat = Location.Straat;
            Gemeente = Location.Stad;
            Diepte = Location.Diepte;
            Huisnummer = Location.Huisnummer;
            Categorie = Location.Category.Naam;
            PreviewBeschrijving = Location.Preview.PreviewBeschrijving;
            DescriptionBeschrijving = Location.Description.DescriptionBeschrijving;
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
