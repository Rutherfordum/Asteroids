﻿using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class AbilitiesComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    public List<MonoBehaviour> Abilities = new List<MonoBehaviour>();

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        foreach (var ability in Abilities)
        {
            if (ability is IShootAbility)
            {
                dstManager.AddComponentData(entity, new ShootData());
            }
        }
    }
}