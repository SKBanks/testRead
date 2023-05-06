using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public interface ICargoContainerOutfit : IOutfit, ISerialize<CargoContainerData>  {
        string CargoContents { get; }
        int CargoCapacity { get; }
    }
}