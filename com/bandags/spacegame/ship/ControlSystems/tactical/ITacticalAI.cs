namespace com.bandags.spacegame.ship {
    public interface ITacticalAI {
        void AttackTarget(Ship targetShip, IHelmAI helmAI);
        void Interrupt();
    }
}