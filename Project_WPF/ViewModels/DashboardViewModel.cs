using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_WPF.Views;

namespace Project_WPF.ViewModels
{
    public class DashboardViewModel : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "DuiklocatiesBekijken": return true;
                case "AccountInstellingen": return true;
                case "DuiklocatieToevoegen": return true;
                case "Favorieten": return true;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "DuiklocatiesBekijken": OpenDuiklocaties(); break;
                case "AccountInstellingen": OpenAccount(); break;
                case "DuiklocatieToevoegen": OpenDuiklocatieToevoegen(); break;
                case "Favorieten": OpenFavorieten(); break;
            }
        }
        public void OpenDuiklocaties()
        {
            DuiklocatieViewModel vm = new DuiklocatieViewModel();
            DuiklocatieView view = new DuiklocatieView();
            view.DataContext = vm;
            view.Show();
        }
        public void OpenAccount()
        {
            AccountViewModel vm = new AccountViewModel();
            AccountView view = new AccountView();
            view.DataContext = vm;
            view.Show();
        }
        public void OpenDuiklocatieToevoegen()
        {
            DuiklocatieToevoegenViewModel vm = new DuiklocatieToevoegenViewModel();
            DuiklocatieToevoegenView view = new DuiklocatieToevoegenView();
            view.DataContext = vm;
            view.Show();
        }
        public void OpenFavorieten()
        {
            FavorietenViewModel vm = new FavorietenViewModel();
            FavorietenView view = new FavorietenView();
            view.DataContext = vm;
            view.Show();
        }

    }
}
