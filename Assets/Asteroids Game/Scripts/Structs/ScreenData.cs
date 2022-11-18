using Unity.Entities;
using Unity.Mathematics;

namespace Asteroid.ComponentData
{
    public struct ScreenData : IComponentData
    {
        public float3 PointZero;
        public float3 PointMax;
    }
}