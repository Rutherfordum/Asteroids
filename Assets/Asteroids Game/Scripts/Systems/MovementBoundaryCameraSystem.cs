using Asteroid.ComponentData;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Asteroid.Systems
{
    public partial class MovementBoundaryCameraSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity entity, Transform transform, in ScreenData screenData) =>
            {
                float3 pos = transform.position;
                if (transform.position.z > screenData.PointMax.z)
                    pos.z = screenData.PointZero.z;

                if (transform.position.z < screenData.PointZero.z)
                    pos.z = screenData.PointMax.z;

                if (transform.position.x > screenData.PointMax.x)
                    pos.x = screenData.PointZero.x;

                if (transform.position.x < screenData.PointZero.x)
                    pos.x = screenData.PointMax.x;

                transform.position = pos;
            }).WithoutBurst().Run();
        }
    }
}