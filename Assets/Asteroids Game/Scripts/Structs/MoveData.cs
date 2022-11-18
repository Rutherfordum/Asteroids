using Unity.Entities;

namespace Asteroid.ComponentData
{
    public struct MoveData : IComponentData
    {
        public float Speed;
        public float TurningSpeed;
    }
}