using BDSA2015.Lecture11.Universal.Models;
using System.Collections.ObjectModel;

namespace BDSA2015.Lecture11.Universal.ViewModels
{
    public class DucksViewModel : BaseViewModel
    {
        public ObservableCollection<Duck> Ducks { get; private set; }

        public DucksViewModel()
        {
            Ducks = new ObservableCollection<Duck>(Duck.All);
        }
    }
}
