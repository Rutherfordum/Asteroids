using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace UserInput.Components
{
    public class UserInputDataComponent : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new InputMoveData());
            dstManager.AddComponentData(entity, new InputShootData());
        }
    }

    public struct InputMoveData : IComponentData
    {
        public float2 Move;
        public bool MoveAction;
    }

    public struct InputShootData : IComponentData
    {
        public bool ShootAction;
    }
}
