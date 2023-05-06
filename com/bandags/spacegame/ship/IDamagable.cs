namespace com.bandags.spacegame.ship {
    public interface IDamagable {
        void TakeDamage(int amount, IShip source);
    }
}