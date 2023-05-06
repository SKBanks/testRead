namespace com.bandags.spacegame.ship {
    public interface ITactical : IControlSystem {
        IHardpointManager HardpointManager { get; }
        ITacticalProperties TacticalProperties { get; }
        ITacticalAI TacticalAI { get; }
    }
}