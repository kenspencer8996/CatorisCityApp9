namespace CityAppServices.Objects.Entities
{
    public class HouseEntity
    {
        //MainPage _host;
        public HouseEntity()
        {

        }
        public HouseEntity(string Name, string imageFileName,
            string imageLivingFileName, string imageKitchenFileName,
            string imageGarageFileName, string ownerName,
            bool IsUserHouse)
        {
            _Name = Name;
            _IsUserHouse = IsUserHouse;
            _imageFileName = imageFileName.ToLower();
            ImageLivingRoomFileName = imageLivingFileName.ToLower();
            ImageKitchenFileName = imageKitchenFileName.ToLower();
            ImageGarageFileName = imageGarageFileName.ToLower();
            OwnerName = ownerName;
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
    }
}
