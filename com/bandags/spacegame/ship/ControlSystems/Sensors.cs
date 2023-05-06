using System;
using com.bandags.spacegame.input;
using UnityEngine;

//Todo: [PRIORITY] Create list of hostile Targets and update threat level each time user needs a new target
    //Each time someone attacks the ship or becomes hostile with the target, the ship should be added to the hostile list
    //When the current hostile target is lost, the list should be searched for the highest priority target and update hostile target to it
namespace com.bandags.spacegame.ship {
    [Serializable]
    public class Sensors : ISensors {
        [field: SerializeReference] public ISelectable Selection { get; set; }
        [field: SerializeReference] public Ship HostileTarget { get; set; }
        public void UpdateOutfits() {
            //Todo: This should be removed... Is it necessary?  Can we refactor this out?
        }
    }
}