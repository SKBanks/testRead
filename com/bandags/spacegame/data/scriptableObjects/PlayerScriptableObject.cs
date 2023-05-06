using System;
using UnityEngine;

namespace com.bandags.spacegame.data {
    [CreateAssetMenu(fileName = "Player_ScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]
    [Serializable]
    public class PlayerScriptableObject : ScriptableObject {
        public string Name;
        public ShipScriptableObject CurrentShip;
    }
}