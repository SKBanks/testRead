namespace com.bandags.spacegame.camera {
    using UnityEngine;

    public class FollowTarget : MonoBehaviour {
        public Transform Target;
        public int FollowDistance;

        private void Update() {
            if (!Target) return;
            var position = Target.position;
            transform.position = new Vector3(position.x, position.y, position.z - FollowDistance);
        }
    }
}