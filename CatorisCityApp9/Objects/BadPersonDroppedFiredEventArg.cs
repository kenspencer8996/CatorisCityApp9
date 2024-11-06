using CatorisCityAppNew.Viewmodels;

namespace CatorisCityAppNew.Objects
{
    public class BadPersonDroppedFiredEventArg
    {
       private int _badpersonnumber;
        private PersonViewModel _badguy;

        public BadPersonDroppedFiredEventArg(int badpersonnumber,PersonViewModel badguy)
        {
            _badpersonnumber = badpersonnumber;
            _badguy = badguy;
        }
        public int BadPersonNumber
        { get { return _badpersonnumber; } }
        public PersonViewModel Badguy
        { get { return _badguy; } }
    }
}
