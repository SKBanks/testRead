using UnityEngine;
namespace com.bandags.spacegame.utilities {
    public static class Instantiation {
        public static T InstantiatePrefab<T>(string prefabPath) {
            var gameObject = Object.Instantiate(Resources.Load(prefabPath) as GameObject);
            if (gameObject == null) {
                Debug.LogError($"Unable to instantiate prefab at path: {prefabPath}");
            }

            return gameObject.GetComponent<T>();
        }
        
        public static T InstantiatePrefab<T>(GameObject prefab) {
            var gameObject = Object.Instantiate(prefab);
            if (gameObject == null) {
                Debug.LogError($"Unable to instantiate prefab : {prefab}");
            }

            return gameObject.GetComponent<T>();
        }
        
        public static GameObject InstantiatePrefab(string prefabPath) {
            var gameObject = Object.Instantiate(Resources.Load(prefabPath) as GameObject);
            if (gameObject == null) {
                Debug.LogError($"Unable to instantiate prefab : {prefabPath}");
            }

            return gameObject;
        }
    }
}