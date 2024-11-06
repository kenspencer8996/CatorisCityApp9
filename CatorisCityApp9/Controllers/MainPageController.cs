using CatorisCityAppNew.Views.Controls.Car;
using CatorisCityAppNew.Objects;
using CityAppServices;
using CityAppServices.Objects.database;

namespace CatorisCityAppNew.Controllers
{
    public class MainPageController
    {
        MainPage _view;
        public MainPageController(MainPage view)
        {
            _view = view;
        }

        internal void Startup()
        {
            GlobalServices.CreateInstances();
            GlobalServices.LoadSettings();
            SampleData.CreateSampleUsers();

            ResourceHelper.GetImages();
            StartupAsync();
        }

        private void StartupAsync()
        {
            LoadCars();
            
        }

        private void LoadCars()
        {
            CarContent car1 = new CarContent("Sports", "autospportcarfitst.png", "$4000");
            car1.CarBoughtEvent += Car_CarBoughtEvent;
            CarContent car2 = new CarContent("Truck", "autotruck.png", "$3000");
            car2.CarBoughtEvent += Car_CarBoughtEvent;
            //_view.AddCar(car1);
            //_view.AddCar(car2);

  
        }
        private void Car_CarBoughtEvent(object? sender, careventArg e)
        {

        }
    }
}
