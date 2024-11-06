namespace CityAppServices.Objects.Entities
{
    public class PersonEntity
    {
        private string _Name = "";
        private int _personId = 0;
        private decimal _currentPay;
        private string _currentImage;
        private int _currentImageKey;
        private PersonEnum _personRole;
        public decimal Funds;
        public bool Active { get; set; }
        public bool IsUser { get; set; }
        public string Name
        { 
            get
                { return _Name; }
            set { _Name = value; }
        }

        public string CurrentImage
        {
            get
            {
                return _currentImage;
            }
            set
            {
                _currentImage = value;
            }
        }
        public int PersonId
        {
            get
            {
                return _personId;
            }
            set
            {
                _personId = value;
            }
        }
    
        public int CurrentImageKey
        {
            get
            {
                return _currentImageKey;
            }
            set
            {
                _currentImageKey = value;
            }
        }

        public PersonEnum PersonRole
        {
            get
            {
                return _personRole;
            }
            set
            {
                _personRole = value;
            }
        }
        public void Add(string name, decimal funds,
            PersonEnum role)
        {
            _Name = name;
            Funds = funds;
            _personRole = role;
        }

        public List<PersonImageEntity> Images { get; set; } = new List<PersonImageEntity>();
        public void AddPersonImage(PersonImageEntity image)
        {
            Images.Add(image);
        }
    }
}
