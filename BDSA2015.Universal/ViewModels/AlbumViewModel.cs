using BDSA2015.Universal.Model;
using System.Collections.ObjectModel;

namespace BDSA2015.Universal.ViewModels
{
    public class AlbumViewModel : BaseViewModel
    {
        private readonly AlbumRepository _repository;

        public ObservableCollection<Album> Albums { get; private set; }

        private Album _selectedAlbum;

        public Album SelectedAlbum
        {
            get { return _selectedAlbum; }
            set
            {
                _selectedAlbum = value;
                 OnPropertyChanged();
           }
        }

        public AlbumViewModel()
        {
            _repository = new AlbumRepository();
        }

        public void Initialize()
        {
            Albums = new ObservableCollection<Album>(_repository.Get());
        }

        public void SelectAlbum(Album album)
        {
            SelectedAlbum = album;
        }
    }
}
