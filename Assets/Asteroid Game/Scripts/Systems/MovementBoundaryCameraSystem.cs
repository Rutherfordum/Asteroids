    using Unity.Entities;
    using Unity.Mathematics;
    using UnityEngine;

    public partial class MovementBoundaryCameraSystem: SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform, in ScreenData screenData) =>
            {
                float3 pos = transform.position;

                if (pos.z > screenData.PointMax.z)
                    pos.z = screenData.PointZero.z;

                if (pos.z < screenData.PointZero.z)
                    pos.z = screenData.PointMax.z;

                if (pos.x > screenData.PointMax.x)
                    pos.x = screenData.PointZero.x;

                if (pos.x < screenData.PointZero.x)
                    pos.x = screenData.PointMax.x;

                transform.position = pos;

            }).WithoutBurst().Run();
        }
    }