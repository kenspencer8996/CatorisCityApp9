using CatorisCityAppNew.Viewmodels;

namespace CatorisCityAppNew.Objects
{

    public class BadPersonMoveFiredEventArg
    {
        public bool MoveNext = false;
        public double _x;
        public double _y;
        public PersonViewModel Badguy;
       public BadPersonMoveFiredEventArg(double x, double y,PersonViewModel badguy)
        {
            _x = x;
            _y = y;
            Badguy = badguy;
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
