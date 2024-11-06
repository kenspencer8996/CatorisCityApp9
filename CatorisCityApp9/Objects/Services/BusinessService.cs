using CatorisCityAppNew.Viewmodels;
using CityAppServices.Objects.database;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Objects.Services
{
    internal class BusinessService
    {
        BusinessRepository repository = new BusinessRepository();
        public async Task<List<BusinessViewModel>> GetBusinesssAsync()
        {
            List<BusinessViewModel> results = new List<BusinessViewModel>();
            List<BusinessViewModel> models = new List<BusinessViewModel>();
            try
            {
                results = await repository.GetBusinesssAsync();
                foreach (BusinessViewModel business in results)
                {
                    BusinessViewModel model = new BusinessViewModel();
                    model.Business = business;
                    models.Add(model);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return models;
        }
        public async Task<BusinessViewModel> GetBusinessbyNameAsync(string name)
        {
            BusinessViewModel Settingout = new BusinessViewModel();
            BusinessViewModel businessViewModel = new BusinessViewModel();
            try
            {
                Settingout = await repository.GetBusinessbyNameAsync(name);
                businessViewModel.Business = Settingout;
            }
            catch (Exception ex)
            {
                throw;
            }
            return businessViewModel;
        }

        public void UpsertSetting(BusinessViewModel Setting)
        {
            try
            {
                repository.UpsertBusiness(Setting);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
    }
}

