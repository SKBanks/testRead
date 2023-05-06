using com.bandags.spacegame.planet;
using com.bandags.spacegame.process;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.ship {
    public interface IHelmAI {
        IProcessManager HelmAIProcessManager { get; }
        void AttackShip(Ship targetShip);
        void LandOnPlanet(Planet planet);
        void GoToPosition(Vector3 position);
        void GoToPositionAndStop(Vector3 position);
        void JumpToSystem(SystemType systemType);
    }
}