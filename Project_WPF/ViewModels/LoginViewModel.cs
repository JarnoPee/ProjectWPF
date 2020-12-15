using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_WPF.Views;

namespace Project_WPF.ViewModels
{
    public class LoginViewModel : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Dashboard": return true;
                case "Registreren": return true;
                case "Aanmelden": return true;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Dashboard": OpenDashboard(); break;
                case "Registreren": OpenRegistreren(); break;
            }
        }
        public void OpenDashboard()
        {
            DashboardViewModel vm = new DashboardViewModel();
            DashboardView view = new DashboardView();
            view.DataContext = vm;
            view.Show();
        }
        public void OpenRegistreren()
        {
            RegistrerenViewModel vm = new RegistrerenViewModel();
            RegistrerenView view = new RegistrerenView();
            view.DataContext = vm;
            view.Show();
        }
    }
}
