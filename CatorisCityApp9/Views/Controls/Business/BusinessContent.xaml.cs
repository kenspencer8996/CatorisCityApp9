using CatorisCityAppNew.Viewmodels;
using CatorisCityAppNew.Views.Controls.Person;
using CityAppServices.Objects.Entities;
using CommunityToolkit.Mvvm.Messaging;
using Plugin.Maui.Audio;

namespace CatorisCityAppNew.Views.Controls.Business;

public partial class BusinessContent : ContentView
{
    private string _BusinesName;
    private string _BusinesImageName;
    public decimal EmployeePayHour { get; set; }
    IAudioManager _AudioManager;
    BusinessViewModel Business;
    string RobberName = "";
    public BusinessContent(BusinessViewModel business)
    {
        InitializeComponent();
        _AudioManager = new AudioManager();
        Business = business;
        BusinessImage.Source = business.ImageName;
        BusinessNameLabel.Text = business.Name;
        _BusinesName = business.Name;
        _BusinesImageName = business.ImageName;
        EmployeePayHour = business.EmployeePayHour;

        //Stream voiceStream = File.OpenRead(Global.Burglaralarmfile);

        //var player = _AudioManager.CreatePlayer(voiceStream);
        WeakReferenceMessenger.Default.Register<PersonMessage>(this, (r, m) =>
        {
            RobberName = m.Value;
            mediaElement.Play();
            SendMessageOnRobbery();
        });
    }
    private void SendMessageOnRobbery()
    {
        RobberyMessageDetailViewModel detail = new RobberyMessageDetailViewModel(RobberName,this);
        WeakReferenceMessenger.Default.Send(new RobberyMessage(detail));
    }
    public void SetPerson(PersonContent person)
    {
        //PersonStack.Children.Clear();
        //PersonStack.Children.Add(person);

    }

    void OnDragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.Copy;
    }
    public string BusinesName
    {
        get { return _BusinesName; }
    }
    public string BusinesImageName
    {
        get { return _BusinesImageName; }
    }
    public void RotateBusinessImage(double degrees)
    {
        BusinessImage.RotateTo(degrees);
    }
    internal LotEntity Lot { get; set; }
   
    private void ContentView_Unloaded(object sender, EventArgs e)
    {
    }
    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {

    }
    private void mediaElement_StateChanged(object sender, CommunityToolkit.Maui.Core.Primitives.MediaStateChangedEventArgs e)
    {
        switch (e)
        {
             default:
                break;
        }
    }
}