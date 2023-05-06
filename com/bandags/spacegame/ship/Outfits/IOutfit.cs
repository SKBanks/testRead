namespace com.bandags.spacegame.ship {
    public interface IOutfit {
        string Name { get; set; }
        int Cost { get; set; }
        int Value { get; set; }
        OutfitCategory OutfitCategory { get; }
        OutfitType OutfitType { get; }
        T Upcast<T>();
    }
}