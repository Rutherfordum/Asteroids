using Asteroid.Interfaces;
using UnityEngine;
namespace Asteroid.Components
{
    public class ShootAbilityComponent : MonoBehaviour, IShootAbility
    {
        public BulletComponent BulletPrefab => _bulletPrefab;
        public float Delay => _delay;

        [SerializeField] private BulletComponent _bulletPrefab;

        [SerializeField] [Range(0.1f, 5f)] private float _delay = 1;

        private float _shootTime;

        public void Execute()
        {
            if (Time.time < _shootTime + Delay) return;
            _shootTime = Time.time;

            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}
