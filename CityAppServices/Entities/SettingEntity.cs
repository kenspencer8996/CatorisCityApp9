namespace CityAppServices.Objects.Entities
{
    public class SettingEntity
    {
        public SettingEntity() { }
        public SettingEntity(string name,string stringSetting, int intSetting) 
        {
            Name = name;
            StringSetting = stringSetting;
            IntSetting = intSetting;
        }

        public int SettingID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StringSetting { get; set; } = string.Empty;
        public int IntSetting { get; set; } = 0;
    }
}
