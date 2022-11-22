using System;
using Unity.Entities;
using UnityEngine;

public class LifeTimeAbilityComponent : MonoBehaviour, ILifeTimeAbility
{
    [SerializeField] 
    private float _lifeTime = 1;

    public float LifeTime { get=> _lifeTime;
        set
        {
            if (value <= 0)
                throw new ArgumentException("value less than or equal to zero");
            _lifeTime = value;
        }
    }

    public void Execute()
    {
      //  Destroy(this.gameObject);
    }

}