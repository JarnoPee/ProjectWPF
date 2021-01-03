using Project_DAL.DomainModels;
using Project_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_WPF.ViewModels
{
    class DuiklocatieToevoegenViewModel : BasisViewModel
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

        public DuiklocatieToevoegenViewModel(int locationID, Customer customer)
        {
            this.customer = customer; ;
            Location = unitOfWork.LocationRepo.Ophalen(x => x.LocationID == locationID, x => x.Category, x => x.Preview, x => x.Description).SingleOrDefault();
            Naam = Location.Naam;
            Land = Location.Land;
            Prijs = Location.Prijs;
            Straat = Location.Straat;
            Gemeente = Location.Stad;
            Diepte = Location.Diepte;
            Huisnummer = Location.Huisnummer;
            Categorie = Location.Category.Naam;
            PreviewBeschrijving = Location.Preview.Beschrijving;
            DescriptionBeschrijving = Location.Description.Beschrijving;

        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Gemeente" && string.IsNullOrEmpty(Gemeente))
                {
                    return "De gemeente moet ingevuld worden!" + Environment.NewLine;
                }
                return "";
            }
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
                case "LocatieVerwijderen": return true;
                case "LocatieToevoegenOfAanpassen": return true;
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
        private void LocatieToevoegenOfAanpassen()
        {
            if (Location.IsGeldig())
            {
                if (Location.LocationID > 0)
                {
                    unitOfWork.LocationRepo.Aanpassen(Location);
                    MessageBox.Show("De locatie is succesvol aangepast");
                }
                else
                {
                    unitOfWork.LocationRepo.Toevoegen(Location);
                    MessageBox.Show("De locatie is succesvol toegevoegd");
                }

                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    DuiklocatieViewModel vm = new DuiklocatieViewModel(customer);
                    DuiklocatieView view = new DuiklocatieView();
                    view.DataContext = vm;
                    view.Show();
                    Application.Current.Windows[0].Close();
                }
            }
        }
        private void LocatieVerwijderen()
        {
                unitOfWork.LocationRepo.Verwijderen(Location);
                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    DuiklocatieViewModel vm = new DuiklocatieViewModel(customer);
                    DuiklocatieView view = new DuiklocatieView();
                    view.DataContext = vm;
                    view.Show();
                    Application.Current.Windows[0].Close();
                }
            
        }

    }
}
