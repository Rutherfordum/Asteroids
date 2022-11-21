﻿using System;
using UnityEngine;

[RequireComponent(typeof(AbilitiesComponent))]
public class ShootAbilityComponent : MonoBehaviour, IShootAbility
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _shootDelay;

    public GameObject BulletPrefab { get => _bulletPrefab; set { } }
    public float ShootDelay
    {
        get => _shootDelay;

        set
        {
            if (_shootDelay <= 0)
                throw new ArgumentException("value cannot be less than or equal to zero");

            _shootDelay = value;
        }
    }

    private float _shootTime;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!GetComponent<AbilitiesComponent>().Abilities.Contains(this))
            GetComponent<AbilitiesComponent>().Abilities.Add(this);
    }
#endif

    public void Execute()
    {
        if (Time.time < _shootTime + ShootDelay) return;
        _shootTime = Time.time;

        Instantiate(BulletPrefab, transform.position, transform.rotation);
    }
}
