using CatorisCityAppNew.Views.Controls.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatorisCityAppNew.Viewmodels
{
    public class KitchenPageViewModel: ViewmodelBase
    {
        public HouseContent House { get; set; }
        public string KitchenImage
        {
            get
            {
                return House.ImageKitchenFileName;
            }
        }
    }
}
