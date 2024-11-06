using CatorisCityAppNew.Objects;
using CatorisCityAppNew.Objects.Entities;
using CatorisCityAppNew.Viewmodels;
using CatorisCityAppNew.Views.Controls.Person;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Views.Controls.Police;

public partial class PoliceStationContent : ContentView
{
    public event EventHandler<BuildingOpenEventArgs> OnBuildingOpenContent;
    public event EventHandler<BadPersonDroppedFiredEventArg> BadPersonDroppedEvent;

    public List<PersonViewModel> Criminals { get; set; }
    internal LotEntity Lot { get; set; }

    public PoliceStationContent()
    {
        InitializeComponent();
        
        WidthRequest = 120;
        HeightRequest = 120;
        Criminals = new List<PersonViewModel>();
}
  
    internal void SetLot(LotEntity lot)
    {
       if (lot.x == 0 ||  lot.y == 0)
            IsVisible = false;
    }
    public void SetPerson(PersonViewModel crook)
    {
        Criminals.Add(crook);
    
    }

    private void DropGestureRecognizer_DragOver(object sender, DragEventArgs e)
    {

    }

    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {
        // BadPersonnContent bp = (BadPersonnContent)e.Data.Properties["BadPerson"];
        var bpId =Convert.ToInt32( e.Data.Properties["BadPerson"].ToString());
      
        int personnumber = 0;
        int persomid = 0;
                var found = from p in Global._cityApp.Persons
                        where p.PersonId == bpId
                        select p;
            if (found.Any())
            {
                var bp = found.First();
                if (BadGuy1.BadPerson == null )
                {
                    PersonViewModel badperson = new PersonViewModel();
                    badperson.Add(0, bp);
                    persomid = bp.PersonId;
                    personnumber = 1;
                    BadGuy1.SetPerson(badperson,personnumber);
                    Criminals.Add(badperson);
             }else if (BadGuy2.BadPerson == null )
                {
                    PersonViewModel badperson = new PersonViewModel();
                    badperson.Add(0, bp);
                    persomid = bp.PersonId;
                    personnumber = 2;
                    BadGuy2.SetPerson(badperson, personnumber);
                    Criminals.Add(badperson);
                }
           
        }


        BadPersonDroppedFiredEventArg args = new BadPersonDroppedFiredEventArg(personnumber, persomid);
        if (BadPersonDroppedEvent != null) 
            BadPersonDroppedEvent(this, args);
    }
}
