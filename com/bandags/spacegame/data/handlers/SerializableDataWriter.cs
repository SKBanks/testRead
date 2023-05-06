using com.bandags.spacegame.galaxy;
using com.bandags.spacegame.player;
using UnityEngine;

namespace com.bandags.spacegame.data {
    public static class SerializableDataWriter {
        public static void SaveGalaxyToPath(Galaxy galaxy) {
            SaveSerializableToPath(galaxy, FileSystemPaths.GALAXY_DATA_PATH);
        }
        public static void SavePlayerToPath(Player player) {
            SaveSerializableToPath(player, FileSystemPaths.PLAYER_DATA_PATH);
        }
        private static void SaveSerializableToPath<T>(ISerialize<T> serializableObject, string savePath) {
            var sGalaxy = serializableObject.Serialize();
            var serializedObject = JsonUtility.ToJson(sGalaxy);
            Debug.Log(serializedObject);
            PlayerPrefs.SetString(savePath, serializedObject);
            PlayerPrefs.Save();
        }
    }
}