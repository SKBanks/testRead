using System.Collections;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.galaxy;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.process {
    public class DeserializeGalaxyProcess : Process {
        private readonly GalaxyData _galaxyData;
        public DeserializeGalaxyProcess(GalaxyData galaxyData) : base(ProcessType.LOAD_SYSTEM_PROCESS) {
            _galaxyData = galaxyData;
        }
        protected override IEnumerator Update() {
            GameEngine.Instance.Galaxy = new Galaxy(GameEngine.Instance.SystemStartingData, GameEngine.Instance.ShipStartingData, GameEngine.Instance.OutfitScriptableObjects);
            GameEngine.Instance.Galaxy.Deserialize(_galaxyData);
            yield return null;
        }
    }
}