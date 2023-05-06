using System.Collections.Generic;
using com.bandags.spacegame.data.Serialization;

namespace com.bandags.spacegame.ship {
    public interface IOutfitManager : ISerialize<OutfitManagerData> {
        List<T> GetOutfits<T>();
        void AddOutfits(IOutfit outfit);
        void Deserialize(OutfitManagerData data, Ship owner);
    }
}