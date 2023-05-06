namespace com.bandags.spacegame.ship {
    public interface IHelm : IControlSystem {
        HelmProperties Properties { get; }
        IHelmAI HelmAI { get; }
    }
}