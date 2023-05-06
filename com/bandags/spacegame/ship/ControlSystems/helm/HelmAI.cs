using com.bandags.spacegame.data;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.process;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.ship {
    public class HelmAI : IHelmAI {
        public IProcessManager HelmAIProcessManager { get; }
        private readonly Ship _ship;

        public HelmAI(Ship ship) {
            _ship = ship;
            HelmAIProcessManager = new ProcessManager(_ship);
        }

        public void AttackShip(Ship targetShip) {
            HelmAIProcessManager.Interrupt();
            HelmAIProcessManager.RunProcess(new AttackShipProcess(_ship, targetShip));
        }

        public void LandOnPlanet(Planet planet) {
            HelmAIProcessManager.Interrupt();
            HelmAIProcessManager.RunProcess(new LandOnPlanetProcess(_ship, planet, () => {
                if (_ship == GameEngine.Instance.CurrentPlayer.CurrentShip) {
                    GameEngine.Instance.GameSceneManager.LoadPlanet(planet.PlanetType);
                } else {
                    GameEngine.Instance.Galaxy.ActiveSystem.SystemBrain.RemoveShipFromSystem(_ship);
                }
            }));
        }

        public void GoToPosition(Vector3 position) {
            HelmAIProcessManager.Interrupt();
            HelmAIProcessManager.RunProcess(new MoveShipProcess(_ship, position));
        }

        public void GoToPositionAndStop(Vector3 position) {
            HelmAIProcessManager.Interrupt();
            HelmAIProcessManager.RunProcess(new MoveShipAndStopProcess(_ship, position));
        }

        public void JumpToSystem(SystemType systemType) {
            if (HelmAIProcessManager.GetProcessType() == ProcessType.JUMP_SHIP_TO_NEW_SYSTEM_PROCESS) {
                return; //Dont try to jump if we already are jumping
            }

            HelmAIProcessManager.Interrupt();
            HelmAIProcessManager.RunProcess(new JumpShipToNewSystemProcess());
        }
    }
}