using CatorisCityAppNew.Objects;
using CatorisCityAppNew.Viewmodels;
using CatorisCityAppNew.Views.Controls.House;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Views.Controls.Person;

public partial class PersonContent : ContentView
{
    PersonViewModel _person;
    IDispatcherTimer _badGuyMoveTimer;
    IDispatcherTimer _badGuyEscapeMoveTimer;
    public PersonContent()
    {
        InitializeComponent();
    }
    public PersonContent(PersonViewModel person)
    {
        InitializeComponent();
        person.Host = this;
        BindingContext = person;
        person.ShowPersonTimerFired += Person_PersonTimerFired;
        PersonFundsLabel.RotateTo(90);
    }
    public PersonViewModel Person
    { 
        get 
        { return _person; }
        set
        {
            if (_person != value)
            {
                _person = value;
            }
        }
    }

    private void Person_PersonTimerFired(object? sender, PersonTimerFiredEventArg e)
    {
        if (e.Person.PersonRole == PersonEnum.BadGuy) 
        {
            this.IsVisible = true;
        }
    }

    private void OnDragStartingMyPerson(object sender, DragStartingEventArgs e)
    {
        HouseContent person = sender as HouseContent ;
        e.Data.Properties.Add("Person", _person.Name);
    }

   
}