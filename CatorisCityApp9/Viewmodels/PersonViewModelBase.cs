using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatorisCityAppNew
{
    internal class PersonViewModelBase
    {
        decimal _currentPay;
         HouseContent _host;
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

        private void ShowPersonTimerFired(PersonViewModel personViewModel, PersonTimerFiredEventArg ev)
        {
            throw new NotImplementedException();
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
        public PersonEnum PersonType { get; set; }
        public bool Girl { get; set; }
        public void Add(string name, bool girl, PersonEnum personType)
        {
            Person.Name = name;
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
            _active= person.Active;
            _currentImageKey = person.CurrentImageKey;
            _currentImage = person.CurrentImage;
            _isUser = person.IsUser;
            _name = person.Name;
        }
    }
}
