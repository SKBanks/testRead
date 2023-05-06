using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.input;

namespace com.bandags.spacegame.ship {
    public interface IShip : ISelectable, IDamagable, IHostility, ISerialize<ShipData> {
        string GetName();
    }
}