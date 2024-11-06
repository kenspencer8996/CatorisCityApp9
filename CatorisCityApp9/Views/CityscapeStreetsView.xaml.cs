namespace CatorisCityAppNew.Views;

public partial class CityscapeStreetsView : ContentPage
{
    CityscapeStreetsController _controller;
    public CityscapeStreetsView()
	{
		InitializeComponent();
        _controller = new CityscapeStreetsController(this);

    }
}