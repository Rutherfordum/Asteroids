using System;
using Unity.Entities;
using UnityEngine;

public class BulletComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    public float Speed
    {
        get => _speed;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Value cannot be less than or equal to zero");
            
            _speed = value;
        }
    }

    [SerializeField]
    private float _speed = 5;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BulletData()
        {
            Speed = this.Speed
        });
    }
}

public struct BulletData : IComponentData
{
    public float Speed;
}
