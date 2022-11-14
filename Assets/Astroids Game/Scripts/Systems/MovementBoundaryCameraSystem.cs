using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MovementBoundaryCameraSystem : ComponentSystem
{
    private EntityQuery _entityQuery;

    protected override void OnCreate()
    {

        _entityQuery = GetEntityQuery(ComponentType.ReadOnly<MovementBoundaryCameraComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_entityQuery)
            .ForEach((Entity entity,Transform transform, ref ScreenData screenData) =>
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
            });
    }
}