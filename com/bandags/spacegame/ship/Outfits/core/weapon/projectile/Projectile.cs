using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.bandags.spacegame.ship {
	public abstract class Projectile : MonoBehaviour, IProjectile {
		public float Speed;
		public GameObject HitPrefab;
		public List<GameObject> Trails;
		private List<GameObject> TrailsBackup;

		private Ship _owner;
		private Rigidbody _rigidbody;
		private ParticleSystem _particleSystem;
		private bool _shouldMove;
		private Vector3 _attackVector;
		public Vector3 startPosition;
		private bool _collided;
		public IProjectileData ProjectileData { get; private set; }

		public void Setup(IProjectileData projectileData, Ship owner) {
			ProjectileData = projectileData;
			_owner = owner;
			_rigidbody = GetComponent<Rigidbody>();
			_particleSystem = GetComponent<ParticleSystem>();
			_shouldMove = false;
		}

		public void SetTarget(GameObject target, Vector3 startingPosition, Ship owner) {
			//transform.SetParent(owner.transform);
			transform.SetParent(null);
			startPosition = startingPosition;
			transform.position = startPosition;
			transform.LookAt(target.transform.position);
			//_attackVector = _owner.transform.up + (_owner.transform.up + _owner.transform.up.normalized * 2);
			_attackVector = (_owner.transform.up.normalized * 2) - _owner.transform.up;
			//Debug.Log($"Starting Position: {startingPosition} |  Attack Vector: {_attackVector}");
			_shouldMove = true;
			_particleSystem.Play(true);
			gameObject.SetActive(true);
		}

		public void Reset() {
			_collided = false;
			_shouldMove = false;
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = Vector3.zero;
			gameObject.SetActive(false);
			transform.SetParent(_owner.transform);
		}

		private void FixedUpdate() {
			if (!_shouldMove) return;
			_rigidbody.position += _attackVector.normalized * (65 * Time.deltaTime);
			//Debug.Log($"Position: {_rigidbody.position}");
		}

		private void OnCollisionEnter(Collision co) {
			if (!ValidCollision(co)) return;
			_collided = true;
			ShowHitParticle(co);
			co.gameObject.GetComponentInParent<IDamagable>()?.TakeDamage(ProjectileData.Damage, _owner);
			Reset();
		}

		private bool ValidCollision(Collision co) {
			var targetIsShip = co.gameObject.CompareTag("Ship");
			var alreadyCollided = _collided;
			var hitSelf = co.transform?.parent?.gameObject == _owner.gameObject;
			return targetIsShip && !alreadyCollided && !hitSelf;
		}

		private void ShowHitParticle(Collision co) {
			if (HitPrefab == null) return;

			var contact = co.contacts[0];
			var hitVFX = Instantiate(HitPrefab, contact.point, Quaternion.FromToRotation(Vector3.up, contact.normal));

			var ps = hitVFX.GetComponent<ParticleSystem>();
			if (ps == null) {
				var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
				Destroy(hitVFX, psChild.main.duration);
			} else
				Destroy(hitVFX, ps.main.duration);
		}
	}
}