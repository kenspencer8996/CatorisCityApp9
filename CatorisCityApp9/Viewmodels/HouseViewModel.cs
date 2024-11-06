using CatorisCityAppNew.Views.Controls.House;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Viewmodels
{
    public class HouseViewModel:ViewmodelBase
    {
        IDispatcherTimer _showTimer;
        IDispatcherTimer _payTimer;
        public HouseContent Host { get; set; }

        private bool _isVisible = true;
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }
        private string _Name;
        private bool _IsUserHouse;
        private string _imageFileName;
        private string _imageLivingRoomFileName;
        private string _imageKitchenFileName;
        private string _imageGarageFileName;
        private string _ownerName;

        public int HouseID { get; set; }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string OwnerName

        {
            get
            {
                return _ownerName;
            }
            set
            {
                _ownerName = value;
            }
        }
        public bool IsUserHouse
        {
            get
            {
                return _IsUserHouse;
            }
            set
            {
                _IsUserHouse = value;
            }
        }


        public string NameAsControlName
        {
            get
            {
                return _Name.Replace(" ", "");
            }

        }
        public string ImageFileName
        {
            get
            {
                return _imageFileName;
            }
            set
            {
                _imageFileName = value;
            }
        }
        public string ImageLivingRoomFileName
        {
            get
            {
                return _imageLivingRoomFileName;
            }
            set
            {
                _imageLivingRoomFileName = value;
            }
        }


        public string ImageKitchenFileName
        {
            get
            {
                return _imageKitchenFileName;
            }
            set
            {
                _imageKitchenFileName = value;
            }
        }
        public string ImageGarageFileName
        {
            get
            {
                return _imageGarageFileName;
            }
            set
            {
                _imageGarageFileName = value;
            }
        }
        public HouseEntity GetEntity()
        {
            HouseEntity entity = new HouseEntity();
            entity.HouseID = HouseID;
            entity.ImageKitchenFileName = ImageKitchenFileName;
            entity.ImageGarageFileName= ImageGarageFileName;
            entity.ImageLivingRoomFileName= ImageLivingRoomFileName;
            entity.Name = _Name;
            entity.OwnerName = OwnerName;
            return entity;
        }
        public void ToModel(HouseEntity entity)
        {
            HouseID = entity.HouseID;
            ImageKitchenFileName = entity.ImageKitchenFileName;
            ImageGarageFileName = entity.ImageGarageFileName ;
            ImageLivingRoomFileName = entity.ImageLivingRoomFileName  ;
            OwnerName = entity.OwnerName ;
            _Name = entity.Name;
        }

    }
}
