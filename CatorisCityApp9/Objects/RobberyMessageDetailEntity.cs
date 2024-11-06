using CatorisCityAppNew.Views.Controls.Business;

namespace CatorisCityAppNew.Viewmodels
{
    internal class RobberyMessageDetailViewModel
    {
        public string RobberName;
        public BusinessContent Business;
        internal RobberyMessageDetailViewModel(string RobberName, BusinessContent Business)
        {
            this.RobberName= RobberName.Trim();
            this.Business = Business;
        }
    }
}
