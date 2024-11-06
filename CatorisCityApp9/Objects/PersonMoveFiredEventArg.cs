using CatorisCityAppNew.Viewmodels;

namespace CatorisCityAppNew.Objects
{

    public class PersonMoveFiredEventArg
    {
        public bool MoveNext = false;
        public double _x;
        public double _y;
        public PersonViewModel Person;
       public PersonMoveFiredEventArg(double x, double y,PersonViewModel person)
        {
            _x = x;
            _y = y;
            Person = person;
        }
        public Rect GetRectCoordinates()
        {
            Rect locRec = new Rect();
            locRec.X = _x;
            locRec.Y = _y;
            locRec.Height = AbsoluteLayout.AutoSize;
            locRec.Width = AbsoluteLayout.AutoSize;
            return locRec;
        }
    }
}
