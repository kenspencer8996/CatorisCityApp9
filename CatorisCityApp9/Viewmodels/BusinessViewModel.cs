using CatorisCityAppNew.Views.Controls.Person;
using CityAppServices.Objects.Entities;

namespace CatorisCityAppNew.Viewmodels
{
    public class BusinessViewModel: ViewmodelBase
    {
        public BadPersonContent BadPerson { get; set; }
        private string _Name = "";
        private decimal _EmployeePayHour;
        private string _ImageName;
        private BusinessTypeEnum _BusinessType;
        public int BusinessID { get; set; }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public decimal EmployeePayHour
        {
            get
            {
                return _EmployeePayHour;
            }
            set
            {
                _EmployeePayHour = value;
            }
        }
        internal string ImageName
        {
            get
            {
                return _ImageName;
            }
            set
            {
                _ImageName = value;
            }
        }
        public BusinessTypeEnum BusinessType
        {
            get
            {
                return _BusinessType;
            }
            set
            {
                _BusinessType = value;
            }
        }
        public BusinessEntity GetEntity()
        {
            BusinessEntity entity = new BusinessEntity();
            entity.BusinessID = BusinessID;
            entity.BusinessType = _BusinessType;
            entity.EmployeePayHour = _EmployeePayHour;
            entity.Name = _Name;
            return entity;
        }
        public void ToModel(BusinessEntity entity)
        {
            BusinessID = entity.BusinessID;
            _BusinessType = entity.BusinessType;
            _EmployeePayHour = entity.EmployeePayHour ;
            _Name = entity.Name ;
        }

    }
}
