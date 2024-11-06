using CityAppServices.Objects.database;
using CityAppServices.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatorisCityAppNew.Objects.Services
{
    internal class ImageService
    {
        ImageRepository repository = new ImageRepository();
        public async Task<List<ImageDetailEntity>> GetImagesAsync()
        {
            List<ImageDetailEntity> results = new List<ImageDetailEntity>();
            try
            {
                results = await repository.GetImagesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return results;
        }
        public async Task<ImageDetailEntity> GetImagebyNameAsync(string name)
        {
            ImageDetailEntity result = new ImageDetailEntity();
            try
            {
                result = await repository.GetImageByNameAsync(name);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public void UpsertSetting(ImageDetailEntity Setting)
        {
            try
            {
                repository.UpsertImage(Setting);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
