using SkiaSharp.Views.Maui.Controls;

namespace CatorisCityAppNew.Objects
{
    internal class UIHelpers
    {
        internal static CityStreetMasterViewModel LoadConent()
        {
            CityStreetMasterViewModel cityStreetMaster = new CityStreetMasterViewModel();
            double masterHeight = 600;
            double masterWidth = 1200;
            cityStreetMaster.CityContent = new MainContent();
            cityStreetMaster.CityContent.HeightRequest = masterHeight;
            cityStreetMaster.CityContent.WidthRequest = masterWidth;
            cityStreetMaster.CityContent.ZIndex = 1;
            cityStreetMaster.CityLayout = new AbsoluteLayout();
            cityStreetMaster.CityLayout.HorizontalOptions = LayoutOptions.Start;
            cityStreetMaster.CityLayout.VerticalOptions = LayoutOptions.Start;
            cityStreetMaster.CityLayout.HeightRequest = masterHeight;
            cityStreetMaster.CityLayout.WidthRequest = 1200;
            cityStreetMaster.CityLayout.ZIndex = 2;

            cityStreetMaster.CityContent.Content = cityStreetMaster.CityLayout;
            // contentView.Content = testlabel;
            Image image = new Image();
            image.Aspect = Aspect.AspectFill;
            image.HeightRequest = masterHeight;
            image.WidthRequest = masterWidth;
            image.Source = "greenyard.jpg";
            image.ZIndex = 3;
            cityStreetMaster.CityLayout.Children.Add(image);
            AbsoluteLayout.SetLayoutBounds(image, GetRect(0, 0, masterWidth, masterHeight));
            Border border = new Border();
            border.HeightRequest = masterHeight;
            border.WidthRequest = masterWidth;
            cityStreetMaster.CityLayout.Children.Add(border);
           // AbsoluteLayout.SetLayoutBounds(border, GetRect(0, 0, 0, 0));
            border.ZIndex = 4;
            cityStreetMaster.CityCanvas = new SKCanvasView();
            cityStreetMaster.CityCanvas.HeightRequest = masterHeight;
            cityStreetMaster.CityCanvas.WidthRequest = masterWidth;
            AbsoluteLayout.SetLayoutBounds(cityStreetMaster.CityCanvas, GetRect(0, 0, masterWidth, masterHeight));
            Global._menuControl = new Views.Controls.MenuLayoutControl();
            Global._menuControl.IsVisible = false;
            AbsoluteLayout.SetLayoutBounds(Global._menuControl, GetRect(0, 0, 300, 200));
            cityStreetMaster.CityLayout.Children.Add(Global._menuControl);
            return cityStreetMaster;
        }
        internal static Rect GetRect(double x, double y, double width, double height)
        {
            Rect rect = new Rect();
            rect.X = x;
            rect.Y = y;
            rect.Width = width;
            rect.Height = height;
            return rect;
        }
    }
}
