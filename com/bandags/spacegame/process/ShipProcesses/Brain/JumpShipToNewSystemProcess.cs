using System.Collections;
using com.bandags.spacegame.data;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public class JumpShipToNewSystemProcess : Process {
        private SystemLayer newSystem;
        
        public JumpShipToNewSystemProcess() : base(ProcessType.JUMP_SHIP_TO_NEW_SYSTEM_PROCESS) { }
        protected override IEnumerator Update() {
            var targetSystemLayer = GameEngine.Instance.UIManager.SelectedSystemType;
            //var targetSystemLayer = (GameEngine.Instance.Galaxy.ActiveSystem.SystemLayerData.SystemType == SystemType.Deneb) ? SystemType.Sol : SystemType.Deneb;
            if (targetSystemLayer == SystemType.None) {
                Debug.Log("Target System None");
                yield break;
            }

            if (targetSystemLayer == GameEngine.Instance.CurrentPlayer.CurrentPlayerState.CurrentSystem) {
                Debug.Log("Current Player Ship in Target System");
                yield break;
            }

            yield return new CreateSystemLayerProcess(targetSystemLayer, systemLayer => {
                newSystem = systemLayer;
            }).Run();
            yield return new MoveShipProcess(GameEngine.Instance.CurrentPlayer.CurrentShip, new Vector3(GameEngine.Instance.CurrentPlayer.CurrentShip.transform.position.x+20,GameEngine.Instance.CurrentPlayer.CurrentShip.transform.position.y+10, GameEngine.Instance.CurrentPlayer.CurrentShip.transform.position.z)).Run();    //todo: fix this to move at vector between current system and target system
            
            //Ships must be transferred outside of disabling parent object, or the underlying MonoBehavior will get killed.
            GameEngine.Instance.Galaxy.ActiveSystem.Ships.Remove(GameEngine.Instance.CurrentPlayer.CurrentShip);
            //Todo: Transfer all ships to new system brain based on their current state (jumping, tracking player, etc.)
                //Loop through and find any other ship in player group that is also jump and add them to new galaxy brain in jump state with delay to join based on how long left to jump
                //Loop through and find any player tracking the current player and check to see if ship plans to pursue.  If yes, add delay based on time to jump.  remove them from existing system and transfer to new but in some sort of queued list
            GameEngine.Instance.Galaxy.ActivateNewSystem(newSystem);
            newSystem.SystemBrain.AddShipToSystem(GameEngine.Instance.CurrentPlayer.CurrentShip);
            yield return new WaitForFixedUpdate();
            //Todo: split this logic up into a parent process called HyperspaceAndLandProcess
                //JumpToNewSystem
                //CheckForQuestUpdateProcess
                //landOnPlanetProcess

            //Begin new system logic
            GameEngine.Instance.CurrentPlayer.CurrentPlayerState.CurrentSystem = targetSystemLayer;
            GameEngine.Instance.CurrentPlayer.QuestManager.QuestUpdate();
            
            //Find a planet to land on
            var systemPlanets = GameEngine.Instance.Galaxy.ActiveSystem.Planets;
            if (systemPlanets.Count == 0) yield break;
            var targetPlanet = systemPlanets[0];
            
            yield return new LandOnPlanetProcess(GameEngine.Instance.CurrentPlayer.CurrentShip, targetPlanet, () => {
                GameDataWriter.SaveGame();
                GameEngine.Instance.GameSceneManager.LoadPlanet(targetPlanet.PlanetType);
            }).Run();
        }

        public override void OnInterrupt() {
            if (newSystem != null && GameEngine.Instance.Galaxy.ActiveSystem != newSystem) {
                GameObject.Destroy(newSystem);  //Do not OnDeActivate/Serialize as the system was never used.
            }
        }
    }
}