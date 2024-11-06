using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatorisCityAppNew.Objects
{
    internal class PersonViewModel
    {
        decimal _currentPay;
        IDispatcherTimer _showTimer;
        IDispatcherTimer _payTimer;
        HouseContent _host;
        private Int32 _personId;
        private string _currentImage;
        public string CurrentImage
        {
            get { return _currentImage; }
            set { _currentImage = value; }
        }
        public Int32 PersonId
        {
            get { return _personId; }
            set
            {
                if (_personId != value)
                {
                    _personId = value;
                }
            }
        }
        public bool IsUser
        {
            get
            {
                return _IsUser;
            }
            set
            {
                _IsUser = value;
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
        PersonEntity Person { get; set; } = new PersonEntity();

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

        private bool _IsUser = false;
        private decimal _Funds = 0;
        public object Host { get; set; }
        public Type HostType { get; set; }
        private PersonEnum _PersonRole = PersonEnum.Individual;
        private int _TimerSeconds = 49;
        private int _currentImageKey = 0;
        private bool _active = false;
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

    
    }
}
