using CatorisCityAppNew.Viewmodels;

namespace CatorisCityAppNew.Views.Controls.Person;

public partial class PersonGuitarContent : ContentView
{
    PersonViewModel _person;
    private string _imagenamenormal;
    private string _imagenameairguitar;
    public PersonGuitarContent()
    {
        InitializeComponent();
    }
    public PersonGuitarContent(PersonViewModel person, string imagenamenormal, string imagenameairguitar)
    {
        InitializeComponent();
 
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
                PersonImage.Source = _person.CurrentImage;
            }
        }
    }

  
   public void SetPerson(PersonViewModel person)
    {
        Person = person;
    }

    private void DropGestureRecognizer_DragOver(object sender, DragEventArgs e)
    {

    }

    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {
        var found = from g in _person.Images where g.Name.Contains("airguitar") select g;
        if (found.Any())
        {
            Guitarimage.Source = found.FirstOrDefault().Name;
            Guitarimage.IsVisible = true;
            switch (found.FirstOrDefault().Name)
            {
                case "girl_8_airguitar":
                    PersonLayout.SetLayoutBounds(Guitarimage, new Rect(15, 60, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                    Guitarimage.RotateTo(45);
                    break;
                default:
                    break;
            }
        }
    }
}