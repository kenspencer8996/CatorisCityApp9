using CityAppServices.Objects.database;
using CityAppServices.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatorisCityAppNew.Objects.Services
{
    internal class PersonImageService
    {
        PersonImageRepository repository = new PersonImageRepository();
        public async Task<List<PersonImageEntity>> GetPersonImagesAsync()
        {
            List<PersonImageEntity> results = new List<PersonImageEntity>();
            try
            {
                results = await repository.GetPersonImagesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return results;
        }
        public async Task<PersonImageEntity> GetPersonImagebyNameAsync(string name)
        {
            PersonImageEntity Settingout = new PersonImageEntity();
            try
            {
                Settingout = await repository.GetPersonImagebyNameAsync(name);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Settingout;
        }

        public void UpsertSetting(PersonImageEntity Setting)
        {
            try
            {
                repository.UpsertPersonImage(Setting);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

    }
}
