using CatorisCityAppNew.Viewmodels;

namespace CatorisCityAppNew.Objects
{
    public class PersonTimerFiredEventArg
    {
        public PersonViewModel Person { get; set; }
        public PersonTimerFiredEventArg(PersonViewModel person)
        {
            Person = person;
        }
    }
}
