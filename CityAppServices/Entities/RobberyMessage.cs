
namespace CityAppServices.Objects.Entities
{
    public class RobberyMessage : ValueChangedMessage<RobberyMessageDetailEntity>
    {
        public RobberyMessage(RobberyMessageDetailEntity value) : base(value)
        {
        }
    }
}
