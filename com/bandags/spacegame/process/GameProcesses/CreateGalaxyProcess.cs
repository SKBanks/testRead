using System;
using System.Collections;
using com.bandags.spacegame.camera;
using com.bandags.spacegame.galaxy;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.process {
    public class CreateGalaxyProcess : Process {
        private readonly Action<SystemLayer> _onSystemLoaded;
        public CreateGalaxyProcess(Action<SystemLayer> onSystemLoaded) : base(ProcessType.CREATE_GALAXY_PROCESS) {
            _onSystemLoaded = onSystemLoaded;
        }
        protected override IEnumerator Update() {
            GameEngine.Instance.Galaxy = new Galaxy(GameEngine.Instance.SystemStartingData, GameEngine.Instance.ShipStartingData, GameEngine.Instance.OutfitScriptableObjects);
            
            //Create the system layer
            yield return new CreateSystemLayerProcess(SystemType.Sol,system => {
                GameEngine.Instance.Galaxy.ActivateNewSystem(system);
            }).Run();
            
            //Create the player
            yield return new CreatePlayerProcess(GameEngine.Instance.StartingPlayerScriptableObject, player => {
                GameEngine.Instance.PlayerManager.CurrentPlayer = player;
                player.CurrentPlayerState.CurrentPlanet = PlanetType.None;
                player.CurrentPlayerState.CurrentSystem = SystemType.Sol;
                GameEngine.Instance.MainCamera.GetComponent<FollowTarget>().Target = GameEngine.Instance.PlayerManager.CurrentPlayer.CurrentShip.transform;
            }).Run();

            GameEngine.Instance.MouseInput.Enabled = true;
            _onSystemLoaded?.Invoke(GameEngine.Instance.Galaxy.ActiveSystem);
        }
    }
}