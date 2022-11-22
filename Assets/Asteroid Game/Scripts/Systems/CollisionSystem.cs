using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public partial class CollisionSystem : SystemBase
{
    private Collider[] _results = new Collider[50];

    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, CollisionAbilityComponent abilityCollision, in ColliderData colliderData) =>
        {
            if (abilityCollision == null) return;
            float3 position = abilityCollision.gameObject.transform.position;
            Quaternion rotation = abilityCollision.gameObject.transform.rotation;

            int size = 0;

            switch (colliderData.ColliderType)
            {
                case ColliderType.Sphere:
                    size = Physics.OverlapSphereNonAlloc(colliderData.SphereCenter + position,
                        colliderData.SphereRadius, _results);
                    break;
                case ColliderType.Capsule:
                    var center =
                        ((colliderData.CapsuleStart + position) + (colliderData.CapsuleEnd + position)) / 2f;
                    var point1 = colliderData.CapsuleStart + position;
                    var point2 = colliderData.CapsuleEnd + position;
                    point1 = (float3)(rotation * (point1 - center)) + center;
                    point2 = (float3)(rotation * (point2 - center)) + center;
                    size = Physics.OverlapCapsuleNonAlloc(point1, point2,
                        colliderData.CapsuleRadius, _results);
                    break;
                case ColliderType.Box:
                    size = Physics.OverlapBoxNonAlloc(colliderData.BoxCenter + position,
                        colliderData.BoxHalthExtents, _results, colliderData.BoxOrientation * rotation);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (size > 0)
            {
                abilityCollision.Execute();
            }
        }).WithoutBurst().Run();
    }
}
