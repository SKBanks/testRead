using System.Collections;
using UnityEngine;
namespace com.bandags.spacegame.utilities {
    public static class TrainRendererExtensions {
        /// <summary>
        /// Reset the trail so it can be moved without streaking
        /// </summary>
        public static void Reset(this TrailRenderer trail, MonoBehaviour instance) {
            instance.StartCoroutine(ResetTrail(trail));
        }

        /// <summary>
        /// Coroutine to reset a trail renderer trail
        /// </summary>
        /// <param name="trail"></param>
        /// <returns></returns>
        static IEnumerator ResetTrail(TrailRenderer trail) {
            var trailTime = trail.time;
            trail.time = 0;
            yield return new WaitForEndOfFrame();
            trail.time = trailTime;
        }
    }
}