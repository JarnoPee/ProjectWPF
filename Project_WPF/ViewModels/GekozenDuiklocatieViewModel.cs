using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_WPF.Views;

namespace Project_WPF.ViewModels
{
    public class GekozenDuiklocatieViewModel : ICommand
    {
        private int locationID;

        public GekozenDuiklocatieViewModel(int locationID)
        {
            
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
            }
            return true;
        }

        public void Execute(object parameter)
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
    }
}
