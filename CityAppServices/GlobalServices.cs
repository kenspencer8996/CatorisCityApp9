using CityAppServices.Objects.database;
using CityAppServices.Objects.Entities;

namespace CityAppServices
{
    public class GlobalServices
    {
        public static List<SettingEntity> Settings { get; set; } = new List<SettingEntity>();
        public static void LoadSettings()
        {
            Settings = SettingsRepository.GetSetting();
        }
        public static PersonImageRepository ImageRepository;
        public static PersonRepository PersonRepository;
        public static BusinessRepository BusinessRepository;
        public static HouseRepository HouseRepository;
        public static PersonImageRepository PersonImageRepository;
        public static ImageRepository imageRepository;
        public static SettingsRepository SettingsRepository;
        public static void CreateInstances()
        {
            AdoNetHelper adoNetHelper = new AdoNetHelper();
            PersonRepository = new PersonRepository();
            ImageRepository = new PersonImageRepository();
            BusinessRepository = new BusinessRepository();
            HouseRepository = new HouseRepository();
            SettingsRepository = new SettingsRepository();
            PersonImageRepository = new PersonImageRepository();
        }

        public static SettingEntity GetSettingByName(string name)
        {
            SettingEntity setting = new SettingEntity();
            var found = from s in Settings where s.Name == name select s;
            if (found != null && found.Any())
            {
                setting = found.First();
            }
            if (setting.IntSetting == 0)
                setting.IntSetting = 1;

            return setting;
        }
        public static SettingEntity GettingSetting(string settingName)
        {
            SettingEntity result = new SettingEntity();
            var settingfound = from s in Settings where s.Name == settingName select s;
            if (settingfound != null && settingfound.Any())
            {
                result = settingfound.FirstOrDefault();
            }
            return result;
        }
        public static void UpdateUISettings(int TravelSpeed,int CampFire,
           int BadguyCount,int PoliceCarSpeed)
        {
            GlobalServices.InsertSetting("travelspeed", "", TravelSpeed);
            GlobalServices.InsertSetting("campfire", "", CampFire);
            GlobalServices.InsertSetting("badguycount", "", BadguyCount);
            GlobalServices.InsertSetting("policecarspeed", "", PoliceCarSpeed);
        }
            
        public static void InsertHouse(string name, string imagenme, string living, string kitchen, string garage, bool isUserHouse, string OwnerName)
        {
            HouseEntity house1 = new HouseEntity(name, imagenme, living, kitchen, garage, OwnerName, isUserHouse);
            HouseRepository.UpsertHouse(house1);

        }
        public static void InsertSetting(string name, string stringSetting, int intSetting)
        {
            SettingEntity setting = new SettingEntity(name, stringSetting, intSetting);
            SettingsRepository.UpsertSetting(setting);
        }
        public static void InsertBusiness(string name, decimal payrate,
            string imagenme, BusinessTypeEnum businessType)
        {
            BusinessEntity bus1 = new BusinessEntity();
            bus1.Add(name, payrate, imagenme, businessType);
            BusinessRepository.UpsertBusiness(bus1);

        }
        public static async Task<PersonEntity> InsertPersonAsync(string name,
            bool isUser, PersonEnum personRole, string currentImage)
        {
            PersonEntity personEntity = new PersonEntity();
            personEntity.Name = name;
            //personEntity.IsUser = false;
            personEntity.PersonRole = personRole;
            personEntity.CurrentImage = currentImage;
            PersonEntity newpersonEntity = await PersonRepository.UpsertPerson(personEntity);

            return newpersonEntity;
        }
        public static void InsertPersonImage(string Name, PersonImageTypeEnum personImageType, PersonImageStatusEnum PersonImageStatus,
         string FilePath, string ImageType,
         int fkpersonId)
        {
            PersonImageEntity image1 = new PersonImageEntity();
            image1.Add(Name, personImageType, PersonImageStatus,
            FilePath, ImageType, fkpersonId);
            PersonImageRepository.UpsertPersonImage(image1);
        }
        public static void InsertImage(string Name, int imageId, string NamePart,
       string FilePath, int NumberPart, int SequenceNumber, string TrailingPart,
       ImageEnum ImageRole)
        {
            ImageDetailEntity image1 = new ImageDetailEntity();

            image1.ImageId = imageId;
            image1.FilePath = FilePath;
            image1.Name = Name;
            image1.NamePart = NamePart;
            image1.NumberPart = NumberPart;
            image1.SequenceNumber = SequenceNumber;
            image1.TrailingPart = TrailingPart;
            image1.ImageRole = ImageRole;
            imageRepository.UpsertImage(image1);
        }

    }

}
