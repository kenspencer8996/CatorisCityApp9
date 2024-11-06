using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatorisCityAppNew.Viewmodels
{
    internal class RobberyMessageDetailViewModel: ViewmodelBase
    {
        public string RobberName;
        public BusinessContent Business;
        internal RobberyMessageDetailViewModel(string RobberName, BusinessContent Business)
        {
            this.RobberName = RobberName.Trim();
            this.Business = Business;
        }
    }
}
