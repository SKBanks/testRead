using com.bandags.spacegame.job;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.player.job {
    public class PlayerJob {
        private string _title;
        private string _description;
        private int _cargoSize;
        private CargoType _cargoType;
        private PlanetType _targetPlanet;
        private SystemType _targetSystem;
        private int _rewardAmount;
    }
}