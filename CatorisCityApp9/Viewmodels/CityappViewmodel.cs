using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Viewmodels
{
    public class CityappViewmodel
    {
        public int CityAppNumber { get; set; }
        public List<BusinessViewModel> Businesses { get; set; } = new List<BusinessViewModel>();

        //public List<BadPersonViewModel> BadPersons { get; set; } = new List<BadPersonViewModel>();
        public List<PersonViewModel> Persons { get; set; } = new List<PersonViewModel>();
        public List<PersonImageEntity> PersonImages { get; set; } = new List<PersonImageEntity>();
        //  public List<ResidenceEntity> Residences { get; set; } = new List<ResidenceEntity>();
        //public List<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();
        public List<HouseViewModel> Houses { get; set; } = new List<HouseViewModel>();

    }
}
