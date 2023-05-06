namespace com.bandags.spacegame.ship {
    public interface IHostility {
        FactionType GetFactionType();
        bool IsHostile(FactionType factionType);
    }
}