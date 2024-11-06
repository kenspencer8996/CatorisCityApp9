using CatorisCityAppNew.Views.Controls.Business;
using CatorisCityAppNew.Views.Controls.House;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Objects.Entities
{
    public class BuildingOpenEventArgs : EventArgs
    {
        public HouseContent House { get; set; }
        public BusinessContent Business { get; set; }
        public BuldingTypeEnum BuldingType { get; set; }
        public BuildingOpenEventArgs(ContentView contentView, BuldingTypeEnum buldingType) 
        {
            BuldingType = buldingType;
            switch (buldingType ) 
            { 
                case BuldingTypeEnum.House:
                    House = (HouseContent)contentView;
                    break;
                case BuldingTypeEnum.Factory:
                    Business = (BusinessContent)contentView;
                    break;
                case BuldingTypeEnum.Bank:
                    Business = (BusinessContent)contentView;
                    break;
                case BuldingTypeEnum.CarLot:
                    Business = (BusinessContent)contentView;
                    break;
                case BuldingTypeEnum.Retail:
                    Business = (BusinessContent)contentView;
                    break;
            }
        }
    }
}
