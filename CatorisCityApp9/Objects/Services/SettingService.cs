using CityAppServices.Objects.database;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Objects.Services
{
    internal class SettingService
    {
       SettingsRepository repository= new SettingsRepository();
        public List<SettingEntity> GetSetting()
        {
            List<SettingEntity> Setting = new List<SettingEntity>();
            try
            {
                Setting = repository.GetSetting();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Setting;
        }
        public SettingEntity GetSettingbyName(string name)
        {
            SettingEntity Settingout = new SettingEntity();
            try
            {
                Settingout = repository.GetSettingbyName(name);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Settingout;
        }

        public void UpsertSetting(SettingEntity Setting)
        {
                try
                {
                    repository.UpsertSetting(Setting);
                }
                catch (Exception ex)
                {

                    throw;
                }
               
            
        }
    }
}

