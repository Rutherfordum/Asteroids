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
        }
    }

    public struct InputMoveData : IComponentData
    {
        public float2 Move;
        public bool isMove;
    }
}
