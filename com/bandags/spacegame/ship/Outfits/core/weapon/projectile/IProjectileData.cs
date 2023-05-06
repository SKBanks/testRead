namespace com.bandags.spacegame.ship {
    public interface IProjectileData {
        int Range { get; }
        float FireRateInSeconds { get; }
        int Damage { get; }
        ProjectileType ProjectileType { get; }
        int ProjectileCount { get; }
    }
}