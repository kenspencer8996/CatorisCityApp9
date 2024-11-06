using CatorisCityAppNew.Viewmodels;
using CityAppServices.Objects.database;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Objects.Services
{
    internal class HouseService
    {
        HouseRepository repository = new HouseRepository();
        public async Task<List<HouseViewModel>> GetHousesAsync()
        {
            List<HouseEntity> results = new List<HouseEntity>();
            List<HouseViewModel> models = new List<HouseViewModel>();
            try
            {
                results = await repository.GetHousesAsync();
                foreach (HouseEntity entity in results)
                {
                    HouseViewModel model = new HouseViewModel();
                    model.House = entity;
                    models.Add(model);
            }
            }
            catch (Exception ex)
            {
                throw;
            }
            return models;
        }
        public async Task<HouseEntity> GetHousebyNameAsync(string name)
        {
            HouseEntity result = new HouseEntity();
            try
            {
                result = await repository.GetHousebyNameAsync(name);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public void UpsertSetting(HouseEntity Setting)
        {
            try
            {
                repository.UpsertHouse(Setting);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
