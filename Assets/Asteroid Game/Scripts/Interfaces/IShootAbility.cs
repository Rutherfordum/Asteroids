using UnityEngine;

public interface IShootAbility : IAbility
{
    public GameObject BulletPrefab { get; set; }
    public float ShootDelay { get; set; }
}