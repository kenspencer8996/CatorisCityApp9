using CatorisCityAppNew.Views.Controls.Business;
using CityAppServices.Objects;

namespace CatorisCityAppNew.Objects
{
    public class PoliceCarMoveFiredEventArg
    {
        public string RobberName;
        public BusinessContent Business;
       public PoliceCarMoveFiredEventArg(string robberName, BusinessContent business)
        {
            RobberName = robberName;
            Business = business;
        }

        public LocationXYEntity LocationXY { get; internal set; }
        public Rect GetRectCoordinates()
        {
            Rect locRec = new Rect();
            locRec.X = LocationXY.x;
            locRec.Y = LocationXY.y;
            locRec.Height = AbsoluteLayout.AutoSize;
            locRec.Width = AbsoluteLayout.AutoSize;
            return locRec;
        }
    }
}
