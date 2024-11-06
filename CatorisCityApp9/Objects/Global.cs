using CatorisCityAppNew.Viewmodels;
using CatorisCityAppNew.Views.Controls;
using CatorisCityAppNew.Views.Controls.Business;
using CityAppServices;
using CityAppServices.Objects;
using CityAppServices.Objects.Entities;
using System.Runtime.CompilerServices;

namespace CatorisCityAppNew.Objects
{

    public static class Global
    {
        public static CityStreetMasterViewModel _cityStreetMaster;
        public static MenuLayoutControl _menuControl;
        private static int _travelSpeed = -1;
        private static int _campfire = -1;
        private static int _campfireSleepTime = -1;
        private static int _policecarspeed = -1;
        private static int _badguycount = -1;
        private static int _alarmtime = -1;
        public static CityappViewmodel _cityApp {get;set;} = new   CityappViewmodel();
        public static int TravelSpeed
        {
            set
            {
                _travelSpeed = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_travelSpeed == -1)
                {
                    ret = GlobalServices.GetSettingByName("travelspeed");
                }
                return ret.IntSetting;
            }
        }
        public static int CampFire
        {
            set
            {
                _campfire = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_campfire == -1)
                {
                    ret = GlobalServices.GetSettingByName("campfire");
                }
                return ret.IntSetting;
            }
        }
        public static int CampFireSleepTime
        {
            set
            {
                _campfireSleepTime = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_campfireSleepTime == -1)
                {
                    ret = GlobalServices.GetSettingByName("campfiresleeptime");
                }
                return ret.IntSetting;
            }
        }
        public static int BadguyCount
        {
            set
            {
                _badguycount = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_badguycount == -1)
                {
                    ret = GlobalServices.GetSettingByName("badguycount");
                }
                return ret.IntSetting;
            }
        }
        public static int PoliceCarSpeed
        {
            set
            {
                _policecarspeed = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_policecarspeed == -1)
                {
                    ret = GlobalServices.GetSettingByName("policecarspeed");
                }
                return ret.IntSetting;
            }
        }
        public static int AlarmTime
        {
            set
            {
                _alarmtime = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_alarmtime == -1)
                {
                    ret = GlobalServices.GetSettingByName("aninationTime");
                }
                return ret.IntSetting;
            }
        }

        private static int GetLotNumber(string targetLots, string name)
        {
            int rInt = 0;
            Random random = new Random();
            if (name == "Catories")
            {
                var allowedLots = Global.Lots.Where(u => u.StreetName == "You St"
                && u.ContentName == "" &&
                u.lotPosition == LotPositionEnum.TopSide).ToList();
                if (allowedLots.Any())
                    rInt = allowedLots.FirstOrDefault().LotNumber;
                else
                {
                    var lots = from l in Global.Lots
                               where
                               l.ContentName == null
                               || l.ContentName == ""
                               select l;
                    if (lots.Any())
                        rInt = lots.First().LotNumber;
                }
            }
            else if (name == "123 Bank" || name == "Jones Fin.")
            {
                var allowedLots = Global.Lots.Where(u => u.StreetName == "Mik Ave"
                    && u.ContentName == "" &&
                    u.lotPosition == LotPositionEnum.LeftSide).ToList();
                if (allowedLots.Any())
                    rInt = allowedLots.FirstOrDefault().LotNumber;
                else
                {
                    var lots = from l in Global.Lots
                               where
                               l.ContentName == null
                               || l.ContentName == ""
                               select l;
                    if (lots.Any())
                        rInt = lots.First().LotNumber;
                }
            }
            else if (name == "PoliceStation")
            {
                var allowedLots = Global.Lots.Where(u => u.StreetName == "You St"
                    && u.ContentName == "" &&
                    u.lotPosition == LotPositionEnum.TopSide).ToList();
                if (allowedLots.Any())
                    rInt = allowedLots.LastOrDefault().LotNumber;
                else
                {
                    var lots = from l in Global.Lots
                               where
                               l.ContentName == null
                               || l.ContentName == ""
                               select l;
                    if (lots.Any())
                        rInt = lots.First().LotNumber;
                }
            }
            {
                var arr = targetLots.Split(',');
                var allowedLots = Global.Lots.Where(u => arr.Contains(u.StreetName)
                    && u.ContentName == "").ToList();

                if (allowedLots.Count > 0)
                {
                    rInt = random.Next(0, allowedLots.Count() - 1);
                    LotEntity lot = allowedLots[rInt];
                    rInt = lot.LotNumber;
                }
            }
            //
            return rInt;
        }

        public static LotEntity GetLot(string targetLots, string name)
        {
            LotEntity result = new LotEntity();
            int lotNo = GetLotNumber(targetLots, name);
            if (lotNo > 0)
            {
                var found = from l in Global.Lots
                            where l.LotNumber == lotNo
                            select l;
                if (found != null && found.Any())
                {
                    result = found.First();
                }
            }
            //else
            //{
            //    bool keeprunning = true;
            //    int counter = Global.Lots.Count() - 1;
            //    do
            //    {
            //        if (Global.Lots[counter].ContentName == "")
            //        {
            //            result = Global.Lots[counter];
            //            keeprunning = false;
            //        }

            //        if (counter == 0)
            //            keeprunning = false;

            //        counter--;
            //    } while (keeprunning);
            //}

            result.ContentName = name;
            return result;
        }
        public static  void AddGovernment(BusinessContent bc)
        {
            LotEntity lot = GetLot(Global.GovStreets, "NA");
            bc.WidthRequest = Global.buildingsize;
            bc.HeightRequest = Global.buildingsize;
            lot.ContentName = "GovernmentContent";
            _cityStreetMaster.CityLayout.Add(bc);
            AbsoluteLayout.SetLayoutBounds(bc, new Rect(lot.x, lot.y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
        public static  void AddYouStreetLabel(int x, int y)
        {
            Label youst = new Label();
            youst.Text = "You Street";
            youst.HeightRequest = 20;
            youst.ZIndex = 99;
            Global.YouStStreetloc.x = x;
            Global.YouStStreetloc.y = y;
            _cityStreetMaster.CityLayout.Add(youst);
            AbsoluteLayout.SetLayoutBounds(youst, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
        public static  void AddTeaStreetLabel(int x, int y)
        {
            Label teast = new Label();
            teast.Text = "Tea Street";
            teast.HeightRequest = 20;
            teast.ZIndex = 99;
            teast.RotateTo(90);
            Global.TeaStStreetLoc.x = x;
            Global.TeaStStreetLoc.y = y;
            _cityStreetMaster.CityLayout.Add(teast);
            AbsoluteLayout.SetLayoutBounds(teast, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
        public static  void AddMikStreetLabel(int x, int y)
        {
            Label milkst = new Label();
            milkst.Text = "Mik Ave";
            milkst.HeightRequest = 20;
            milkst.ZIndex = 99;
            _cityStreetMaster.CityLayout.Add(milkst);
            Global.MikAveStreetLoc.x = x;
            Global.MikAveStreetLoc.y = y;
            AbsoluteLayout.SetLayoutBounds(milkst, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

        }
        public static  void AddYodelLaneLabel(int x, int y)
        {
            Label yodelst = new Label();
            yodelst.Text = "Yodel Lane";
            yodelst.HeightRequest = 20;
            yodelst.ZIndex = 99;
            yodelst.RotateTo(90);
            _cityStreetMaster.CityLayout.Add(yodelst);
            Global.YodelLaneStreetLoc.x = x;
            Global.YodelLaneStreetLoc.y = y;
            AbsoluteLayout.SetLayoutBounds(yodelst, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

        }
        public static  void AddMooDrLaneLabel(int x, int y)
        {
            Label moodr = new Label();
            moodr.Text = "Moo Dr";
            moodr.HeightRequest = 20;
            moodr.ZIndex = 99;
            moodr.RotateTo(90);
            _cityStreetMaster.CityLayout.Add(moodr);
            Global.MooDrStreetLoc.x = x;
            Global.MooDrStreetLoc.y = y;
            AbsoluteLayout.SetLayoutBounds(moodr, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
       
       // public static uint AninationTime = 10000;
       

        public static bool ShowLotOutlines = true;
        private static string mainDir = FileSystem.Current.AppDataDirectory;
        private static string fileName = "cityappconfig.json";
        private static string configpath = System.IO.Path.Combine(mainDir, fileName);
        public static bool ShowAllBordersIfAvailable = true;
        public static string HouseStreets = "You St";
        public static string FinancialStreets = "Yodel Lane";
        public static string FactoryStreets = "Tea St";
        public static string GovStreets = "Mik Ave";
        public static string PoliceStreets = "You St";
        public static bool Loading = true;
        public static string Burglaralarmfile = "";
        public static LotEntity PoliceStationLocation {  get; set; }
        public static LocationXYEntity YouStStreetloc =new LocationXYEntity();
        public static LocationXYEntity MooDrStreetLoc = new LocationXYEntity();
        public static LocationXYEntity YodelLaneStreetLoc = new LocationXYEntity();
        public static LocationXYEntity TeaStStreetLoc = new LocationXYEntity();
        public static LocationXYEntity MikAveStreetLoc= new LocationXYEntity();
        public static LotEntity PoliceStationLot;

        public static CityappViewmodel Cityapp { get; set; } = new CityappViewmodel();
        public static double screensizewidth;
        public static double screensizeheight;
        public static int buildingsize = 80;
        public static int BuildingLocationBuffer = 2;
        public static List<ObjectLocationPathEntity> PathsList = new List<ObjectLocationPathEntity>();
        public static List<ObjectLocationPathEntity> EscapePathsList = new List<ObjectLocationPathEntity>();
        public static int citybarn1x = 0;
        public static int citybarn1y = 0;
        public static int cityshed1x = 0;
        public static int cityshed1y = 0;
        public static int cityforest1x = 0;
        public static int cityforest1y = 0;
        public static int citybush1x = 0;
        public static int citybush1y = 0;
        public static int citybush2x = 0;
        public static int citybush2y = 0;
        public static int citytentx = 0;
        public static int citytenty = 0;

        public static int citybarn1Width;
        public static int citybarn1Height;
        public static int cityshed1Width;
        public static int cityshed1Height;
        public static int cityforestWidth ;
        public static int cityforestHeight ;
        public static int citybush1Width ;
        public static int citybush1Height ;
        public static int citybush2Width ;
        public static int citybush2Height ;
        public static bool OutputDebugging { get; set; } = true;
        public static void WriteDebugOutput(string message, [CallerMemberName] string callerMemberName = null)
        {
            if (OutputDebugging)
                System.Diagnostics.Debug.WriteLine(callerMemberName + ": " + message);

        }      
        //note on center calcs.
        //add 1/2 to x, subtrct 1/2 to y
        public static int cityforest1xCenter
        {
            get
            {
                int halfwidth = cityforestWidth / 2;
                return (cityforest1x + halfwidth + 150);            }
        }
        public static int cityforest1yCenter
        {
            get
            {
                int halfHeight = cityforestHeight / 2;
                int center = cityforest1y + halfHeight;
                center = center - 30;
                return (center);
            }
        }
        public static int citybarn1xCenter
        {
            get
            {
                int halfwidth = citybarn1Width / 2;
                return (citybarn1x + halfwidth);
            }
        }
        public static int citybarn1yCenter
        {
            get
            {
                int halfHeight = citybarn1Height;
                    int center = citybarn1y + halfHeight;
                center = center - 30;
                return (center);
            }
        }
        public static int cityshed1xCenter
        {
            get
            {
                int halfwidth = cityshed1Width / 2;
                return (cityshed1x + halfwidth);
            }
        }
        public static int cityshed1yCenter
        {
            get
            {
                int halfHeight = cityshed1Height;
                int center = cityshed1y + halfHeight;
                center = center - 30;
                return (center);
            }
        }
        public static int citybush1xCenter
        {
            get
            {
                int halfwidth = citybush1Width / 2;
                return (citybush1x + halfwidth);
            }
        }
        public static int citybush1yCenter
        {
            get
            {
                int halfHeight = citybush1Height / 2;
                return (citybush1y); //+ halfHeight);
            }

        }
        public static int citybush2xCenter
        {
            get
            { 
                int halfwidth = citybush2Width / 2;
                int center = citybush2x + halfwidth;
                center = center - 15;
                return (center);
            }
        }
        public static int citybush2yCenter
        {
            get
            {
                int halfHeight = citybush2Height / 2;
                int center = citybush2y + halfHeight;
                center = center - 35;
                return (center);
            }

        }
        public static ObjectLocationSizeInfoEntity GetImageInfo(Image img)
        {
            ObjectLocationSizeInfoEntity info = new ObjectLocationSizeInfoEntity();
            int imgwidth = 0;
            if (img.Width > 0)
                imgwidth = Convert.ToInt32(img.Width);
            else
                imgwidth = Convert.ToInt32(img.WidthRequest);
            int imgheight = 0;
            if (img.Height > 0)
                imgheight = Convert.ToInt32(img.Height);
            else
                imgheight = Convert.ToInt32(img.HeightRequest);
            info.width = imgwidth; 
            info.height = imgheight;
            info.width = imgwidth;
            info.height = imgheight;

            return info;
        }
        internal static List<LotEntity> Lots { get; set; } = new List<LotEntity>();
        public static int StreetWidth = 30;
        public static int StreetTopOffset = 125;
        public static int StreetOuterOffset = 120;
        public static int LotSizeNormal = 100;
        public static DeviceIdiom CurrentDeviceIdiom;
        public static List<CampfireLocationEntity> CampfireSpots { get; set; } = new List<CampfireLocationEntity>();
        public static LocationXYEntity CampFireApproachN = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachNW = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachW = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachSW = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachS = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachSE = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachE = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachNE = new LocationXYEntity();
        public static LocationXYEntity CampfireLocation { get; set; } = new LocationXYEntity();
        internal static List<ImageTypeEntity> HouseImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> VehicleSalesImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> RetailImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> FinancialImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> RoomImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> BadguyImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> PersonImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> VechileImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> CarlotImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> ClassroomImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> FactoryImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> GarageImageList { get; set; } = new List<ImageTypeEntity>();
        public static bool LogRuntimes { get; set; } = false;
        public static Logger Log;
        public static List<BusinessContent> Businesses = new List<BusinessContent>();
      
        private static void Addbusinessntity(
          string name, int payrate, BusinessTypeEnum businessType)
        {
            Random rand = new Random();
            BusinessViewModel busiess = new BusinessViewModel();
            ImageTypeEntity imageType = new ImageTypeEntity();
            int index;
            switch (businessType)
            {
                case BusinessTypeEnum.Government:
                    //int index = rand.Next(bus.Count);
                    //questions[index];
                    break;
                case BusinessTypeEnum.Retail:
                    index = rand.Next(Global.RetailImageList.Count);
                    if (index > -1 && Global.RetailImageList.Any())
                        imageType = Global.RetailImageList[index];
                    break;
                case BusinessTypeEnum.Financial:
                    index = rand.Next(Global.FinancialImageList.Count);
                    if (index > -1 && Global.FinancialImageList.Any())
                        imageType = Global.FinancialImageList[index];
                    break;
                case BusinessTypeEnum.Airport:
                    //index = rand.Next(RetailImages.Count);
                    //imageType = RetailImages[index];
                    break;
                case BusinessTypeEnum.Medical:
                    //index = rand.Next(RetailImages.Count);
                    //imageType = RetailImages[index];
                    break;
                case BusinessTypeEnum.Factory:
                    index = rand.Next(Global.FactoryImageList.Count);
                    if (index > -1 && Global.FactoryImageList.Any())
                        imageType = Global.FactoryImageList[index];
                    break;
                case BusinessTypeEnum.Carlot:
                    index = rand.Next(CarlotImageList.Count);
                    if (index > -1 && Global.CarlotImageList.Any())
                        imageType = Global.CarlotImageList[index];
                    break;
                default:
                    break;
            }
            busiess.Add(name, payrate, imageType.Name, businessType);
            Cityapp.Businesses.Add(busiess);

        }
        private static void AddPersonViewModel(string name, bool girl, PersonImageTypeEnum personImageType)
        {
            Random rand = new Random();
            PersonViewModel person = new PersonViewModel();
            PersonImageEntity personimage = new PersonImageEntity();
            int index;
            ImageTypeEntity image1 = new ImageTypeEntity();
            if (girl)
            {
                var foundGirls = from g in PersonImageList where g.Imagetype == ImageContentEnum.girl select g;
                index = rand.Next(foundGirls.Count());
                image1 = foundGirls.ElementAt(index);
            }
            else
            {
                if (personImageType != PersonImageTypeEnum.BadGuy)
                {
                }
                else
                {
                    var foundguys = from b in PersonImageList
                                    where b.Imagetype == ImageContentEnum.man
                                    select b;
                    index = 0;
                    index = rand.Next(foundguys.Count());
                    image1 = foundguys.ElementAt(index);
                }
            }
            personimage.Name = image1.Name.Replace(" ", "");
            personimage.FilePath = image1.Name;
            List<PersonImageEntity> personimages = new List<PersonImageEntity>();
            person.Add(name, girl, PersonEnum.Individual);
            Cityapp.Persons.Add(person);
        }
        private static void AddPersonViewModel(string name)
        {
            Random rand = new Random();
            PersonViewModel person = new PersonViewModel();
            // BadPersonImageEntity personimage = new BadPersonImageEntity();
            int index;
            ImageTypeEntity image1 = new ImageTypeEntity();
            var foundbadguys = from b in PersonImageList
                               where b.Imagetype == ImageContentEnum.badguy
                               select b;
            index = rand.Next(foundbadguys.Count());
            image1 = foundbadguys.ElementAt(index);
            //var foundbadguys = from b in cityapp.BadPersons where b.StartsWith("badguy") select b;
            //index = rand.Next(foundbadguys.Count());
            //image1 = foundbadguys.ElementAt(index);

        }


        public static int GetBuildingControlSize
        {
            get
            {
                int returnval = 120;
                if (CurrentDeviceIdiom == DeviceIdiom.Desktop)
                    returnval = 120;
                if (CurrentDeviceIdiom == DeviceIdiom.Tablet)
                    returnval = 100;
                if (CurrentDeviceIdiom == DeviceIdiom.Phone)
                    returnval = 80;


                return returnval;
            }
        }


      

        private static void CreateDefaultCityApp()
        {
            try
            {
                BusinessViewModel busiess = new BusinessViewModel();
                Addbusinessntity("4th 1st bank", 200, BusinessTypeEnum.Financial);
                Addbusinessntity("A bank", 210, BusinessTypeEnum.Financial);
                Addbusinessntity("My CU", 220, BusinessTypeEnum.Financial);

                Addbusinessntity("Iron W", 140, BusinessTypeEnum.Factory);
                Addbusinessntity("Smelter", 170, BusinessTypeEnum.Factory);
                Addbusinessntity("Hot Cars", 120, BusinessTypeEnum.Carlot);

                AddPersonViewModel("Catori", true, PersonImageTypeEnum.Normal);
                AddPersonViewModel("Frank", false, PersonImageTypeEnum.Normal);
                AddPersonViewModel("Jim", false, PersonImageTypeEnum.Normal);
                AddPersonViewModel("Bob", false, PersonImageTypeEnum.Normal);

                ReloadBadGuys();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void ReloadBadGuys()
        {
            //AddPersonViewModel("Joesmo");
            //if (badguycount >= 2)
            //    AddPersonViewModel("SamSlick");
            //if (badguycount >= 3)
            //    AddPersonViewModel("Bobbad");
            //if (badguycount >= 4)
            //    AddPersonViewModel("SlickJim");
        }
        public static void Addbadguypaths()
        {
             ObjectLocationPathEntity paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.Barn1);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);

        }
        public static void AddbadguyEscapepaths()
        {
            ObjectLocationPathEntity paths = new ObjectLocationPathEntity();

            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);

        }
    }
    }
