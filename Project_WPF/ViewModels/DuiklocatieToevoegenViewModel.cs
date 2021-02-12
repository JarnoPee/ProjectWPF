using Project_DAL.DomainModels;
using Project_WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_WPF.ViewModels
{
    class DuiklocatieToevoegenViewModel : BasisViewModel
    {
        private Customer customer;
        public string Foutmelding { get; set; }
        public string Land { get; set; }
        public string Straat { get; set; }
        public string Stad { get; set; }
        public string Huisnummer { get; set; }
        public string Naam { get; set; }
        public decimal? Prijs { get; set; }
        public string Diepte { get; set; }
        public string DescriptionBeschrijving { get; set; }
        public string PreviewBeschrijving { get; set; }
        public string Categorie { get; set; }
        public string Geschiktheid { get; set; }

        public Category GeselecteerdeCategory { get; set; }
        public Location Location { get; set; }
        public Category Category { get; set; }
        public Preview Preview { get; set; }
        public Description Description { get; set; }

        public ObservableCollection<Location> Locations { get; set; }
        public ObservableCollection<Category> Categories { get; set; }


        public DuiklocatieToevoegenViewModel(int? locationID, Customer customer)
        {
            this.customer = customer;

            Categories = new ObservableCollection<Category>(unitOfWork.CategoryRepo.Ophalen());

            if (locationID != null)
            {

                Location = unitOfWork.LocationRepo.Ophalen(x => x.LocationID == locationID, x => x.Category, x => x.Preview, x => x.Description).SingleOrDefault();
                Naam = Location.Naam;
                Land = Location.Land;
                Prijs = Location.Prijs;
                Straat = Location.Straat;
                Stad = Location.Stad;
                Diepte = Location.Diepte;
                Geschiktheid = Location.Geschiktheid;
                Huisnummer = Location.Huisnummer;
                GeselecteerdeCategory = Categories.FirstOrDefault(x => x.CategoryID == Location.CategoryID);
                Categorie = Location.Category.Naam;
                PreviewBeschrijving = Location.Preview.PreviewBeschrijving;
                DescriptionBeschrijving = Location.Description.DescriptionBeschrijving;
            }
            else
            {
                Location = new Location();
            }
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Stad" && string.IsNullOrEmpty(Stad))
                {
                    return "De gemeente moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Naam" && string.IsNullOrEmpty(Naam))
                {
                    return "De Naam moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Geschiktheid" && string.IsNullOrEmpty(Geschiktheid))
                {
                    return "De geschiktheid moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Prijs" && Prijs == null)
                {
                    return "De prijs moet een numeriek getal zijn" + Environment.NewLine;
                }
                else if (columnName == "Land" && string.IsNullOrEmpty(Land))
                {
                    return "De Land moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Straat" && string.IsNullOrEmpty(Straat))
                {
                    return "De Straat moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Diepte" && string.IsNullOrEmpty(Diepte))
                {
                    return "De Diepte moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "Huisnummer" && string.IsNullOrEmpty(Huisnummer))
                {
                    return "De Huisnummer moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "GeselecteerdeCategory" && GeselecteerdeCategory == null)
                {
                    return "De categorie moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "DescriptionBeschrijving" && string.IsNullOrEmpty(DescriptionBeschrijving))
                {
                    return "De beschrijving moet ingevuld worden!" + Environment.NewLine;
                }
                else if (columnName == "PreviewBeschrijving" && string.IsNullOrEmpty(PreviewBeschrijving))
                {
                    return "De preview moet ingevuld worden!" + Environment.NewLine;
                }
                return "";
            }
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
                case "LocatieVerwijderen":
                    if (IsGeldig())
                    {
                        return true;

                    }
                    return false;
                case "LocatieToevoegenOfAanpassen":
                    if (IsGeldig())
                    {
                        return true;

                    }
                    return false;
                case "ToevoegenLocationCustomer": return true;

            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
                case "LocatieVerwijderen": LocatieVerwijderen(); break;
                case "LocatieToevoegenOfAanpassen": LocatieToevoegenOfAanpassen(); break;
                case "ToevoegenLocationCustomer": OpenToevoegenLocationCustomer(); break;

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
        private void LocatieToevoegenOfAanpassen()
        {
            if (Location.LocationID > 0)
            {
                Location.Naam = Naam;
                Location.Prijs = Prijs;
                Location.Diepte = Diepte;
                Location.Land = Land;
                Location.Straat = Straat;
                Location.Stad = Stad;
                Location.Huisnummer = Huisnummer;
                Location.Geschiktheid = Geschiktheid;
                Location.Category = GeselecteerdeCategory;
                Location.Preview.PreviewBeschrijving = PreviewBeschrijving;
                Location.Description.DescriptionBeschrijving = DescriptionBeschrijving;

                unitOfWork.LocationRepo.Aanpassen(Location);
                MessageBox.Show("De locatie is succesvol aangepast");
                unitOfWork.Save();
 
                DuiklocatieViewModel vm = new DuiklocatieViewModel(customer, "");
                DuiklocatieView view = new DuiklocatieView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                Location Location = new Location();
                Location.Naam = Naam;
                Location.Prijs = Prijs;
                Location.Diepte = Diepte;
                Location.Land = Land;
                Location.Straat = Straat;
                Location.Stad = Stad;
                Location.Huisnummer = Huisnummer;
                Location.Geschiktheid = Geschiktheid;
                Location.Category = GeselecteerdeCategory;
                Preview Preview = new Preview();
                Preview.PreviewBeschrijving = PreviewBeschrijving;
                Description Description = new Description();
                Description.DescriptionBeschrijving = DescriptionBeschrijving;

                unitOfWork.PreviewRepo.Toevoegen(Preview);
                unitOfWork.DescriptionRepo.Toevoegen(Description);
                Location.Description = Description;
                Location.Preview = Preview;
                unitOfWork.LocationRepo.Toevoegen(Location);
                MessageBox.Show("De locatie is succesvol aangepast");

                unitOfWork.Save();

                DuiklocatieViewModel vm = new DuiklocatieViewModel(customer, "DuiklocatieView");
                DuiklocatieView view = new DuiklocatieView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();
            }


        }
        private void LocatieVerwijderen()
        {
                unitOfWork.LocationRepo.Verwijderen(Location);
                unitOfWork.Save();
                    DuiklocatieViewModel vm = new DuiklocatieViewModel(customer, "DuiklocatieView");
                    DuiklocatieView view = new DuiklocatieView();
                    view.DataContext = vm;
                    view.Show();
                    Application.Current.Windows[0].Close();            
        }
        public void OpenToevoegenLocationCustomer()
        {
            if (Location != null)
            {
                Foutmelding = "";
                    try
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
                                DuiklocatieViewModel vm = new DuiklocatieViewModel(customer, "FavorietenView");
                                FavorietenView view = new FavorietenView();
                                view.DataContext = vm;
                                view.Show();
                                Application.Current.Windows[0].Close();
                            }
                        }

                    }
                    catch (Exception)
                    {

                        Foutmelding = "Deze is al toegevoegd bij uw favorieten";
                    }

            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
