using CatorisCityAppNew.Viewmodels;

namespace CatorisCityAppNew.Objects
{
    public class BadPersonTimerFiredEventArg
    {
        public CatorisCityAppNew.Viewmodels.PersonViewModel Person { get; set; }
        public BadPersonTimerFiredEventArg(PersonViewModel person)
        {
            Person = person;
        }
    }
}
