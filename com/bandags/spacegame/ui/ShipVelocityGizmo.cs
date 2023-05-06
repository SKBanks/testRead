using UnityEngine;

namespace DefaultNamespace {
    public class ShipVelocityGizmo : MonoBehaviour {

        private Rigidbody2D _rigidbody2D;
        private void Start() {
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        }
        private void LateUpdate() {
            Debug.DrawLine(transform.position, transform.position + transform.up * 2, Color.white);
            Debug.DrawLine(transform.position,  transform.position + new Vector3(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y, transform.position.z), Color.red);
        }
    }
}