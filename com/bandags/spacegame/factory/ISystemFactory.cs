using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.factory {
    public interface ISystemFactory {
        SystemLayer CreateSystemLayer(int systemOffset, SystemLayerData systemLayerStartingData);
    }
}