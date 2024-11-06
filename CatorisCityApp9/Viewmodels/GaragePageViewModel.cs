using CatorisCityAppNew.Views.Controls.House;

namespace CatorisCityAppNew.Viewmodels
{
    public class GaragePageViewModel: ViewmodelBase
    {
        public HouseContent House { get; set; }
        public string GarageImage
        {
            get
            {
                return House.ImageGarageFileName;
            }
        }
    }
}
