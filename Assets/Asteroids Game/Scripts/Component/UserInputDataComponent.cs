using Asteroid.ComponentData;
using Unity.Entities;
using UnityEngine;

namespace Asteroid.Components
{
    public class UserInputDataComponent : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new InputData());
        }
    }
}