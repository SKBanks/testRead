namespace com.bandags.spacegame.ship {
    public class ProjectileData : IProjectileData {
        public int Range { get; set; }
        public float FireRateInSeconds { get; set;}
        public int Damage { get; set;}
        public ProjectileType ProjectileType { get; set;}
        public int ProjectileCount { get; set; }
    }
}