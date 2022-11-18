using System.Collections.Generic;
using Asteroid.ComponentData;
using Asteroid.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Asteroid.Components
{
    public class AbilitiesComponent : MonoBehaviour, IConvertGameObjectToEntity
    {
        public List<MonoBehaviour> Abilities => _abilities;

        [SerializeField] private List<MonoBehaviour> _abilities;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            foreach (var ability in Abilities)
            {
                if (ability is IMoveAbility moveAbility)
                    dstManager.AddComponentData(entity, new MoveData()
                    {
                        Speed = moveAbility.Speed,
                        TurningSpeed = moveAbility.TurningSpeed
                    });

                if (ability is IShootAbility shootAbility)
                    dstManager.AddComponentData(entity, new ShootData());

                if (ability is ILifeTimeAbility lifeTimeAbility)
                    dstManager.AddComponentData(entity, new LifeTimeData()
                    {
                        LifeTime = lifeTimeAbility.LifeTime
                    });
            }
        }
    }
}