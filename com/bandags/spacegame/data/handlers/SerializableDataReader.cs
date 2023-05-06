using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.data {
    public static class SerializableDataReader {
        public static GalaxyData ReadGalaxyFromPath() {
            return ReadSerializableFromPath<GalaxyData>(FileSystemPaths.GALAXY_DATA_PATH);
        }
        
        public static PlayerData ReadPlayerFromPath() {
            return ReadSerializableFromPath<PlayerData>(FileSystemPaths.PLAYER_DATA_PATH);
        }
        
        private static T ReadSerializableFromPath<T>(string savePath) {
            var jsonData = PlayerPrefs.GetString(savePath);
            var deserializedObject = JsonUtility.FromJson<T>(jsonData);
            return deserializedObject;
        }
    }
}