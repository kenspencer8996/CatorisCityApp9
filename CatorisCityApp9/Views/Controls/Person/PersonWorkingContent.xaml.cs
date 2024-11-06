using CatorisCityAppNew.Objects;
using CatorisCityAppNew.Viewmodels;
using CatorisCityAppNew.Views.Controls.House;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Views.Controls.Person;

public partial class PersonWorkingContent : ContentView
{
    PersonViewModel _person;
     public PersonWorkingContent(PersonViewModel person)
    {
        InitializeComponent();
        _person = person;
        BindingContext = person;
         PersonFundsLabel.RotateTo(90);
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

    internal void StartPay(decimal employeePayHour)
    {
        _person.StartPay(employeePayHour);
    }
}