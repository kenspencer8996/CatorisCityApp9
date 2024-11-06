
using CatorisCityAppNew.Viewmodels;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CityAppServices.Objects.Entities
{
    internal class RobberyMessage : ValueChangedMessage<RobberyMessageDetailViewModel>
    {
        internal RobberyMessage(RobberyMessageDetailViewModel value) : base(value)
        {
        }
    }
}
