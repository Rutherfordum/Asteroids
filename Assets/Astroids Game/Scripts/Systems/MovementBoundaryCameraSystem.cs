using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class MovementBoundaryCameraSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((
            ref Translation transform,
            ref ScreenData screenData) =>
            {
                float3 pos = transform.Value;
                if (transform.Value.z > screenData.PointMax.z)
                    pos.z = screenData.PointZero.z;

                if (transform.Value.z < screenData.PointZero.z)
                    pos.z = screenData.PointMax.z;

                if (transform.Value.x > screenData.PointMax.x)
                    pos.x = screenData.PointZero.x;

                if (transform.Value.x < screenData.PointZero.x)
                    pos.x = screenData.PointMax.x;

                transform.Value = pos;
            }).Run();
    }
}