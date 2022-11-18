using Unity.Entities;
using Unity.Mathematics;

namespace Asteroid.ComponentData
{
    public struct InputData : IComponentData
    {
        public float2 Move;
        public bool MoveAction;
        public bool ShootAction;
    }
}
