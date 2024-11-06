using CatorisCityAppNew.Views.Controls.Car;

namespace CatorisCityAppNew.Objects
{
    public class careventArg
    {
        public careventArg(CarContent Car)
        { 
            this.Car = Car;
        }
        public CarContent Car { get; set; }
    }
}
