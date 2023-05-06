using System;
using com.bandags.spacegame.data;
using com.bandags.spacegame.factory;
using com.bandags.spacegame.galaxy;
using com.bandags.spacegame.input;
using com.bandags.spacegame.player;
using com.bandags.spacegame.process;
using com.bandags.spacegame.scene;
using com.bandags.spacegame.ui;
using System.Collections.Generic;
using com.bandags.spacegame.data.jobs;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.quest;
using UnityEngine;

namespace com.bandags.spacegame {
    [Serializable]
    public class GameEngine : MonoBehaviour {
        public static GameEngine Instance { get; private set; }
        
        [Header("Programatically Set Objects")]
        [field: SerializeReference] public IProcessManager ProcessManager;
        [field: SerializeReference] public IFactory Factory;
        [field: SerializeReference] public MouseInput MouseInput;
        [field: SerializeReference] public IGameSceneManager GameSceneManager;
        [field: SerializeReference] public PlayerManager PlayerManager;
        [field: SerializeReference] public Galaxy Galaxy;
        [field: SerializeReference] public UIManager UIManager;
        [field: SerializeReference] public IQuestLibrary QuestLibrary;

        [Header("Editor Set Objects")] 
        public Camera MainCamera;
        public GameObject QuestDialogParent;
        public PlayerScriptableObject StartingPlayerScriptableObject;
        public List<SystemScriptableObject> SystemStartingData;
        public List<ShipScriptableObject> ShipStartingData;
        public List<OutfitScriptableObject> OutfitScriptableObjects;
        public List<QuestScriptableObject> QuestScriptableObjects;

        public Player CurrentPlayer => PlayerManager.CurrentPlayer;
        private void Awake() {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
            
            Instance = this;
            ProcessManager = new ProcessManager(this);
            Factory = new Factory();
            MouseInput = new MouseInput(Camera.main);
            GameSceneManager = new GameSceneManager();
            PlayerManager = new PlayerManager();
            QuestLibrary = new QuestLibrary();
            GameSceneManager.Initialize();
        }
        
        private void Update() {
            MouseInput.Update();
        }
        
        //Todo: Planets
            //Implement Outfitter
            //Implement Shipyard
            //Implement Jobs (in progress)
            //Implement Trade
                //Implement Cargo (in progress)
                //Allow cargo to hold trade items
      
        //Todo: Create Ship Stop Process
            //Stops the ship
            
        //Todo: Ship Movement
            //Hold: Full speed at position.  ship overruns and spins around at full speed attempting to constantly move towards point without slowing
            //Tap: Move and stop at position
            //DoubleTap Ship: Focus and follow ship
            
        //Todo: Ship Combat
            //Implement Ship brain to allow choice between following ai options
                //Landing on a planet
                //Moving near the planet but not on the planet
                //Attacking a random ship
                //Defending from a random ship attack or fleeing

            //Todo: Governments / Relationships / Reputation
            //How do we implement this

        //Todo: Map
            //Implement draggable background (planets keep in sync)
            //Implement more systems
                //Figure out how to adjust names to not overlap too much?
            
        //Todo: MiniMap
            //How do we implement this
                //Port from previous implementation?
                //Build New?
    }
}