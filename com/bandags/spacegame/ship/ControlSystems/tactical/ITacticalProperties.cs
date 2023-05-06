namespace com.bandags.spacegame.ship {
    public interface ITacticalProperties {
        int MaxShieldStrength { get; }
        int CurrentShieldStrength { get; }
        int MaxHullStrength { get; }
        int CurrentHullStrength { get; }
        void UpdateCurrentHullStrength(int value);
        void UpdateCurrentShieldStrength(int value);
        void UpdateOutfits(IOutfitManager outfitManager);
    }
}