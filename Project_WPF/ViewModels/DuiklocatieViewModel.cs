using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_DAL;
using Project_DAL.Data.UnitOfWork;
using Project_DAL.DomainModels;
using Project_WPF.Views;

namespace Project_WPF.ViewModels
{
    public class DuiklocatieViewModel : BasisViewModel, ICommand,  IDisposable
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new DuiklocatiesBeheerEntities());

        private Location selectedLocation;

        public ObservableCollection<Location> Locations { get; set; }

        public Location SelectedLocation
        {
            get => selectedLocation;
            set
            {
                selectedLocation = value;
                
            }
        }

        public override string this[string columnName] => throw new NotImplementedException();
        public DuiklocatieViewModel()
        {
            Locations = new ObservableCollection<Location>(unitOfWork.LocationRepo.Ophalen(x => x.Category, x => x.Preview));
        }


        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
            }
            return true;
        }


        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
            }
        }
        public void OpenDashboard()
        {
            DashboardViewModel vm = new DashboardViewModel();
            DashboardView view = new DashboardView();
            view.DataContext = vm;
            view.Show();
        }
        private void OpenLocationWindow()
        {

            GekozenDuiklocatieView location = new GekozenDuiklocatieView();
            GekozenDuiklocatieViewModel gekozenDuiklocatieViewModel = new GekozenDuiklocatieViewModel(selectedLocation.LocationID);
            location.DataContext = gekozenDuiklocatieViewModel;
            location.Show();
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
