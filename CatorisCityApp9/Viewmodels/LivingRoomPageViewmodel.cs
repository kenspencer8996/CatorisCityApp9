using CatorisCityAppNew.Views.Controls.House;

namespace CatorisCityAppNew.Viewmodels
{
    public partial class LivingRoomPageViewmodel: ViewmodelBase
    {
       public HouseContent House { get; set; }
        public double widthofparent;
        public double heightofparent;
        public PersonViewModel Person 
        { get
            {
                if (House.Persons != null && House.Persons.Any())
                    return House.Persons[0];
                else 
                    return new PersonViewModel();
            }
        }
        public string LivingRoomImage
        {
            get
            {
                return House.ImageLivingFileName;
            }
        }
        public LivingRoomPageViewmodel()
        {

        }
         
    }
}
