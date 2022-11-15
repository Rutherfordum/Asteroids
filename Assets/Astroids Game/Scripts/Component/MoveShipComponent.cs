using System;
using Unity.Entities;
using UnityEngine;

namespace Asteroid.Components
{
    public class MoveShipComponent: MonoBehaviour, IConvertGameObjectToEntity
    {
        [Range(1,10)]
        [SerializeField] private float _speed = 3;

        [Range(1, 10)]
        [SerializeField] private float _speedRotate = 3;

        public float Speed
        {
            get => _speed;
            set
            {
                if(value <= 0 || value > 100)
                    throw new ArgumentException("value is a big", "Speed");

                _speed = value;
            }
        }

        public float SpeedRotate
        {
            get => _speedRotate;
            set
            {
                if (value <= 0 || value > 100)
                    throw new ArgumentException("value is a big", "Speed Rotate");

                _speedRotate = value;
            }
        }
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new MoveShipData()
            {
                Speed = this._speed/100,
                SpeedRotate = this._speedRotate/100
            });
        }
    }
    public struct MoveShipData : IComponentData
    {
        public float Speed;
        public float SpeedRotate;
    }
}