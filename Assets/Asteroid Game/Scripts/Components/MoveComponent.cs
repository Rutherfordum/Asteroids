using Unity.Entities;
using UnityEngine;

public class MoveComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField]
    [Range(1, 10)]
    private float _speed = 1;
   
    [SerializeField]
    [Range(1, 10)]
    private float _turningSpeed = 10;

    public float Speed => _speed/100;
    public float TurningSpeed => _turningSpeed;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new MoveData()
        {
            Speed = this.Speed,
            TurningSpeed = this.TurningSpeed
        });
    }
}
