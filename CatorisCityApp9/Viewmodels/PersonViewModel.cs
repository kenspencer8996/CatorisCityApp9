
using CatorisCityAppNew.Objects;
using CatorisCityAppNew.Views.Controls.Business;
using CatorisCityAppNew.Views.Controls.House;
using CityAppServices.Objects;
using CityAppServices.Objects.Entities;
using CommunityToolkit.Mvvm.Messaging;
using System.ComponentModel;
namespace CatorisCityAppNew.Viewmodels
{
    public class PersonViewModel 
    {
        private decimal _currentPay;
        private HouseContent _host;
        private int _personId;
        private string _currentImage;
        private IDispatcherTimer _payTimer;
        private IDispatcherTimer _showTimer;
        IDispatcherTimer _badGuyMoveTimer;
        IDispatcherTimer _badGuyEscapeMoveTimer;
        int _personNumber = 0;
        int _iterationForPaths = 0;
        int _iterationForEscapePaths = 0;
        LocationEnum currentPathLocation = LocationEnum.None;
        bool _TimerFired = false;
        int _timerSeconds = 10;
        int _timerEscapeSeconds = 10;
        LocationEnum _lastMovePath = 0;
        private ObjectLocationPathEntity currentPath;
        private ObjectLocationPathEntity currentEscapePath;
        public event EventHandler<PersonTimerFiredEventArg> ShowPersonTimerFired;
        public CampfireLocationEntity CampfireLocation {  get; set; }
        public List<int> CampFirePath  { get; set; }
        public double lastlocationX { get; set; }
        public double lastlocationY { get; set; }
        public PersonViewModel()
        {

        }
        public List<PersonImageEntity> Images { get; set; } = new List<PersonImageEntity>();
        private void ResetCounters()
        {
            _iterationForPaths = 0;
        }
        
        
       

        public bool IsUser
        {
            get
            {
                return _isUser;
            }
            set
            {
                _isUser = value;
                OnPropertyChanged("IsUser");
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
                OnPropertyChanged("PersonId");
            }
        }

        public decimal Funds
        {
            get
            {
                return _Funds;
            }
            set
            {
                _Funds = value;
                OnPropertyChanged("Funds");
            }
        }

        public void StartPay(decimal payRate)
        {
            _currentPay = payRate;
            _payTimer.Start();
        }
        public void LeaveWork()
        {
            _currentPay = 0;
            _payTimer.Stop();
        }
        private void PaytimerFired()
        {
            Funds += _currentPay;
        }

        private void ShowTimerfired()
        {
            _host.IsVisible = true;
            PersonTimerFiredEventArg ev = new PersonTimerFiredEventArg(this);
            ShowPersonTimerFired(this, ev);
        }

        private string _name = "";

        private bool _isUser = false;
        private decimal _Funds = 0;
        public object Host { get; set; }
        public Type HostType { get; set; }
        private PersonEnum _PersonRole = PersonEnum.Individual;
        private int _TimerSeconds = 49;
        private int _currentImageKey = 0;
        private bool _active = false;
        public PersonEnum PersonRole
        {
            get
            {
                return _PersonRole;
            }
            set
            {
                _PersonRole = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
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
        public PersonEnum PersonType { get; set; }
        public bool Girl { get; set; }
        public void Add(string name, bool girl, PersonEnum personType)
        {
            Name = name;
            PersonType = personType;
            Girl = girl;
        }
        public List<PersonViewModel> Friends { get; set; }

        public PersonEntity GetEntity()
        {
            PersonEntity person = new PersonEntity();
            person.PersonId = _personId;
            person.PersonRole = _PersonRole;
            person.Active = _active;
            person.CurrentImageKey = _currentImageKey;
            person.CurrentImage = _currentImage;
            person.IsUser = _isUser;
            person.Name = _name;
            return person;
        }
        public void ToModel(PersonEntity person)
        {
            _personId = person.PersonId;
            _PersonRole = person.PersonRole;
            _active = person.Active;
            _currentImageKey = person.CurrentImageKey;
            _currentImage = person.CurrentImage;
            _isUser = person.IsUser;
            _name = person.Name;
        }
        public void StopTimer()
        {
            if (_badGuyMoveTimer != null)
                _badGuyMoveTimer.Stop();

        }
        public event PropertyChangedEventHandler? PropertyChanged;


        public void OnPropertyChanged(string propertyName)
        {
            if (Global.Loading == false)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       
  
    }

}