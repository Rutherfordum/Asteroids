using Asteroid.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Asteroid.Components
{
    public class LifeTimeAbilityComponent: MonoBehaviour, ILifeTimeAbility, IConvertGameObjectToEntity
    {
        [SerializeField]
        [Range(1, 10)]
        private float _lifeTime;

        private float _time;
        private Entity _entity;
        private EntityManager _dstManager;

        public float LifeTime
        {
            get => _lifeTime;
            set { }
        }


        public void Execute()
        {
            if (Time.time < _time + LifeTime) return;
            _time = Time.time;

            Destroy(this.gameObject);
            _dstManager.DestroyEntity(_entity);
        }

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            _entity = entity;
            _dstManager = dstManager;
        }
    }
}