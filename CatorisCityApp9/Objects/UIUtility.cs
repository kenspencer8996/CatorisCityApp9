namespace CatorisCityAppNew.Objects
{
    public class UIUtility
    {
        public static Image GetImageControl(string path,
            double HeightRequest,double WidthRequest,
            int zindex)
        {
            Image thisImage = new Image();
            thisImage.HeightRequest = HeightRequest;
            thisImage.Source = path;
            thisImage.WidthRequest = WidthRequest;
            thisImage.ZIndex = zindex;
            return thisImage;
        }
    }
}
