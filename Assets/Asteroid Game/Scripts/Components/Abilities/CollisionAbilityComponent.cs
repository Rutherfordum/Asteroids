using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CollisionAbilityComponent : MonoBehaviour, IConvertGameObjectToEntity, ICollisionAbility
{
    public Collider Collider;
    public List<MonoBehaviour> CollisionActions = new List<MonoBehaviour>();

    private List<IAbility> _collisionActionAbilities = new List<IAbility>();

#if UNITY_EDITOR
    private void OnValidate()
    {
        Collider = GetComponent<Collider>();
        foreach (var action in CollisionActions)
        {
            if (action is IAbility ability)
            {
                if (!_collisionActionAbilities.Contains(ability))
                    _collisionActionAbilities.Add(ability);
            }
            else
            {
                throw new ArgumentException("Collision action must derive from IAbility !!!");
            }
        }
    }
#endif

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        float3 position = gameObject.transform.position;

        switch (Collider)
        {
            case SphereCollider sphere:
                sphere.ToWorldSpaceSphere(out var sphereCenter, out var sphereRadius);
                dstManager.AddComponentData(entity, new ColliderData
                {
                    ColliderType = ColliderType.Sphere,
                    SphereCenter = sphereCenter - position,
                    SphereRadius = sphereRadius,
                    initialTakeOff = true
                });
                break;

            case CapsuleCollider capsule:
                capsule.ToWorldSpaceCapsule(out var capsuleStart, out var capsuleEnd, out var capsuleRadius);
                dstManager.AddComponentData(entity, new ColliderData
                {
                    ColliderType = ColliderType.Capsule,
                    CapsuleStart = capsuleStart - position,
                    CapsuleEnd = capsuleEnd,
                    CapsuleRadius = capsuleRadius,
                    initialTakeOff = true
                });
                break;

            case BoxCollider box:
                box.ToWorldSpaceBox(out var boxCenter, out var boxHalfExtents, out var boxOrientation);
                dstManager.AddComponentData(entity, new ColliderData
                {
                    ColliderType = ColliderType.Box,
                    BoxCenter = boxCenter - position,
                    BoxHalthExtents = boxHalfExtents,
                    BoxOrientation = boxOrientation,
                    initialTakeOff = true
                });
                break;
        }

        Collider.enabled = false;
    }

    public void Execute()
    {
        Debug.Log(gameObject.name);
        foreach (var action in _collisionActionAbilities)
        {
            action.Execute();
        }
    }
}