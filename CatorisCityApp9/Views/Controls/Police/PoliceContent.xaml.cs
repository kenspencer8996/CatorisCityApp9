using CatorisCityAppNew.Objects;
using CatorisCityAppNew.Viewmodels;
using CatorisCityAppNew.Views.Controls.Business;
using CatorisCityAppNew.Views.Controls.House;
using CityAppServices.Objects;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Views.Controls.Person;

public partial class PoliceContent : ContentView
{
    public event EventHandler<PersonMoveFiredEventArg> PersonMoveEvent;

    PersonViewModel _person;
    IDispatcherTimer _showTimer;
    IDispatcherTimer _personMoveTimer;
    int _personNumber = 0;
    int _person1Seconds;
    int _personIteration = 0;
    int _person1Iteration = 0;

    public PoliceContent()
    {
        InitializeComponent();

    }

    public void SetPerson(PersonViewModel person, int personNumber)
    {
        _person = person;
        _personNumber = personNumber;
        PersonImage.Source = person.CurrentImage;
        _showTimer.Tick += Person_PersonTimerFired;
        StartTimers();
    }

    private void Person_PersonTimerFired(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

   
    private void SetupTimerIntervals()
    {
        Random rand = new Random();
        //_person1Seconds = rand.Next(20); 
      
        //_person6Seconds= rand.Next(22);

        _person1Seconds =10;
      
    }
    private void StartTimers()
    {
        SetupTimerIntervals();
        _personMoveTimer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
        _personMoveTimer.Interval = TimeSpan.FromSeconds(_person1Seconds);
        _personMoveTimer.Tick += (sender, e) => PersonMove_TimerFired();
    }

    private void PersonMove_TimerFired()
    {
        _personMoveTimer.Stop();
        MoveBadGuyToLocation(LocationEnum.Bush1Center, 5);
        _personMoveTimer.Start();
       

        _personIteration++;
    }

    private LocationXYEntity GetLocation(LocationEnum locationType)
    {
        LocationXYEntity locationXY = new LocationXYEntity();
        switch (locationType)
        {
            case LocationEnum.ForestCenter:
                locationXY.x = Global.cityforest1x;
                locationXY.y = Global.cityforest1yCenter;
                break;
            case LocationEnum.Bush1Center:
                locationXY.x = Global.citybush1xCenter;
                locationXY.y = Global.citybush1yCenter;
                break;
            case LocationEnum.Bush2Center:
                locationXY.x = Global.citybush2xCenter;
                locationXY.y = Global.citybush2yCenter;
                break;
            case LocationEnum.BusinessCenter:
                locationXY = GetBusinessCenterLocation();
                locationXY.x = locationXY.x + 20;
                locationXY.y = locationXY.y +- 20;
                break;
            default:
                break;
        }

        return locationXY;
    }

    private LocationXYEntity GetBusinessCenterLocation()
    {
        LocationXYEntity locationXY = new LocationXYEntity();
        Random rand = new Random();
        PersonViewModel person = new PersonViewModel();
        PersonImageEntity personimage = new PersonImageEntity();
        int index;
         index = rand.Next(Global.Businesses.Count());
        BusinessContent bc = Global.Businesses.ElementAt(index);
        locationXY.x = bc.Lot.x;
        locationXY.y = bc.Lot.x;
        return locationXY;
    }

    private void Person_PersonTimerFired(object? sender, BadPersonTimerFiredEventArg e)
    {

          
    }
    private async void MoveBadGuyToLocation(LocationEnum location,
        int xOffset = 0, int yOffset = 0)
    {
        double x = 0;
        double y = 0;
        var layoutBoundsNewLoc = GetLocation(location);
        x = layoutBoundsNewLoc.x + xOffset;
        y = layoutBoundsNewLoc.y + yOffset;
        var layoutBounds = AbsoluteLayout.GetLayoutBounds(this);
        double xnow = layoutBounds.X;
        double ynow = layoutBounds.Y;
        //https://learn.microsoft.com/en-us/dotnet/maui/user-interface/animation/custom?view=net-maui-8.0
        var MoveBadGuyParentAnimation = new Animation();
        Animation MoveXAnimation = new Animation(v => this.MoveBadGuyX = v, xnow, x, null);
        Animation MoveYAnimation = new Animation(v => this.MoveBadGuyY = v, ynow, y, null);
        uint animationTime = (uint)Global.TravelSpeed * 1000;

        MoveBadGuyParentAnimation.Add(0, 1, MoveXAnimation);
        MoveBadGuyParentAnimation.Add(0, 1, MoveYAnimation);
        MoveBadGuyParentAnimation.Commit(this, "MoveAnimations", 16, animationTime, null, (v, c) => DummyFunc(true, false));
       await  this.FadeTo(1, 2000);
        
    }

    private Func<bool> DummyFunc(bool v1, bool v2)
    {
        var res = 1 == 2;
        return () => res;
    }

    private double _moveBadGuyX = 0;
    private double _moveBadGuyY = 0;
    private double MoveBadGuyX
    {
        set
        {
            _moveBadGuyX = value;
        }
    }
    private double MoveBadGuyY
    {
        set
        {
            _moveBadGuyY = value;
            PersonMoveFiredEventArg arg = new PersonMoveFiredEventArg(_moveBadGuyX, _moveBadGuyY, _person);
            PersonMoveEvent(this,arg);
        }
    }
    private void OnDragStartingMyPerson(object sender, DragStartingEventArgs e)
    {
        HouseContent person = sender as HouseContent;
        e.Data.Properties.Add("Person", _person.Name);
    }


}